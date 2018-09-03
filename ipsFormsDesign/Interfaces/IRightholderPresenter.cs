namespace ipsFormsDesign.Interfaces
{
    public interface IRightholderPresenter
    {
        void Show(int custId);
        void ShowNew(int customerType);
        void Save(bool accept);
    }
}