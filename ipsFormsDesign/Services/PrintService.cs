using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.ViewModels.Fixations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Services
{
    public class PrintService
    {
        private readonly WordEngine _wordEngine;
        private readonly IPreviewView _previewView;

        public PrintService(IPreviewView previewView)
        {
            _previewView = previewView;
            _wordEngine = new WordEngine(IpsGlobal.AnketaDictionaties);
        }

        public async void PrintFixationOrder(Fixation fixation)
        {
            _previewView.SetHeader("Наказ на фіксацію - " + fixation.EventName);
            _previewView.Show();
            _previewView.StartWaiting();

            var template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "F_Наказ на фіксацію.docx");

            await _wordEngine.ProcessFixationOrder(template, fixation);

            _previewView.LoadPdf(_wordEngine.Pdf);
            _previewView.StopWaiting();
        }

        public async void PrintFixationAct(Fixation fixation)
        {
            _previewView.SetHeader("Акт фіксації - " + fixation.EventName);
            _previewView.Show();
            _previewView.StartWaiting();

            var template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "F_Акт фіксації_друк.docx");

            await _wordEngine.ProcessFixationAct(template, fixation);

            _previewView.LoadPdf(_wordEngine.Pdf);
            _previewView.StopWaiting();
        }

        public async void PrintFixationIdentificationAct(Fixation fixation, IEnumerable<RegisterCountViewModel> registerCountList)
        {
            _previewView.SetHeader("Акт ідентифікації - " + fixation.EventName);
            _previewView.Show();
            _previewView.StartWaiting();

            var template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "F_АКТ Ідентифікація.docx");

            await _wordEngine.ProcessFixationIdentificationAct(template, fixation, registerCountList);

            _previewView.LoadPdf(_wordEngine.Pdf);
            _previewView.StopWaiting();
        }
    }

    public interface IPreviewView
    {
        void Show();
        void StartWaiting();
        void StopWaiting();
        void LoadPdf(string path);
        void SetHeader(string header);
    }
}
