using System;
using System.Collections.Generic;
using System.Linq;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ipsFormsDesign.Tests
{
    [TestClass]
    public class CatalogServiceTest
    {
        private readonly RightholderCatalogService _catalog = RightholderCatalogService.GetInstance();
        private const int CustID = 42349;


        private int _fileId_temp = default(int);
        private CatalogFile _catalogFile_temp = null;

        [TestMethod]
        public void CRUD_test()
        {
            CreateCatalogFile_test();
            GetCatalogList_test();
            UpdateCatalogFile_test();
            DeleteCatalogFile_test();
        }

        // create
        private void CreateCatalogFile_test()
        {
            var catalogFile = new CatalogFile
            {
                FileName = "FileName",
                Comment = "TEST FILE",
                RhType = 3,
                Status = 0,
                PubCatalogItem = new ObservableListSource<PubCatalogItem>
                {
                    new PubCatalogItem
                    {
                        ObjName = "Name1",
                        Status = 0,
                        AuthorMusic = "AuthorMusic1",
                        AuthorText = "AuthorText1",
                    },
                    new PubCatalogItem
                    {
                        ObjName = "Name2",
                        Status = 0,
                        AuthorMusic = "AuthorMusic2",
                        AuthorText = "AuthorText2",
                    },
                    new PubCatalogItem
                    {
                        ObjName = "Name3",
                        Status = 0,
                        AuthorMusic = "AuthorMusic3",
                        AuthorText = "AuthorText3",
                    },
                }
            };

            //var result = _catalog.UploadCatalogFile(CustID, catalogFile);
            //Assert.IsNotNull(result);

            //_fileId_temp = result.FileId;

            //var resultEquals = result.ObjectEquals(catalogFile, new[] {"CustId", "FileId", "UserId"});
            //Assert.IsTrue(resultEquals);
        }

        // read
        private void GetCatalogList_test()
        {
            var result = _catalog.GetCatalogFileList(CustID);
            _catalogFile_temp = result?.FirstOrDefault();

            Assert.IsNotNull(result);
        }

        // update
        private void UpdateCatalogFile_test()
        {
            if (_catalogFile_temp == null)
                return;

            var catalogFile = new CatalogFile
            {
                FileName = "FileName_TEST",
                Comment = "TEST FILE_TEST_TEST",
                RhType = 3,
                Status = 1,
            };
            _catalogFile_temp.FileName = catalogFile.FileName;
            _catalogFile_temp.Comment = catalogFile.Comment;
            _catalogFile_temp.Status = catalogFile.Status;

            //_catalog.
        }

        // delete
        private void DeleteCatalogFile_test()
        {
            if (_fileId_temp == 0)
                return;

            var result = _catalog.DeleteCatalogFile(CustID, _fileId_temp);
            //Assert.IsTrue(result, "Catalog file not deleted!");
        }
    }
}
