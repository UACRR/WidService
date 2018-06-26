using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ipsFormsDesign.Model;

namespace ipsFormsDesign.Interfaces
{
    public class ObservableListSource<T> : ObservableCollection<T>, IListSource
               where T : class
    {
        private IBindingList _bindingList;

        public ObservableListSource()
        {
        }

        public ICollection<T> list { get { return this; } }

        public ObservableListSource(IList<T> list)
        {
            _bindingList = new BindingList<T>(list);
        }
        public ObservableListSource(ICollection<T> list)
        {
            _bindingList = new BindingList<T>(list.ToList());
        }

        bool IListSource.ContainsListCollection { get { return false; } }

        IList IListSource.GetList()
        {
            return _bindingList ?? (_bindingList = this.ToBindingList());
        }

        private IBindingList ToBindingList()
        {
            return new BindingList<T>(this);
        }


         
    }
}
