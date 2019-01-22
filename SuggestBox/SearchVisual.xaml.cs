using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SuggestBox
{
    /// <summary>
    /// SearchVisual.xaml 的交互逻辑
    /// </summary>
    public partial class SearchVisual
    {
        public SearchVisual()
        {
            InitializeComponent();
        }
        #region 字段和属性

        private List<SearchItem> _datasource=new List<SearchItem>();

        #endregion

        #region 对外函数

        public void SetDataSource(List<SearchItem> list)
        {
            SugList.ItemsSource = list;
            _datasource = list;
        }

        #endregion
        #region 对内函数

        /// <summary>
        /// 下拉选项框元素变动
        /// </summary>
        /// <param name="list"></param>
        private void DataSourceChanged(List<SearchItem> list)
        {
            SugList.ItemsSource = null;
            SugList.ItemsSource = list;
            //if (list.Count < 1 || SearchTerms.Text.Trim().Length < 1) return;
            ShowSugLbVisual();
        }

        /// <summary>
        /// 隐藏下拉选项框
        /// </summary>
        private void HideSugLbVisual()
        {
            SugLbVisual.IsOpen = false;
            SugList.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// 显示下拉选项框
        /// </summary>
        private void ShowSugLbVisual()
        {
            SugLbVisual.IsOpen = true;
            SugList.Visibility = Visibility.Visible;
        }
        #endregion
        #region 控件事件响应
        /// <summary>
        /// 输入框输入字符响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTerms_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var list =
                _datasource.FindAll(
                    s =>
                        s.SearchValue.ToLower()
                            .Contains(SearchTerms.Text.Trim().ToLower()));
            DataSourceChanged(list);
        }

        /// <summary>
        /// 搜索按钮点击响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            DataSourceChanged(_datasource);
            ShowSugLbVisual();
        }

        /// <summary>
        /// 下拉选项框选择响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SugList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectItem=SugList.SelectedItem as SearchItem;
            if (selectItem != null) SearchTerms.Text = selectItem.SearchValue;
            HideSugLbVisual();
        }

        #endregion

        private void SearchTerms_OnGotFocus(object sender, RoutedEventArgs e)
        {
            DataSourceChanged(_datasource);
        }
    }

    public class SearchItem
    {
        public int Id { get; set; }
        public string SearchValue { get; set; }
    }
}
