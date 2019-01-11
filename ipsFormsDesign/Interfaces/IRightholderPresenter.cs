using ipsFormsDesign.Dictionary;
using ipsmedserviceapp.Model.SQLViewsData;

namespace ipsFormsDesign.Interfaces
{
    /// <summary>
    /// Методи перевірки ОКПО та ІРІ на унікальність
    /// </summary>
    public interface IUniqueChecker
    {
        bool CheckOKPOIsUnique(string okpo);
        bool CheckIPIIsUnique(string okpo);
    }
    public interface IRightholderPresenter: IUniqueChecker
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
    }
}