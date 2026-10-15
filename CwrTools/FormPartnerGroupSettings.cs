using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CwrTools
{
    public partial class FormPartnerGroupSettings : Form
    {
        private bool _ignoreItemCheckEvent = false;
        private int _groupId;
        public FormPartnerGroupSettings(int groupId)
        {
            _groupId = groupId;
            InitializeComponent();
        }

        private void FormPartnerGroupSettings_Load(object sender, EventArgs e)
        {
            _ignoreItemCheckEvent = true;
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = "select Name, IsV21, IsV22, AddNativeNames from PartnerGroups where Id = @groupId";
                cmd.Parameters.AddWithValue("@groupId", _groupId);
                using(var r = cmd.ExecuteReader())
                {
                    r.Read();
                    Text = $"Налаштування групи {r.GetString(0)}";
                    lbSettings.Items.Add("Формат файлу V21", r.GetBoolean(1));
                    lbSettings.Items.Add("Формат файлу V22", r.GetBoolean(2));
                    lbSettings.Items.Add("Включати оригінальні назви", r.GetBoolean(3));
                }
            });
            _ignoreItemCheckEvent = false;
        }

        private void lbSettings_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(_ignoreItemCheckEvent)
                return;

            _ignoreItemCheckEvent = true;
            if (e.NewValue == CheckState.Checked)
            {
                if(e.Index == 1)
                    lbSettings.SetItemChecked(0, false);
                else if(e.Index == 0)
                    lbSettings.SetItemChecked(1, false);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                if(e.Index == 1)
                    lbSettings.SetItemChecked(0, true);
                else if(e.Index == 0)
                    lbSettings.SetItemChecked(1, true);
            }
            _ignoreItemCheckEvent = false;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"update PartnerGroups set
                      IsV21 = @isV21
                    , IsV22 = @isV22
                    , AddNativeNames = @addNativeNames
                    where Id = @groupId
                ";
                cmd.Parameters.AddWithValue("@groupId", _groupId);
                cmd.Parameters.AddWithValue("@isV21", lbSettings.GetItemChecked(0));
                cmd.Parameters.AddWithValue("@isV22", lbSettings.GetItemChecked(1));
                cmd.Parameters.AddWithValue("@addNativeNames", lbSettings.GetItemChecked(2));
                cmd.ExecuteNonQuery();
            });

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
