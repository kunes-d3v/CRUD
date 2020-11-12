using InterfaceServ;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
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

namespace ClientGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.Write("> Init Service connection ... ");
            // create base address
            var httpAddr = new Uri("http://127.0.0.1:9999/CRUDServer/Stock");

            // create a new channel
            var channel = new ChannelFactory<IStockService>(new WSHttpBinding());

            // create the EP
            var ep = new EndpointAddress(httpAddr);

            // assign the EP to the channel
            var proxy = channel.CreateChannel(ep);

            Debug.WriteLine("Done.");

            // execute a simulation scenario
            // add some new products categories
            ProductCategory prodCat = new ProductCategory();
            prodCat.id = 0;
            prodCat.name = "Detergents";
            prodCat.description = "For cleaning and sterilizing.";
            //prodCat.products = null;
            proxy.AddProductsCategory(prodCat);
            // add some new products
            // update some products
            // update some products category
            // update some products
            // update some products category

        }
    }
}
