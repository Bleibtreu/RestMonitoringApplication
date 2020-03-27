using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
using FirstFloor.ModernUI.Windows.Controls;
using RestService;
using RestService.DataServices;
using RestService.RequestAPI;
using RestService.RestAPI;

namespace RestMonitoringApplication
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : ModernWindow
    {

        private static MainWindow _Instance = null;
        public static ObservableCollection<Record> recordsData;
        private ISQLServerServices SQLServer;

        public static MainWindow Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new MainWindow();
                return _Instance;
            }
            set { }
        }

        
        public MainWindow()
        {
            InitializeComponent();
            _Instance = this;
            RestServices.Instance.Init();
            RestServices.Instance.RestEvent += new RestListen(ListenData);
            recordsData = new ObservableCollection<Record>();
            SQLServer = new SQLServerServices();
            LogHelper.Info("InitializeComponent success");         
        }

        private void SetData(Record record)
        {
            MainWindow.recordsData.Add(record);           
            LogHelper.Info("Save record data to the SQL-Server");
            SQLServer.SavaRecord(record);
        }

        public void ListenData(string id, string direction, string url, string attribution, DateTime occurrence_time, string status)
        {
            LogHelper.Info("Listen success, id = " + id + ", direction = " + direction + ", url = " + url + ", attribution = " + attribution + ", occurrence_time = " + occurrence_time.ToString("yyyy-M-d h:m:s") + "status = " + status);
            Record record = new Record
            {
                id = id,
                direction = direction,
                url = url,
                attribution = attribution,
                occurrence_time = occurrence_time,
                status = status              
            };
            SetData(record);
        }
    }
}
