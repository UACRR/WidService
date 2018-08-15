using Telerik.WinControls;

namespace RightholderWorkplace.Localisation
{
    public class RadMessageUkraineLocalizationProvider : RadMessageLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case RadMessageStringID.AbortButton: return "Відмінити";
                case RadMessageStringID.CancelButton: return "Скасувати";
                case RadMessageStringID.IgnoreButton: return "Ігнорувати";
                case RadMessageStringID.NoButton: return "Ні";
                case RadMessageStringID.OKButton: return "ОК";
                case RadMessageStringID.RetryButton: return "Повторити";
                case RadMessageStringID.YesButton: return "Так";
                case RadMessageStringID.DetailsButton: return "Деталі";
                default:
                    return base.GetLocalizedString(id);
            }
        }
    }
}
