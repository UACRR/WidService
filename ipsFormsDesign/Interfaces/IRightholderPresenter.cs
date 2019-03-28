using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model.SQLViewsData;

namespace ipsFormsDesign.Interfaces
{
    /// <summary>
    /// Методи перевірки ОКПО та ІРІ на унікальність
    /// </summary>

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
        void UploadFromExcel();
        void SetAgreementNumber();
        IUniqueChecker UniquChecker { get; }
    }
}