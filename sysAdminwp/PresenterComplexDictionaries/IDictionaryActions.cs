using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sysAdminwp.PresenterComplexDictionaries
{
    interface IDictionaryActions<T> where T : class
    {
        //get dictionary by id
        T GetDictionary(int id);

        //create dictionary
        T Create(T sors);

        //update dictionary
        T Update(T sors);

        //delete dictionary
        bool Delete(int code);
    }
}
