using RightholderWorkplaceSeparateForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightholderWorkplaceSeparateForm.Services
{
    public class RightholdersService
    {
        private List<RightholderModel> _rightholders;
        private static int _lastId = 2;

        public RightholdersService()
        {
            _rightholders = new List<RightholderModel>
            {
                new RightholderModel { Id = 1, FirstName = "FirstName1", LastName = "LastName1" },
                new RightholderModel { Id = 2, FirstName = "FirstName2", LastName = "LastName2" },
            };
        }

        public IEnumerable<RightholderModel> GetAll()
        {
            return _rightholders;
        }

        public RightholderModel GetById(int id)
        {
            return _rightholders.FirstOrDefault(u => u.Id == id);
        }

        public void Add(RightholderModel rightholder)
        {
            rightholder.Id = ++_lastId;
            _rightholders.Add(rightholder);
        }

        public RightholderModel New()
        {
            return new RightholderModel();
        }

        public void Update(RightholderModel rightholder)
        {
            var foundedRightholder = _rightholders.Find(r => r.Id == rightholder.Id);

            if (foundedRightholder == null)
                return;

            foundedRightholder.FirstName = rightholder.FirstName;
            foundedRightholder.LastName = rightholder.LastName;
        }
    }
}
