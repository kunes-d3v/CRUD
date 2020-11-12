using InterfaceServ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Server
{
    public class StockService : IStockService
    {
        private DBStockCTX stockDB = null;    // stock database context handler
        private ServiceHost hoster = null;     // service handler

        public StockService()
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
            ServiceHost hoster = new ServiceHost(typeof(IStockService), baseAddr);

            // add service EP
            hoster.AddServiceEndpoint(typeof(IStockService), new WSHttpBinding(), "Products");

            // enable metadata exchange
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;

            // add EP to host
            hoster.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            // open the host
            hoster.Open();
            #endregion
        }

        #region product OPS
        public int Add(Product product)
        {
            // PS: there is some exceptions to catch ie: duplicates, null ...
            try
            {
                stockDB.products.Add(product);
                stockDB.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 1;
            }
            return 0;
        }
        public int Delete(Product product)
        {
            // PS: there is some exceptions to catch ie: null,  ...
            try
            {
                stockDB.products.Remove(product);
                stockDB.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 1;
            }
            return 0;
        }
        public int Update(int productID, Product newProduct)
        {
            // PS: there is some exceptions to catch ie: null,  ...
            try
            {
                /*
                // 1st method: with a query
                // init a query
                var query = from prod in stockDB.products 
                            where prod.id == productID 
                            select prod;

                // get the searched element
                Product product = query.FirstOrDefault<Product>();

                // 2nd method: without a query, use find method
                Product prod = stockDB.products.Find(productID);
                prod.name           = newProduct.name;
                prod.description    = newProduct.description;
                prod.price          = newProduct.price;
                prod.category       = newProduct.category;
                */

                // 3rd method: using attach method
                stockDB.products.Attach(newProduct);
                stockDB.Entry(newProduct).State = EntityState.Modified;

                stockDB.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 1;
            }
            return 0;
        }
        public List<Product> GetAllProducts()
        {
            return stockDB.products.ToList<Product>();
        }
        #endregion

        #region category OPS
        public int Add(ProductCategory category)
        {
            // PS: there is some exceptions to catch ie: duplicates, null ...
            try
            {
                stockDB.productscategories.Add(category);
                stockDB.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 1;
            }
            return 0;
        }

        public int Delete(ProductCategory category)
        {
            // PS: there is some exceptions to catch ie: duplicates, null ...
            try
            {
                stockDB.productscategories.Remove(category);
                stockDB.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 1;
            }
            return 0;
        }

        public int Update(int categoryID, ProductCategory newCategory)
        {
            /*
            // 1st method: with a query
            // init a query
            var query = from prodCat in stockDB.productscategories
                        where prodCat.id == categoryID
                        select prodCat;

            // get the searched element
            ProductCategory category = query.FirstOrDefault<ProductCategory>();

            // 2nd method: without a query, use find method
            ProductCategory prodCat = stockDB.productscategories.Find(categoryID);

            prodCat.name           = newCategory.name;
            prodCat.description    = newCategory.description;
            prodCat.products       = newCategory.products;
            */

            // 3rd method: using attach method
            stockDB.productscategories.Attach(newCategory);
            stockDB.Entry(newCategory).State = EntityState.Modified;

            stockDB.SaveChanges();
            return 0;
        }

        public List<ProductCategory> GetAllProductsCategories()
        {
            return stockDB.productscategories.ToList();
        }

        #endregion
    }
}
