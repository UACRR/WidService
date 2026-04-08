using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WidSubmit.UcSubmWorkCheckList;

namespace WidSubmit
{
    public partial class UcSubmWorkRespErr_Mockup : UserControl
    {
        public UcSubmWorkRespErr_Mockup()
        {
            InitializeComponent();
        }

        private void UcSubmWorkRespErr_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            panelMain = new TableLayoutPanel();

            panelScrollContainer = new Panel();
            panelScrollContainer.Dock = DockStyle.Fill;
            panelScrollContainer.AutoScroll = true;
        }
        
        public void ClearContent()
        {
        }

        public void UpdateContent(int submWorkId)
        {
        }
    }
}
