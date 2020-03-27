using RestService;
using RestService.DataServices;
using RestService.RestAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RestMonitoringApplication
{
    /// <summary>
    /// DataControlPage.xaml 的交互逻辑
    /// </summary>
    public partial class DataControlPage : UserControl
    {
        private static DataControlPage _Instance = null;
        //public static ObservableCollection<Record> recordsData;
        public static DataControlPage Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new DataControlPage();
                return _Instance;
            }
            set { }
        }

        
        public DataControlPage()
        {
            InitializeComponent();
            DG1.DataContext = MainWindow.recordsData;

        }

        private void setData()
        {
            DG1.DataContext = MainWindow.recordsData;
        }        

}
}
