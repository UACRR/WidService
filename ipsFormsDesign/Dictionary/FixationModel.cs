using ipsFormsDesign.Model;
using ipsFormsDesign.ViewModels.Fixations;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ipsFormsDesign.Dictionary
{
    public class FixationModel
    {
        public Fixation Fixation { get; set; }
        public ICollection<RegisterCountViewModel> RegisterCounts { get; set; } = new Collection<RegisterCountViewModel>();
    }
}
