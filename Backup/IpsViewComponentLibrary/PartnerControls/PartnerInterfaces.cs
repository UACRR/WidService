using System;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.PartnerControls
{
    public interface IAnketaControls
    {
        event EventHandler<bool> SaveClick;

        void BeginBindings(Customer customer);
    }
}