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
using LibraryTradeMarket;
using DBLibrary;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            Business b = new Business();
            b.getTempCart("fd0531a65184448fabd22d4881bb58e6");
            b.addCart("q234", "0001", "bb", "10", "0", "PCS");

            return;

            ClassSqlclient cdb = new ClassSqlclient();
            cdb.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=TradeMarket;Persist Security Info=True;User ID=rd;Password=allone";
            cdb.isOpen();

            
            var x = b.isLogin("admin", LibraryTradeMarket.Utility.getSecretCode("1"));
            if (x != null)
            {
                MessageBox.Show(x.Account);
            }
            else
            {
                MessageBox.Show("error");
            }


            List<ProductTypeViewModel> l = new List<ProductTypeViewModel>();
            l = b.getProductType();

            List<ProductViewModel> lp = new List<ProductViewModel>();

            lp = b.getProductByType("水果");


            lp = b.getProductByKeyword("蕉");

        }
    }
}
