using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Application.Repositories;
using Application.Models;
using Application.Files.Text;
using Application.Files.Xml;

namespace Application.Tests
{
    [TestClass]
    public class FileTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Text_Exception_When_Invalid_Path()
        {
            //Arrange
            Text<string> text = new Text<string>();
            
            //Act
            text.Save(null, "Error");            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Xml_Exception_When_Invalid_Path()
        {
            //Arrange
            Xml<string> xml = new Xml<string>();
            string error = "Error";

            //Act
            xml.Read(null, out error);
        }

        [TestMethod]

        public void Xml_Deserialize()
        {
            //Arrange
            Xml<string> xml = new Xml<string>();
            string error = "Error";

            //Act
            xml.Save("path", error);
        }





    }
}
