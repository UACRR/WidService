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

        [TestMethod]
        public void TestUpdateCopyrightKind()
        {
            //define copyrightKind instance
            CopyrightKind copyrightKind = new CopyrightKind {
                CodeI = 666,
                Name = "TestCopyrightKindUpdated",
                CrGroupCode = 1
            };
            //get updated dictionary
            CopyrightKind result = _dictionary.UpdateCopyrightKind(copyrightKind);
            //checks for result data
            Assert.IsNotNull(result, "dictionary is not updated");
        }

        [TestMethod]
        public void TestDeleteCopyrightKind()
        {
            //define CodeI -> delete only created instances
            Random random = new Random();
            int codeI = random.Next(666, 999);
            //delete CopyrightKind instance
            bool result = _dictionary.DeleteCopyrightKind(codeI);
            //checks for result
            Assert.IsTrue(result, "copyrightKind is not deleted");
        }

        //[TestMethod]
        //public void TestGetCountry()
        //{

        //}

        //[TestMethod]
        //public void TestCreateCountry()
        //{
            
        //}

        //[TestMethod]
        //public void TestUpdateCountry()
        //{

        //}

        //[TestMethod]
        //public void TestDeleteCountry()
        //{

        //}

        [TestMethod]
        public void TestGetCreativeRoleType()
        {
            //define codeI
            int codeI = 1;
            //get result data
            CreativeRoleType result = _dictionary.GetCreativeRoleType(codeI);
            //check on success action
            Assert.IsNotNull(result, "dictionary(CreativeRoleType) is not exist");
        }

        [TestMethod]
        public void TestCreateCreativeRoleType()
        {
            //create CreativeRoleType instance
            Random random = new Random();
            int codeI = random.Next(16, 60000);
            CreativeRoleType creativeRole = new CreativeRoleType {
                CodeI = codeI,
                Name = "TestCreativeRoleType",
                CategoryCode = 5,
                Crtype = 1
            };
            //get result data
            CreativeRoleType result = _dictionary.CreateCreativeRoleType(creativeRole);
            //checks for result
            Assert.IsNotNull(result, "dictionary(CraetiveRoleType) is not created");
        }

        [TestMethod]
        public void TestUpdateCreativeRoleType()
        {
            //define CreativeRoleType for update
            CreativeRoleType creativeRole = new CreativeRoleType
            {
                CodeI = 1,
                Name = "TestCreativeRoleType",
                CategoryCode = 5,
                Crtype = 1
            };
            //get updated dictionary
            CreativeRoleType result = _dictionary.UpdateCreativeRoleType(creativeRole);
            //checks for result data
            Assert.IsNotNull(result, "dictionary(CreativeRoleType) is not updated");
        }
    }
}
