namespace ipsFormsDesign.Interfaces
{
    public interface IRightholderView
    {
        object AgreementAddRhDataSource { get; set; }
        object AnketaPersonDataSource { get; set; }
        object AnketaCompanyDataSource { get; set; }
        //define Anketa External Data Source
        object AnketaExternalDataSource { get; set; }
        object BankAccountDataSource { get; set; }
        object CustomerDataSource { get; set; }
        bool IsValid { get; }
        IRightholderPresenter Presenter { get; set; }
        object RightholderDataSource { get; set; }
        object TermsOfServiceDataSource { get; set; }

        void Run();
        void Hide();
        void SetHeader(string header);
    }
}