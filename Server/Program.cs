using InterfaceServ;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // init a new instance of stock service
            Console.WriteLine("> Staring Stock Service ...");

            #region DB connection init (EF6)
            Debug.WriteLine(">> Init StockDB ... ");
            // create DB if does not exists
            DBStockCTX stockDB = new DBStockCTX();
            Console.Write(">>> Checking Stock DB existance: ");
            if (!stockDB.Database.Exists())
            {
                Console.Write("does not exists!\n>>>> Creating a new one ... ");
                stockDB.Database.Create();
                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("already exists.");
            }
            //Debug.WriteLine("Done.");
            #endregion

            #region Service init (WCF)
            // init the service here
            Debug.Write(">> Init Service ... ");
            Uri baseAddr = new Uri("http://127.0.0.1:9999/CRUDServer");

            // create the service host
            ServiceHost hoster = new ServiceHost(typeof(StockService), baseAddr);

            // add service EP
            hoster.AddServiceEndpoint(typeof(IStockService), new WSHttpBinding(), "Stock");

            // enable metadata exchange
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            hoster.Description.Behaviors.Add(smb);

            // add EP to host
            hoster.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            // open the host
            hoster.Open();
            Debug.WriteLine("Done.");
            #endregion
            Console.WriteLine("> Service is UP ...");

            Console.WriteLine("!!! Press ENTER to quit !!!");
            Console.ReadLine();
        }
    }
}
