//using MarketplaceAPI.Model;
//using MarketplaceAPI.Model.Context;
//using MarketplaceAPI.Repository.Generic;
//using Moq;
//using System;
//using Xunit;

//namespace MarketplaceAPI_Tests.Repository.Generic
//{
//    public class GenericRepositoryTests : IDisposable
//    {
//        private Product product;

//        private IRepository<Product> _repository;

//        private MySQLContext _context;

//        public GenericRepositoryTests()
//        {
//            _context = _repository.Create<MySQLContext>(T);
//        }

   

//        [Fact]
//        public void Create_StateUnderTest_ExpectedBehavior()
//        {
//            // Arrange
//            var unitUnderTest = this.CreateGenericRepository();
//            T item = TODO;

//            // Act
//            var result = unitUnderTest.Create(
//                item);

//            // Assert
//            Assert.True(false);
//        }

//        [Fact]
//        public void Delete_StateUnderTest_ExpectedBehavior()
//        {
//            // Arrange
//            var unitUnderTest = this.CreateGenericRepository();
//            long id = TODO;

//            // Act
//            unitUnderTest.Delete(
//                id);

//            // Assert
//            Assert.True(false);
//        }

//        [Fact]
//        public void Exist_StateUnderTest_ExpectedBehavior()
//        {
//            // Arrange
//            var unitUnderTest = this.CreateGenericRepository();
//            long? id = TODO;

//            // Act
//            var result = unitUnderTest.Exist(
//                id);

//            // Assert
//            Assert.True(false);
//        }

//        [Fact]
//        public void FindAll_StateUnderTest_ExpectedBehavior()
//        {
//            // Arrange
//            var unitUnderTest = this.CreateGenericRepository();

//            // Act
//            var result = unitUnderTest.FindAll();

//            // Assert
//            Assert.True(false);
//        }

//        [Fact]
//        public void FindById_StateUnderTest_ExpectedBehavior()
//        {
//            // Arrange
//            var unitUnderTest = this.CreateGenericRepository();
//            long id = TODO;

//            // Act
//            var result = unitUnderTest.FindById(
//                id);

//            // Assert
//            Assert.True(false);
//        }

//        [Fact]
//        public void FindByTerm_StateUnderTest_ExpectedBehavior()
//        {
//            // Arrange
//            var unitUnderTest = this.CreateGenericRepository();
//            string entity = TODO;
//            string attribute = TODO;
//            string term = TODO;

//            // Act
//            var result = unitUnderTest.FindByTerm(
//                entity,
//                attribute,
//                term);

//            // Assert
//            Assert.True(false);
//        }

//        [Fact]
//        public void GetRelated_StateUnderTest_ExpectedBehavior()
//        {
//            // Arrange
//            var unitUnderTest = this.CreateGenericRepository();
//            string entity = TODO;
//            string attribute = TODO;
//            string term = TODO;

//            // Act
//            var result = unitUnderTest.GetRelated(
//                entity,
//                attribute,
//                term);

//            // Assert
//            Assert.True(false);
//        }

//        [Fact]
//        public void Update_StateUnderTest_ExpectedBehavior()
//        {
//            // Arrange
//            var unitUnderTest = this.CreateGenericRepository();
//            T item = TODO;

//            // Act
//            var result = unitUnderTest.Update(
//                item);

//            // Assert
//            Assert.True(false);
//        }
//    }
//}
