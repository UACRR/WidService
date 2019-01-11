using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Interfaces
{
    public interface IDBFPresenter
    {
        List<ExternalPay> GetListUnlinkPays();
        InputFile CheckInputFile(InputFile newFile);
        InputFile SaveInputFile(InputFile file);
        ExternalPay SaveLinkedPay(ExternalPay pay);
        List<ExternalPay> SaveListPays(List<ExternalPay> list);
    }
}
