using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace InterfaceServ
{
    [ServiceContract]
    public interface IStockService
    {
        // define service operation

        #region product ops
        /// <summary>
        /// Add a new product.
        /// </summary>
        /// <param name="category">The new product to add.</param>
        /// <returns>Zero on success, other on failure.</returns>
        [OperationContract]
        int AddProduct(Product product);

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="product">The target product to delete.</param>
        /// <returns>Zero on success, other on failure.</returns>
        [OperationContract]
        int DeleteProduct(Product product);

        /// <summary>
        /// Update a specific product.
        /// </summary>
        /// <param name="productID">ID of the product to be updated.</param>
        /// <param name="newProduct">The new product to update with.</param>
        /// <returns>Zero on success, other on failure.</returns>
        [OperationContract]
        int UpdateProduct(int productID, Product newProduct);

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>List of all availble products.</returns>
        [OperationContract] 
        List<Product> GetAllProducts();

        #endregion

        #region product category ops
        /// <summary>
        /// Add a new product category.
        /// </summary>
        /// <param name="category">The new product category to add.</param>
        /// <returns>Zero on success, other on failure.</returns>
        [OperationContract]
        int AddProductsCategory(ProductCategory category);

        /// <summary>
        /// Delete a product category.
        /// </summary>
        /// <param name="category">The target product category to delete.</param>
        /// <returns>Zero on success, other on failure.</returns>
        [OperationContract]
        int DeleteProductsCategory(ProductCategory category);

        /// <summary>
        /// Update a specific product category.
        /// </summary>
        /// <param name="productID">ID of the product category to be updated.</param>
        /// <param name="newProduct">The new product category to update with.</param>
        /// <returns>Zero on success, other on failure.</returns>
        [OperationContract]
        int UpdateProductsCategory(int categoryID, ProductCategory newCategory);

        /// <summary>
        /// Get all products categories.
        /// </summary>
        /// <returns>List of all availble products.</returns>
        [OperationContract]
        List<ProductCategory> GetAllProductsCategories();
        #endregion


    }
}
