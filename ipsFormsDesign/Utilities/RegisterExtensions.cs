using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Utilities
{
    public static class RegisterExtensions
    {
        public static List<RegisterItemViewModel> GetRegisterItemsList(this Register register)
        {
            var list = new List<RegisterItemViewModel>();

            foreach (var r in register.RegisterItem)
            {
                var rvm = new RegisterItemViewModel
                {
                    ItemName = r.ItemName,
                    AuthorMusic = r.AuthorMusic,
                    AuthorText = r.AuthorText,
                    CategoryCode = r.CategoryCode,
                    CountUse = r.CountUse,
                    DurationItem = r.DurationItem,
                    DurationUse = r.DurationUse,
                    Performer = r.Performer,
                    RegId = r.RegId,
                    RegIitemId = r.RegIitemId,
                    IsAuto = r.IsAuto,
                    GenreType = r.GenreType,
                    CodeItem = r.CodeItem,
                    RegisterItemFix = r.RegisterItemFix ?? new RegisterItemFix { TimeStart = new TimeSpan(), TimeEnd = new TimeSpan() },
                };

                if (r.Obj != null)
                    rvm.SetObjectData(r.ObjId, r.Obj.Name, r.Obj.Author, r.Obj.Performer, r.Obj.MediaTrack?.Duration, resetIsAuto: false);

                //rvm.RegisterExtraList.AddRange(r.RegisterExtra);

                list.Add(rvm);
            }

            return list;
        }
    }
}
