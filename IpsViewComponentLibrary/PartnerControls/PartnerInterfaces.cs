using System;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.PartnerControls
{
    public interface IAnketaControls
    {
        event EventHandler<bool> SaveClick;
        event EventHandler CancelClick;

        void BeginBindings(Customer customer);
    }
}