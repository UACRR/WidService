using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Dictionary
{
    /// <summary>
    /// Опис Обзнайденого 'єкту права
    /// </summary>
    public class RegisterSearchObject
    {

        public int ObjId { get; set; }
        public string Name { get; set; }
        public string Performer { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public TimeSpan? Duration { get; set; }

    }
}
