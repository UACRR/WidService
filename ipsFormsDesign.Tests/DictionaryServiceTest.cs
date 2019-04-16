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
            _dictionary.DeleteCopyrightKind(666);
            //default CopyrightKind dictionary
            CopyrightKind copyrightKind = new CopyrightKind {
                CodeI = 666,
                Name = "TestCopyrightKind",
                CrGroupCode = 1
            };
            //get created dictionary
            CopyrightKind result = _dictionary.CreateCopyrightKind(copyrightKind);
            _dictionary.DeleteCopyrightKind(666);
            //checks for result data
            Assert.IsNotNull(result, "copyrightKind is not created");
        }

        /// <summary>
        /// don't call Controller method - 1482
        /// </summary>
        //[TestMethod]
        //public void TestUpdateCopyrightKind()
        //{
        //    //define copyrightKind instance
        //    CopyrightKind copyrightKind = new CopyrightKind {
        //        CodeI = 666,
        //        Name = "TestCopyrightKindUpdated",
        //        CrGroupCode = 1
        //    };
        //    //get updated dictionary
        //    CopyrightKind result = _dictionary.UpdateCopyrightKind(copyrightKind);
        //    //checks for result data
        //    Assert.IsNotNull(result, "dictionary is not updated");
        //}

        [TestMethod]
        public void TestDeleteCopyrightKind()
        {
            //define CodeI -> delete only created instances
            CopyrightKind copyrightKind = new CopyrightKind
            {
                CodeI = 666,
                Name = "TestCopyrightKind",
                CrGroupCode = 1
            };
            _dictionary.CreateCopyrightKind(copyrightKind);
            //delete CopyrightKind instance
            bool result = _dictionary.DeleteCopyrightKind(666);
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
            _dictionary.DeleteCreativeRoleType(666);
            CreativeRoleType creativeRole = new CreativeRoleType {
                CodeI = 666,
                Name = "TestCreativeRoleType",
                CategoryCode = 5,
                Crtype = 1
            };
            //get result data
            CreativeRoleType result = _dictionary.CreateCreativeRoleType(creativeRole);
            _dictionary.DeleteCreativeRoleType(666);
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

        [TestMethod]
        public void TestDeleteCreativeRoleType()
        {
            //define CreativeRoleType for delete
            CreativeRoleType creativeRole = new CreativeRoleType
            {
                CodeI = 666,
                Name = "TestCreativeRoleType",
                CategoryCode = 5,
                Crtype = 1
            };
            _dictionary.CreateCreativeRoleType(creativeRole);
            //get result data
            bool result = _dictionary.DeleteCreativeRoleType(666);
            //checks for result data
            Assert.IsTrue(result, "dictionary(CreativeRoleType) is not delete");
        }

        [TestMethod]
        public void TestGetGenreType()
        {
            //define codeI for get dictionary
            int codeI = 1;
            //get result data
            GenreType result = _dictionary.GetGenreType(codeI);
            //checks for result data
            Assert.IsNotNull(result, "dictionary(GenreType) is not exist");
        }

        [TestMethod]
        public void TestCreateGenreType()
        {
            //define GenreType instance for add
            _dictionary.DeleteGenreType(666);
            GenreType genreType = new GenreType {
                CodeI = 666,
                CategoryCode = 5,
                Name = "TestGenreType"
            };
            //get added dictionary
            GenreType result = _dictionary.CreateGenreType(genreType);
            _dictionary.DeleteGenreType(666);
            //checks for result data
            Assert.IsNotNull(result, "genreType is not created");
        }

        [TestMethod]
        public void TestUpdateGenreType()
        {
            //define GenreType for update
            GenreType genreType = new GenreType
            {
                CodeI = 43752,
                CategoryCode = 5,
                Name = "TestGenreTypeUpdated"
            };
            //get result data
            GenreType result = _dictionary.UpdateGenreType(genreType);
            //checks for result data
            Assert.IsNotNull(result, "genreType is not updated");
        }

        [TestMethod]
        public void TestDeleteGenreType()
        {
            //define codeI for delete GenreType
            GenreType genreType = new GenreType
            {
                CodeI = 666,
                CategoryCode = 5,
                Name = "TestGenreType"
            };
            _dictionary.CreateGenreType(genreType);
            //get result data
            bool result = _dictionary.DeleteGenreType(666);
            //checks for result data
            Assert.IsTrue(result, "GenreType is not deleted");
        }

        [TestMethod]
        public void TestGetKlR030()
        {
            //define codeI for get KlR030
            int codeI = 3;
            //get result data
            KlR030 result = _dictionary.GetKlR030(codeI);
            //checks for result data
            Assert.IsNotNull(result, "KlR030 is not exist");
        }

        /// <summary>
        /// don't call Controller method - 1658
        /// </summary>
        //[TestMethod]
        //public void TestCreateKlR030()
        //{
        //    //define KlR030 for add
        //    _dictionary.DeleteKlR030(666);
        //    KlR030 klr030 = new KlR030 {
        //        R030 = 666.ToString(),
        //        R031 = 3,
        //        R030Name = "KlR030TestCreated"
        //    };
        //    //get result data
        //    KlR030 result = _dictionary.CreateKlR030(klr030);
        //    //checks result data
        //    Assert.IsNotNull(result, "KlR030 is not added");
        //}

        //don't call Controller method - 1671
        //[TestMethod]
        //public void TestUpdateKlR030()
        //{
        //    //define KlR030 for update
        //    KlR030 klr030 = new KlR030
        //    {
        //        R030 = "003",
        //        R031 = 3,
        //        R030Name = "KlR030TestCreated"
        //    };
        //    //get result data
        //    KlR030 result = _dictionary.UpdateKlR030(klr030);
        //    //checks result data
        //    Assert.IsNotNull(result, "KlR030 is not updated");
        //}

        /// <summary>
        /// don't call Controller Method - 1695
        /// </summary>
        //[TestMethod]
        //public void TestDeleteKlR030()
        //{
        //    //define codeI for delete
        //    KlR030 klr030 = new KlR030
        //    {
        //        R030 = 999.ToString(),
        //        R031 = 3,
        //        R030Name = "KlR030TestCreated"
        //    };
        //    _dictionary.CreateKlR030(klr030);
        //    //get result data
        //    bool result = _dictionary.DeleteKlR030(999);
        //    //checks for result data
        //    Assert.IsTrue(result, "KlR030 is not deleted");
        //}
        
        [TestMethod]
        public void TestGetSystemConstant()
        {
            //define SystemConstant id
            int codeI = 1;
            //get result data
            SystemConstant result = _dictionary.GetSystemConstant(codeI);
            //checks for result
            Assert.IsNotNull(result, "SystemConstant is not exist");
        }

        [TestMethod]
        public void TestCreateSystemConstant()
        {
            //define SystemConstant for add
            _dictionary.DeleteSystemConstant(666);
            SystemConstant systemConstant = new SystemConstant {
                CodeI = 666,
                Name = "testSystemConstant"
            };
            //get result data
            SystemConstant result = _dictionary.CreateSystemConstant(systemConstant);
            _dictionary.DeleteSystemConstant(666);
            //checks for result data
            Assert.IsNotNull(result, "SystemConstant is not created");
        }

        [TestMethod]
        public void TestUpdateSystemConstant()
        {
            //define SystemConstant instance for update
            SystemConstant systemConstant = new SystemConstant {
                CodeI = 37,
                Name = "testSystemConstantUpdate"
            };
            //get result data
            SystemConstant result = _dictionary.UpdateSystemConstant(systemConstant);
            //checks for result data
            Assert.IsNotNull(result, "SystemConstant is not updated");
        }

        [TestMethod]
        public void TestDeleteSystemConstant()
        {
            //define codeI for delete
            SystemConstant systemConstant = new SystemConstant
            {
                CodeI = 666,
                Name = "testSystemConstant"
            };
            _dictionary.CreateSystemConstant(systemConstant);
            //get result data
            bool result = _dictionary.DeleteSystemConstant(666);
            //checks for result data
            Assert.IsTrue(result, "SystemConstant dictionary is not exist");
        }

        [TestMethod]
        public void TestGetTypePlace()
        {
            //define TypePlace
            int codeI = 1;
            //get result data
            TypePlace result = _dictionary.GetTypePlace(codeI);
            //checks for result data
            Assert.IsNotNull(result, "TypePlace is not exist");
        }

        [TestMethod]
        public void TestCreateTypePlace()
        {
            //define TypePlace for add
            _dictionary.DeleteTypePlace(666);
            TypePlace typePlace = new TypePlace {
                CodeI = 666,
                Name = "CraetedTypePlace"
            };
            //get result data
            TypePlace result = _dictionary.CreateTypePlace(typePlace);
            _dictionary.DeleteTypePlace(666);
            //checks for result data
            Assert.IsNotNull(result, "TypePlace is not added");
        }

        [TestMethod]
        public void TestUpdateTypePlace()
        {
            //define TypePlace for update
            TypePlace typePlace = new TypePlace {
                CodeI = 25,
                Name = "TypePlaceUpdated"
            };
            //get result data
            TypePlace result = _dictionary.UpdateTypePlace(typePlace);
            //checks for result data
            Assert.IsNotNull(result, "typePlace is not updated");
        }

        [TestMethod]
        public void TestDeleteTypePlace()
        {
            //define codeI for delete
            TypePlace typePlace = new TypePlace
            {
                CodeI = 666,
                Name = "CraetedTypePlace"
            };
            _dictionary.CreateTypePlace(typePlace);
            //get result data
            bool result = _dictionary.DeleteTypePlace(666);
            //checks for result data
            Assert.IsTrue(result, "TypePlace is not deleted");
        }
    }
}
