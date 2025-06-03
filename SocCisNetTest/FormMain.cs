using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocCisNetLib;

namespace SocCisNetTest
{
    public partial class FormMain : Form
    {

        private const string _fileFullName = @"D:\OlegM\Sources\WidService\SocCisNetLib\CisNetPackages\WRK_59431174_140_WINDOWS.xml";
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var importer = new WorkImporter();
            importer.ImportWorks(_fileFullName);
        }
    }
}
