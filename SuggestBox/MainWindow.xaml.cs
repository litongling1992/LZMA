using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        private int terminalNo;

        public int TerminalNo
        {
            get { return terminalNo; }
            set
            {
                if (value != terminalNo)
                {
                    terminalNo = value;
                    OnPropertyChanged("TerminalNo");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format("终端编号的值为{0}", TerminalNo));
        }


        //private SuggestComboBox combobox;
        public MainWindow()
        {
            InitializeComponent();
            // combobox=new SuggestComboBox();
            //ComboboDisplay.Child = combobox;
            
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var list = new[]
                {
                    "Janean Mcgaha",
                    "Tama Gaitan",
                    "Jacque Tinnin",
                    "Elvira Woolfolk",
                    "Fransisca Owens",
                    "Minnie Ardoin",
                    "Renay Bentler",
                    "Joye Boyter",
                    "Jaime Flannery",
                    "Maryland Arai",
                    "Walton Edelstein",
                    "Nereida Storrs",
                    "Theron Zinn",
                    "Katharyn Estrella",
                    "Alline Dubin",
                    "Edra Bhatti",
                    "Willa Jeppson",
                    "Chelsea Revel",
                    "Sonya Lowy",
                    "Danelle Kapoor"
                };
            var datasource = list.Select((t, i) => new SearchItem() {Id = i, SearchValue = t}).ToList();
            SearchControl.SetDataSource(datasource);

            var keySource = list.Select((t, i) => new ClassItem() { SearchValue = t }).ToList();
            KeyWords.SetDataSource(keySource);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var list = new[]
             {
                    "A",
                    "B",
                    "C",
                    "D",
                    "E",                  
                };
            var datasource = list.Select((t, i) => new SearchItem() { Id = i, SearchValue = t }).ToList();
            var s=new List<SearchItem>();
            for (int i = 0; i < datasource.Count; i++)
            {
                if (i==0)
                {
                    s.Add(datasource[i]);
                    datasource.Remove(datasource[i]);
                    break;
                }
            }
            var newS = datasource;
            var b = s;
        }

        private void MainWindow_OnLocationChanged(object sender, EventArgs e)
        {
            //KeyWords.Popup.IsOpen = false;
        }
    }
}
