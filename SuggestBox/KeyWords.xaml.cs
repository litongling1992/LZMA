using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuggestBox
{
    /// <summary>
    /// KeyWords.xaml 的交互逻辑
    /// </summary>
    public partial class KeyWords : UserControl
    {
        private List<ClassItem> _datasource = new List<ClassItem>();
        public KeyWords()
        {
            InitializeComponent();
        }

        ///// <summary>
        ///// 隐藏下拉选项框
        ///// </summary>
        //private void HideSugLbVisual()
        //{
        //    SugLbVisual.IsOpen = false;
        //    SugList.Visibility = Visibility.Collapsed;
        //}

        public void SetDataSource(List<ClassItem> list)
        {
            //SugList.ItemsSource = list;
            //_datasource = list;
            SugList.ItemsSource = null;
            SugList.ItemsSource = list;
        }


        ///// <summary>
        ///// 显示下拉选项框
        ///// </summary>
        //private void ShowSugLbVisual()
        //{
        //    //SugLbVisual.StaysOpen = false;
        //    //SugLbVisual.StaysOpen = true;
        //    //SugLbVisual.IsOpen = false;
        //    SugLbVisual.IsOpen = true;
        //    SugList.Visibility = Visibility.Visible;
        //}

        private void SugList_OnSelectionChanged(object sender,
            SelectionChangedEventArgs e)
        {
            //var selectItem = SugList.SelectedItem as SearchItem;
            //if (selectItem == null) return;

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //SugLbVisual.StaysOpen = false;
            //SugLbVisual.IsOpen = false;
        }

        private void DataSourceChanged(List<ClassItem> list)
        {

            SugList.ItemsSource = null;
            SugList.ItemsSource = list;
            //if (list.Count < 1 || SearchTerms.Text.Trim().Length < 1) return;
            //ShowSugLbVisual();
        }


        //private void GotFocus_OnHandler(object sender, RoutedEventArgs e)
        //{

        //    var list = new List<ClassItem>();
        //    foreach (var item in _datasource)
        //    {
        //        list.Add(item);
        //    }
        //    DataSourceChanged(list);
        //}

        //private void LostFocus_OnHandler(object sender, RoutedEventArgs e)
        //{
        //    SugLbVisual.StaysOpen = false;
        //    SugLbVisual.IsOpen = false;
        //}
        private void KeyWords_OnLoaded(object sender, RoutedEventArgs e)
        {
            
        }
    }


    public class ClassItem
    {
        public string SearchValue { get; set; }
    }
}
