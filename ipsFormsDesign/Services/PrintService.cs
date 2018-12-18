using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.ViewModels.Fixations;
using System;
using System.Collections.Generic;
using System.IO;

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

            _previewView.SetResult(_wordEngine.Pdf, _wordEngine.Docx);
            _previewView.StopWaiting();
        }

        public async void PrintFixationAct(Fixation fixation)
        {
            _previewView.SetHeader("Акт фіксації - " + fixation.EventName);
            _previewView.Show();
            _previewView.StartWaiting();

            var template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "F_Акт фіксації_друк.docx");

            await _wordEngine.ProcessFixationAct(template);

            _previewView.SetResult(_wordEngine.Pdf, _wordEngine.Docx);
            _previewView.StopWaiting();
        }

        public async void PrintFixationSlugbova(Fixation fixation)
        {
            _previewView.SetHeader("Службова - " + fixation.EventName);
            _previewView.Show();
            _previewView.StartWaiting();

            var template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "F_Службова до юридичного деп.docx");

            await _wordEngine.ProcessFixationSlugbova(template, fixation);

            _previewView.SetResult(_wordEngine.Pdf, _wordEngine.Docx);
            _previewView.StopWaiting();
        }

        public async void PrintFixationIdentificationAct(Fixation fixation, IEnumerable<RegisterCountViewModel> registerCountList)
        {
            _previewView.SetHeader("Акт ідентифікації - " + fixation.EventName);
            _previewView.Show();
            _previewView.StartWaiting();

            var template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "F_АКТ Ідентифікація.docx");

            await _wordEngine.ProcessFixationIdentificationAct(template, fixation, registerCountList);

            _previewView.SetResult(_wordEngine.Pdf, _wordEngine.Docx);
            _previewView.StopWaiting();
        }
    }

    public interface IPreviewView
    {
        void Show();
        void StartWaiting();
        void StopWaiting();
        void SetResult(string pathPdf, string pathDocx);
        void SetHeader(string header);
    }
}
