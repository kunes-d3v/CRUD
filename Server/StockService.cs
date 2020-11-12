using InterfaceServ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace Server
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class StockService : IStockService
    {
        //private DBStockCTX stockDB = null;    // stock database context handler
        //private ServiceHost hoster = null;     // service handler

        #region product OPS
        public int AddProduct(Product product)
        {
            // PS: there is some exceptions to catch ie: duplicates, null ...
            Debug.Write(">>> Adding a new product ... ");
            try
            {
                DBStockCTX stockDB = new DBStockCTX();
                stockDB.products.Add(product);
                stockDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:");
                Console.WriteLine(ex.Message);
                return 1;
            }
            Debug.WriteLine("Done.");
            return 0;
        }
       
        public int DeleteProduct(Product product)
        {
            // PS: there is some exceptions to catch ie: null,  ...
            Debug.Write(">>> Deleting a product ... ");
            try
            {
                DBStockCTX stockDB = new DBStockCTX();
                stockDB.products.Remove(product);
                stockDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:");
                Console.WriteLine(ex.Message);
                return 1;
            }
            Debug.WriteLine("Done.");
            return 0;
        }
        
        public int UpdateProduct(int productID, Product newProduct)
        {
            // PS: there is some exceptions to catch ie: null,  ...
            Debug.Write(">>> Updating a new product ... ");
            try
            {
                DBStockCTX stockDB = new DBStockCTX();
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
                Debug.WriteLine("Error:");
                Console.WriteLine(ex.Message);
                return 1;
            }
            Debug.WriteLine("Done.");
            return 0;
        }
        
        public List<Product> GetAllProducts()
        {
            Debug.Write(">>> Requesting all product ...");
            List<Product> products = null;
            try
            {
                DBStockCTX stockDB = new DBStockCTX();
                products = stockDB.products.ToList<Product>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:");
                Console.WriteLine(ex.Message);
                return products;
            }
            Debug.WriteLine("Done.");
            return products;
        }
        #endregion



        #region category OPS
        public int AddProductsCategory(ProductCategory category)
        {
            // PS: there is some exceptions to catch ie: duplicates, null ...
            Debug.Write(">>> Adding a new products category ... ");
            try
            {
                DBStockCTX stockDB = new DBStockCTX();
                stockDB.productscategories.Add(category);
                stockDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:");
                Console.WriteLine(ex.Message);
                return 1;
            }
            Debug.WriteLine("Done.");
            return 0;
        }

        public int DeleteProductsCategory(ProductCategory category)
        {
            // PS: there is some exceptions to catch ie: duplicates, null ...
            Debug.Write(">>> Deleting a products category ... ");
            try
            {
                DBStockCTX stockDB = new DBStockCTX();
                stockDB.productscategories.Remove(category);
                stockDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:");
                Console.WriteLine(ex.Message);
                return 1;
            }
            Debug.WriteLine("Done.");
            return 0;
        }

        public int UpdateProductsCategory(int categoryID, ProductCategory newCategory)
        {
            Debug.Write(">>> Updating a products category ... ");
            DBStockCTX stockDB = new DBStockCTX();
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
            Debug.WriteLine("Done.");
            return 0;
        }

        public List<ProductCategory> GetAllProductsCategories()
        {
            Debug.Write(">>> Requesting all product ...");
            List<ProductCategory> productsCat = null;
            try
            {
                DBStockCTX stockDB = new DBStockCTX();
                productsCat = stockDB.productscategories.ToList<ProductCategory>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:");
                Console.WriteLine(ex.Message);
                return productsCat;
            }
            Debug.WriteLine("Done.");
            return productsCat;
        }
        #endregion
    }
}
