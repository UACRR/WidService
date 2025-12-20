using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwrTools
{
    public class CwrFileSplitter
    {
        internal class FilePartTranRange
        {
            public int StartIdx { get; set; }
            public int EndIdx { get; set; }
        }

        private int _maxLineCount;
        private string _sourceFileFullName;
        private string _sourceFileName;
        private string _sourceDirFullName;
        private string _targetDirFullName;

        private string _hdrLine;
        private string _grhLine;
        private string _grtLine;
        private string _trlLine;
        private List<List<string>> _tranLinesList;

        private List<FilePartTranRange> _filePartTranRangeList;

        public CwrFileSplitter(string sourceFileFullName, int maxLineCount)
        {
            _sourceFileFullName = sourceFileFullName;
            _maxLineCount = maxLineCount;

            _sourceFileName = Path.GetFileName(_sourceFileFullName);
            _sourceDirFullName = Path.GetDirectoryName(sourceFileFullName);
            _targetDirFullName = Path.Combine(_sourceDirFullName, $"{_sourceFileName}_{_maxLineCount}");
        }
        public void SplitFile()
        {
            PreProcessFile();
            WriteFileParts();
        }
        private void PreProcessFile()
        {
            try
            {
                _tranLinesList = new List<List<string>>();
                List<string> tranLines = null;
                foreach (string line in File.ReadLines(_sourceFileFullName))
                {
                    var recType = line.Substring(0, 3);
                    switch(recType)
                    {
                        case "":
                            break;
                        case "HDR":
                            _hdrLine = line;
                            break;
                        case "GRH":
                            _grhLine = line;
                            break;
                        case "GRT":
                            _tranLinesList.Add(tranLines);
                            _grtLine = line;
                            break;
                        case "TRL":
                            _trlLine = line;
                            break;
                        case "NWR":
                            if(tranLines != null)
                            {
                                _tranLinesList.Add(tranLines);
                            }
                            tranLines = new List<string> { line };
                            break;
                        default:
                            tranLines.Add(line);
                            break;
                    }
                }

                CalcTranParts();
            }
            catch (IOException e)
            {
                Console.WriteLine($"An I/O error occurred: {e.Message}");
            }
        }

        private void CalcTranParts()
        {
            _filePartTranRangeList = new List<FilePartTranRange>();

            var lineCnt = 4;
            var startIdx = 0;
            for (int idx = 0; idx < _tranLinesList.Count; idx++)
            {
                lineCnt += _tranLinesList[idx].Count;
                if (idx == _tranLinesList.Count - 1)
                {
                    _filePartTranRangeList.Add(new FilePartTranRange { StartIdx = startIdx, EndIdx = _tranLinesList.Count - 1 });
                }                
                else if(lineCnt > _maxLineCount)
                {
                    _filePartTranRangeList.Add(new FilePartTranRange { StartIdx = startIdx, EndIdx = idx - 1 });
                    lineCnt = 4 + _tranLinesList[idx].Count;
                    startIdx = idx;
                }
            }
        }
    
        private void WriteFileParts()
        {
            if(Directory.Exists(_targetDirFullName))
            {
                Directory.Delete(_targetDirFullName, true);
            }
            Directory.CreateDirectory(_targetDirFullName);
            for (var idx = 0; idx < _filePartTranRangeList.Count; idx++)
            {
                var rng = _filePartTranRangeList[idx];
                var filePartFullName = Path.Combine(_targetDirFullName, $"({idx}){_sourceFileName}");
                WriteFilePart(rng, filePartFullName);
            }

            var zipFileFullName = Path.Combine(_sourceDirFullName, $"{_sourceFileFullName}.{_maxLineCount}.zip");
            File.Delete(zipFileFullName);
            System.IO.Compression.ZipFile.CreateFromDirectory(_targetDirFullName, zipFileFullName);

            if(Directory.Exists(_targetDirFullName))
            {
                Directory.Delete(_targetDirFullName, true);
            }
        }

        private void WriteFilePart(FilePartTranRange rng, string filePartFullName)
        {
            try
            {
                using (StreamWriter fw = new StreamWriter(filePartFullName))
                {
                    fw.WriteLine(_hdrLine);
                    fw.WriteLine(_grhLine);

                    var localTranIdx = 0;
                    var recordCount = 0;
                    var tranCount = 0;
                    for (var idxTran = rng.StartIdx; idxTran <= rng.EndIdx; idxTran++)
                    {
                        var tranLines = _tranLinesList[idxTran];
                        foreach (var line in tranLines)
                        {
                            var targetLine = $"{line.Substring(0, 3)}{localTranIdx.ToString("D8")}{line.Substring(11)}";
                            fw.WriteLine(targetLine);
                            recordCount++;
                        }

                        localTranIdx++;
                        tranCount++;
                    }

                    var targetGrtLine = $"GRT{tranCount:D8}{recordCount:D8}";
                    fw.WriteLine(targetGrtLine);

                    var targetTrlLine = $"TRL{1:D5}{tranCount:D8}{recordCount:D8}";
                    fw.WriteLine(targetTrlLine);
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}
