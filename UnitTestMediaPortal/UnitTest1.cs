using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IpsViewComponentLibrary;
//using ipsAnketaClient;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using WebAPIConnector;
using ipsFormsDesign;
using ipsFormsDesign.Interfaces;
using System.ComponentModel;
using ipsFormsDesign.Services;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using ipsFormsDesign.Data;
using AutoMapper;
//using Autofac;



namespace UnitTestMediaPortal
{
    [TestClass]
    public class UnitTestBinding
    {
        private ApiConnector api = null;


        [TestInitialize]
        public void Initialize()
        {
            api = new ApiConnector();
        }

        public interface Interface01
        {
            string body { get; set; }
        }
        public interface Interface02
        {
            string body { get; set; }
        }
        [TestMethod]
        public void TestIpsGlobal()
        {
            IpsGlobal.addInstance(typeof(Interface01), "interface01");
            Assert.AreEqual(IpsGlobal.Instances[typeof(Interface01)], "interface01");

        }
        [TestMethod]
        public void CheckDbfLoad()
        {
            DbfEngine eng = new DbfEngine();
            var items = eng.ReadDbfFile(@"G:\MediaService\Import\DBF\181023e.DBF");
        }

        [TestMethod]
        public void TestDbfPresenter()
        {
            DbfService _service = new DbfService();
            var list = _service.GetListOfConsumers();
            Assert.IsNotNull(list);
            Console.WriteLine($"Count of Consumers is {list.Count}");
        }

        class ClsOne
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ClsTwo Item { get; set; }
        }

        class ClsTwo
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        class clsDTO
        {
            public int Id { get; set; }
            public string ClsOneName { get; set; }
            public string ClsTwoName { get; set; }
        }
        [TestMethod]
        public void TestAutoMap()
        {
            Mapper.Initialize( cfg => {
                cfg.CreateMap<ClsOne, clsDTO>()
                .ForMember( d => d.Id, opt => opt.MapFrom( src => src.Id ))
                .ForMember(d => d.ClsOneName, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.ClsTwoName, opt => opt.MapFrom(src => src.Item.Name))
                .ReverseMap()
                .ForPath( d => d.Item.Id, opt => opt.MapFrom( src => src.Id ))
                ;
            });
            ClsOne one = new ClsOne { Id = 1, Name = "One",
                Item = new ClsTwo { Id = 1, Name = "Two"}
            };

            var result = Mapper.Map<ClsOne, clsDTO>(one);
            Assert.AreEqual(result.ClsOneName, one.Name);

            result.Id = 2;
            Mapper.Map(result, one);

            Assert.AreEqual(one.Id, 2);
            Assert.AreEqual(one.Id, one.Item.Id);
            Assert.AreEqual(result.ClsTwoName, one.Item.Name);
        }

    }
}
