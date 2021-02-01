using ElectronicShop.Data.Infrastructure;
using ElectronicShop.Data.Repositories;
using ElectronicShop.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class ProductCategoryRepositoryTest
    {
        IDbFactory dbFactory;                       // Cung cấp cho IProductRepository để khởi tạo
        IProductCategoryRepository productCategoryRepository;       // Dung để test các phương thức của Repository
        IUnitOfWork unitOfWork;                     // Hỗ trợ test Repository, lưu data

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            productCategoryRepository = new ProductCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void ProductCategory_Repository_Create()
        {
            ProductCategory productCategory = new ProductCategory();
            productCategory.Name = "Product_Repository_Create";
            productCategory.Alias = "Product_Repository_Create";

            var result = productCategoryRepository.Add(productCategory);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }

        [TestMethod]
        public void ProductCategory_Repository_GetAll()
        {  
            var result = productCategoryRepository.GetAll(); 
             
            Assert.AreEqual(1, result.Count());
        }
    }
}
