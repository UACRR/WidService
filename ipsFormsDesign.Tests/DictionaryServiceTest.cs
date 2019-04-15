using System;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ipsFormsDesign.Tests
{
    [TestClass]
    public class DictionaryServiceTest
    {
        private DictionaryService _dictionary = new DictionaryService();

        [TestMethod]
        public void TestGetCopyrightKind()
        {
            //default id dictionary
            int id = 1;
            //get dictionary
            CopyrightKind result = _dictionary.GetCopyrightKind(id);
            //checks result data
            Assert.IsNotNull(result, "dictionary CopyrightKind is not exist");
        }

        [TestMethod]
        public void TestCreateCopyrightKind()
        {
            //define different value for CodeI
            Random random = new Random();
            int codeI = random.Next(667, 999);
            //default CopyrightKind dictionary
            CopyrightKind copyrightKind = new CopyrightKind {
                CodeI = codeI,
                Name = "TestCopyrightKind",
                CrGroupCode = 1
            };
            //get created dictionary
            CopyrightKind result = _dictionary.CreateCopyrightKind(copyrightKind);
            //checks for result data
            Assert.IsNotNull(result, "copyrightKind is not created");
        }
    }
}
