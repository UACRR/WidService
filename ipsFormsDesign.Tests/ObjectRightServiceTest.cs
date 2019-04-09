using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using ipsFormsDesign.Services.ObjectUploading;
using ipsFormsDesign.ViewModels.ObjectsRight;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ipsFormsDesign.Tests
{
    [TestClass]
    public class ObjectRightServiceTest
    {
        private ObjectRightService _objectRightService;

        [TestInitialize]
        public void TestInit()
        {
            _objectRightService = new ObjectRightService();
            //check on null state
            Assert.IsNotNull(_objectRightService, "ObjectRightService is not initialized, state -null");
        }

        //check return data of Dictionaries
        [TestMethod()]
        public void TestGetDictionary()
        {
            //get save return data
            ObjectRightDictionaries result = _objectRightService.GetDictionary();
            //check on null state result
            Assert.IsNotNull(result, "ObjectRightDictionaries is null");
            //check collection 'category' on amount elements
            Assert.IsTrue(result.category.Count != 0, "category is empty");
            //check collection 'copyrightType' on amount elements
            Assert.IsTrue(result.copyrightType.Count != 0, "copyrightType is empty");
            //check collection 'creativeRoleType' on amount elements
            Assert.IsTrue(result.creativeRoleType.Count != 0, "creativeRoleType is empty");
            //check collection 'etGenre' on amount elements
            Assert.IsTrue(result.etGenre.Count != 0, "etGenre is empty");
            //check collection 'etRole' on amount elements
            Assert.IsTrue(result.etRole.Count != 0, "etRole is empty");
            //check collection 'genreType' on amount elements
            Assert.IsTrue(result.genreType.Count != 0, "genreType is empty");
            //check collection 'legalBasis' on amount elements
            Assert.IsTrue(result.legalBasis.Count != 0, "legalBasis is empty");
            //check collection 'objAct' on amount elements
            Assert.IsTrue(result.objAct.Count != 0, "objAct is empty");
            //check collection 'objectStatus' on amount elements
            Assert.IsTrue(result.objectStatus.Count != 0, "objectStatus is empty");
            //check collection 'permitStatus' on amount elements
            Assert.IsTrue(result.permitType.Count != 0, "permitType is empty");
            //check collection 'seekType' on amount elements
            Assert.IsTrue(result.seekType.Count != 0, "seekType is empty");
            //check collection 'specType' on amount elements
            Assert.IsTrue(result.specType.Count != 0, "specType is empty");
            //check collection 'folkType' on amount elements
            Assert.IsTrue(result.folkType.Count != 0, "folkType is empty");
            //check collection 'RegisterStatuses' on amount elements
            Assert.IsTrue(result.RegisterStatuses.Count != 0, "RegisterStatuses is empty");
        }

        [TestMethod()]
        public void TestGetMainView()
        {
            //save returned data 'objectright/view/list_01'
            var result = _objectRightService.GetMainView();
            //check result on null state
            Assert.IsNotNull(result, "result data is null");
            //check collection on amount elements
            Assert.IsTrue(result.Count != 0, "collection is empty");
        }

        [TestMethod()]
        public void TestGetDictionary1()
        {
            var list = _objectRightService.GetDictionary();
            Assert.IsNotNull(list, "Is Not NULL");
            Assert.AreNotEqual(list.copyrightType.Count, 0, "copyrightType.Count");
        }

        [TestMethod()]
        public void TestGetObjectRights()
        {
            ObjectRightQuery query = new ObjectRightQuery { PageSize = 20, Page = 1 };
            var list = _objectRightService.GetObjectRights(query);
            Assert.IsNotNull(list, "IsNotNull");
            Assert.AreNotEqual(list.List.Count, 0, "Count != 0");
        }

        [TestMethod()]
        public async Task TestGetObjectRightsAsync()
        {
            ObjectRightQuery query = new ObjectRightQuery { PageSize = 20, Page = 1 };
            var list = await _objectRightService.GetObjectRightsAsync(query);
            Assert.IsNotNull(list, "IsNotNull");
            Assert.AreNotEqual(list.List.Count, 0, "Count != 0");
        }

        [TestMethod()]
        public void TestNew()
        {
            var newItem = _objectRightService.New(6);
            Assert.IsNotNull(newItem);
        }

        [TestMethod()]
        public void TestGetObjectsByFilter()
        {
            var list = _objectRightService.GetObjectsByFilter("obj");
            Assert.AreNotEqual(list.Count, 0, "Count != 0");
        }

        [TestMethod()]
        public void TestGetRightholdersObjectsRights()
        {
            var list = _objectRightService.GetRightholdersObjectsRights(1835);
            Assert.IsNotNull(list);
        }

        [TestMethod()]
        public void TestGetObjectById()
        {
            var objrht = _objectRightService.GetObjectById(5842);
            Assert.IsNotNull(objrht, "IsNotNull");
        }

        [TestMethod()]
        public void TestGetObjectRightholders()
        {
            var list = _objectRightService.GetObjectRightholders(5842);
            Assert.AreNotEqual(list.Count, 0, "Count != 0");
        }

        [TestMethod()]
        public void TestGetDataBr()
        {
            var objBox = _objectRightService.GetDataBr(7111);
            Assert.IsNotNull(objBox);
        }
    }
}
