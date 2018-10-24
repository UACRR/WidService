using ipsFormsDesign.Dictionary;

namespace ipsFormsDesign.Interfaces
{
    public interface IRightholderPresenter
    {
        void Show(int custId);
        void ShowNew(int customerType);
        void SetAgreementRightholderStatus(AgreementStatuses newStatus);
        void Save(bool accept);
        void Close();
        void CopyAddressFactToRegister();
        void CopyAddressFactToLetter();
        void CopyAddressRegisterToLetter();
        void AddNewObject(int category);
        void AddExistingObject();
        void LoadFromExcel();
    }
}