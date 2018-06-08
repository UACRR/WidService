using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMVCStack.Interface;

namespace TestMVCStack.Main
{
    public class ServiceMain : IService
    {
        internal int localId = 0;
        class test : IData
        {

            public int id { get; set; }
            public string field1 { get; set ; }
            public string field2 { get; set ; }
            public bool isNew { get; set; } = true;

            internal IData Clone()
            {
                return new test { id=id, field1=field1, field2=field2, isNew =isNew };
            }
        }

        private ObservableCollection<IData> list = null;
        public IList<IData> GetList()
        {
            if(list==null)
            {
                list = new ObservableCollection<IData>();

                list.Add(new test { field1 = "1111", field2 = "222222", isNew = false, id=localId++ });
                list.Add(new test { field1 = "4444", field2 = "222222", isNew= false, id = localId++ });

            }

            return list;
        }

        public void AddNexItem()
        {
            list.Add(new test { field1 = "555", field2 = "333", isNew = false, id = localId++ });

        }

        public IData newItem()
        {
            return new test { isNew = true, id = localId++ };
        }

        public IData Clone( object row )
        {
            test item = row as test;

            return item?.Clone();
        }

        public void Save( object row )
        {
            if(!(row is test ))
            {
                return;
            }

            test editRow = row as test;

            if (editRow.isNew)
            {
                editRow.isNew = false;
                list.Add(editRow);

                return;
            }

            var dest = list.Where(rec => ((test)rec)?.id == editRow.id).SingleOrDefault();
            if (dest == null)
                return;

            dest.field1 = editRow.field1;
            dest.field2 = editRow.field2;


        }


    }
}
