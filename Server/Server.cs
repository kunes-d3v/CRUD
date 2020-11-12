using InterfaceServ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private DBStockCTX stockDB;
        public Server()
        {
            /* PS:
             * - catch exceptions must be add!
             */

            #region DB connection init (EF6)
            stockDB = new DBStockCTX();
            #endregion

            #region Service init (WCF)
            // init the service here
            Uri baseAddr = new Uri("http://127.0.0.1:9999/CRUDServer");

            // create the service host
            ServiceHost host = new ServiceHost(typeof(IStockService), baseAddr);

            // add service EP
            host.AddServiceEndpoint(typeof(IStockService), new WSHttpBinding(), "Products");

            // enable metadata exchange
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;

            // add EP to host
            host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            // open the host
            host.Open();
            #endregion
        }
    }
}
