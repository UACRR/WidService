using IronOcr;
using IronSoftware.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace CisNetImporter
{
    public partial class UcCisNetImporter : UserControl
    {
        public class TextLine
        {
            public List<string> Words {  get; set; }
        }

        public class RightHolder
        {
            public string Name {  get; set; }
            public string IpNameNr {  get; set; }
            public string PerSoc {  get; set; }
            public string PerShr {  get; set; }
            public string MecSoc {  get; set; }
            public string MecShr {  get; set; }

            public RightHolder()
            {
                Name = "";
                IpNameNr = "";
                PerSoc = "";
                PerShr = "";
                MecSoc = "";
                MecShr = "";
            }
        }

        private List<TextLine> _textLines;

        private string _workName;
        private string _workIswc;
        private List<RightHolder> _rightHolders;

        public UcCisNetImporter()
        {
            InitializeComponent();
            Configure();
        }
        
        private void Configure()
        {
            lvRightHolders.FullRowSelect = true;
            lvRightHolders.GridLines = true;
            lvRightHolders.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvRightHolders.MultiSelect = false;
            lvRightHolders.View = View.Details;

            lvRightHolders.Columns.Clear();
            lvRightHolders.Columns.Add("Назва", 100);
            lvRightHolders.Columns.Add("Код назви", 100);
            lvRightHolders.Columns.Add("Тов Пуб", 80);
            lvRightHolders.Columns.Add("Пуб%", 80);
            lvRightHolders.Columns.Add("Код Мех", 80);
            lvRightHolders.Columns.Add("Мех%", 100);
        }

        private void GetWords()
        {
            _textLines = new List<TextLine>(); 
            using (Bitmap bitmap = new Bitmap(pbScreenFragment.Image))
            using (var engine = new TesseractEngine(@"D:\OlegM\Sources\WidService\CisNetImporter\tessdata", "eng", EngineMode.Default))
            using (var page = engine.Process(bitmap, PageSegMode.SingleBlock))
            using (var iter = page.GetIterator())
            {
                iter.Begin();
                do
                {
                    do
                    {
                        var textLine = new TextLine {Words = new List<string>() };
                        do
                        {
                            string word = iter.GetText(PageIteratorLevel.Word).Trim();
                            textLine.Words.Add(word);
                        } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));
                        _textLines.Add(textLine);
                    } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
            }
        }
        
        private void FillMsInfo()
        {
            tbWorkName.Text = _workName;
            tbWorkIswc.Text = _workIswc;

            lvRightHolders.Items.Clear();
            _rightHolders.ForEach(x => {
                var item = lvRightHolders.Items.Add(x.Name);
                item.SubItems.Add(x.IpNameNr);
                item.SubItems.Add(x.PerSoc);
                item.SubItems.Add(x.PerShr);
                item.SubItems.Add(x.MecSoc);
                item.SubItems.Add(x.MecShr);
            });
        }

        public string RefineText()
        {
            return "";
        }

        private void AddRightHolders()
        {
            _rightHolders = new List<RightHolder>();
            for(var lineIdx = 3; lineIdx < _textLines.Count; lineIdx++)
            {
                var line = _textLines[lineIdx];
                AddRightHolder(line);
            }
        }

        private void AddRightHolder(TextLine line)
        {
            var rightHolder = new RightHolder();
            for(var idx = 0; idx < line.Words.Count; idx++)
            {
                var word = line.Words[idx];
                if(word.Length == 11)
                {
                    rightHolder.IpNameNr = word;
                    break;
                }
                rightHolder.Name += word + " ";
            }
            rightHolder.Name = rightHolder.Name.Trim();

            var perProcessed = false;
            for(var idx = 0; idx < line.Words.Count; idx++)
            {
                var word = line.Words[idx];
                if(word.Contains('%') && !perProcessed)
                {
                    rightHolder.PerSoc = line.Words[idx - 1];
                    rightHolder.PerShr = word;
                    perProcessed = true;
                }
                else if(word.Contains('%') && perProcessed)
                {
                    rightHolder.MecSoc = line.Words[idx - 1];
                    rightHolder.MecShr = word;
                }
            }

            _rightHolders.Add(rightHolder);
        }

        private void IronOcrRead()
        {
            using (Bitmap bitmap = new Bitmap(pbScreenFragment.Image))
            {
                // 3. Initialize IronTesseract and OcrInput
                var ocr = new IronTesseract();
                using (var input = new OcrInput())
                {
                    // 4. Load the bitmap directly into the OcrInput object
                    //input.LoadImage(bitmap);

                    // (Optional) Apply image filters for better OCR accuracy
                    // input.Deskew(); 
                    // input.DeNoise();

                    // 5. Perform OCR
                    var result = ocr.Read(input);
                    string extractedText = result.Text;

                    // Use the extracted text
                    Console.WriteLine(extractedText);
                }
            }
        }

        private void btnPasteFragment_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                var bmp = new Bitmap(Clipboard.GetImage());
                pbScreenFragment.Image = bmp;
                pbScreenFragment.SizeMode = PictureBoxSizeMode.AutoSize;
            }
            else
            {
                MessageBox.Show("No image found in the clipboard.");
                return;
            }
        }

        private void btnProcessFragment_Click(object sender, EventArgs e)
        {
            GetWords();
            tbRawText.Text = "";
            _textLines.ForEach(line => {
                    line.Words.ForEach(word => {
                        tbRawText.Text += word + " ";
                    });
                tbRawText.Text += "\r\n";
            });
            //try
            //{
            //    // 1. Cast the PictureBox Image to a Bitmap
            //    using (Bitmap bitmap = new Bitmap(pbScreenFragment.Image))
            //    {
            //        // 2. Initialize Tesseract Engine 
            //        // Note: Replace @"./tessdata" with the actual path to your tessdata folder
            //        using (var engine = new TesseractEngine(@"D:\OlegM\Sources\WidService\CisNetImporter\tessdata", "eng", EngineMode.Default))
            //        {
            //            // 3. Process the image
            //            using (var page = engine.Process(bitmap))
            //            {
            //                // 4. Extract and output the text
            //                string extractedText = page.GetText();
            //                Console.WriteLine(extractedText);
            //        
            //                // Display text in a TextBox or RichTextBox
            //                var lines = extractedText.Split('\n');
            //                var words = extractedText.Split(' ');
            //                tbRawText.Text = "";
            //                words.ToList().ForEach(word => {
            //                    var txt = word.Trim('\r');
            //                    if(txt != "")
            //                    {
            //                        tbRawText.Text += $"{txt}\r\n";
            //                    }
            //                } );
            //                
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error processing image: {ex.Message}");
            //}
        }

        private void btnProcessText_Click(object sender, EventArgs e)
        {
            var line = _textLines[0];
            _workName = "";
            line.Words.ForEach(word => {
                if(word.ToUpper() != "A")
                    _workName += word + " ";
            });
            _workName = _workName.Trim();
            
            line = _textLines[1];
            _workIswc = "";
            for(var idx = 0; idx < line.Words.Count; idx++)
            {
                var word = line.Words[idx];
                if(word.ToUpper() == "ISWC:")
                {
                    _workIswc = line.Words[idx + 1];
                }
            }
            _workIswc = _workIswc.Trim();

            AddRightHolders();

            FillMsInfo();
        }
    }
}
