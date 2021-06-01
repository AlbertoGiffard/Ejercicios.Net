using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Application.Repositories;
using Application.Models;

namespace Application.Tests
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        public void CreateSuccessfullyTest()
        {
            //Arrange
            CustomerRepository repository = new CustomerRepository();

            int millisecond = DateTime.Now.Millisecond;

            Customer entityToCreate = new Customer()
            {
                LastName = "TestCustomerLastName" + millisecond,
                Name = "TestCustomerName" + millisecond
            };
            //Notar que entityToCreate.Id es null en este momento


            //Act
            repository.Create(entityToCreate);

            Customer entityToValidate =
                repository.GetById(entityToCreate.Id);

            //Assert
            Assert.IsNotNull(entityToValidate);
            Assert.IsTrue(entityToValidate.Id > 0);
        }

        ///// <summary>
        /////A test for GetAll
        /////</summary>
        [TestMethod()]
        public void GetAllTest()
        {
            //Arrange
            CustomerRepository target = new CustomerRepository();
            List<Customer> expected = new List<Customer>(3);
            List<Customer> actual;

            //Act
            actual = target.GetAll();

            //Assert
            Assert.IsNotNull(actual);

        }
        ///// <summary>
        /////A test for GetById
        /////</summary>
        [TestMethod()]
        public void GetByIdTest()
        {
            //Arrange
            CustomerRepository target = new CustomerRepository();
            long entityId = 20;
            Customer expected = new Customer("Junior", "CustomerLastname20", 32);
            target.Create(expected);
            Customer actual;

            //Act
            actual = target.GetById(entityId);

            //Assert
            Assert.AreEqual(expected.LastName, actual.LastName);

        }
        ///// <summary>
        /////A test for Remove
        /////</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            //Arrange
            CustomerRepository target = new CustomerRepository();
            Customer entity = new Customer("Junior", "Prueba", 32);
            entity.Id = 1;
            Customer actual;

            //Act
            target.Remove(entity);

            //Assert
            Assert.IsNull(target.GetById(1));

        }
        ///// <summary>
        /////A test for Update
        /////</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            //Arrange
            CustomerRepository target = new CustomerRepository();
            Customer entity = new Customer("Junior", "Prueba", 32);
            target.Create(entity);
            entity.Name = "test";

            //Act
            target.Update(entity);

            //Assert
            Assert.AreEqual("test", entity.Name);

        }
    }
}
