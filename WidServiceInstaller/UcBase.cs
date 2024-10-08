using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidServiceInstaller
{
    public partial class UcBase : UserControl
    {
        public DeploymentConfig deploymentConfig { get; set; }

        protected IEnumerable<PropertyInfo> propDscs;

        public UcBase()
        {
            InitializeComponent();
        }

        private void UcBase_Load(object sender, EventArgs e)
        {
            if(deploymentConfig == null) // For Design Mode
            {
                return;
            }
            var ucType = this.GetType();

            var cfgType = deploymentConfig.GetType();
            propDscs = cfgType.GetProperties().Where(x => {
                var attributes = x.GetCustomAttributes(false).ToDictionary(a => a.GetType().Name, a => a);
                var category = ((CategoryAttribute)attributes["CategoryAttribute"]).Category;
                return category == ucType.Name;
             });

            panelMain.ColumnCount = 2;
            panelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 78F));
            panelMain.RowCount = propDscs.Count() * 2;

            int rowIndex = 0;
            panelMain.RowStyles.Clear();
            propDscs.ToList().ForEach(x =>
            {
                var attributes = x.GetCustomAttributes(false).ToDictionary(a => a.GetType().Name, a => a);
                var displayName = ((DisplayNameAttribute)attributes["DisplayNameAttribute"]).DisplayName;
                var category = ((CategoryAttribute)attributes["CategoryAttribute"]).Category;

                panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
                panelMain.Controls.Add(new Label { Text = displayName, Dock = DockStyle.Fill }, 0, rowIndex);
                rowIndex++;

                var value = (string)x.GetValue(deploymentConfig);
                var tb = new TextBox { Text = value, Dock = DockStyle.Fill };
                if(x.Name == "WindowsServiceAccount")
                {
                    tb.ReadOnly = true;
                }
                panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
                panelMain.Controls.Add(tb, 0, rowIndex);
                rowIndex++;
            });

            panelMain.Size = new Size(775, 549);
            panelMain.TabIndex = 1;
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";


        }

        protected bool SaveChanges()
        {
            int rowIndex = 0;
            propDscs.ToList().ForEach(x =>
            {
                rowIndex++;

                var ctrl = (TextBox)panelMain.GetControlFromPosition(0, rowIndex);
                x.SetValue(deploymentConfig, ctrl.Text);
                rowIndex++;
            });

            return ValidateChanges();
        }

        protected virtual bool ValidateChanges()
        {
            return false;
        }
        public virtual bool OnNext()
        {
            return SaveChanges();
        }
    }
}
