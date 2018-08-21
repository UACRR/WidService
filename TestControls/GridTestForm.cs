using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary;
using IpsViewComponentLibrary.ConsumerDialogForms;
using Telerik.Charting;
using Telerik.Charting.Styles;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace TestControls
{
    public partial class GridTestForm : RadForm
    {
        private ObservableListSource<Test> source = null;
        private string[] _columnNames = {"DEC", "OCT", "HEX"};
        public GridTestForm()
        {
            InitializeComponent();

            vgvMain.PageSize = 30;
            vgvMain.EnablePaging = true;
            vgvMain.TableElement.PagingPanelElement.ShowNumericalButtons = false;
            vgvMain.TableElement.PagingPanelElement.ShowFastBackButton = false;
            vgvMain.TableElement.PagingPanelElement.ShowFastForwardButton = false;
            vgvMain.RowCount = 1024;
            vgvMain.CellValueNeeded += VgvMain_CellValueNeeded;
            vgvMain.PageChanging += VgvMain_PageChanging;
            vgvMain.TableElement.ColumnsViewState.SetItemSize(0,200);
            Method(0);
            vgvMain.Refresh();
        }

        private void VgvMain_PageChanging(object sender, VirtualGridPageChangingEventArgs e)
        {
            Method(e.NewIndex);
            vgvMain.Refresh();
        }

        private void VgvMain_CellValueNeeded(object sender, VirtualGridCellValueNeededEventArgs e)
        {
            if (e.ColumnIndex < 0 || source == null)
                return;

            if (e.RowIndex == RadVirtualGrid.HeaderRowIndex)
            {
                e.Value = _columnNames[e.ColumnIndex];
            }
            if (e.RowIndex >= 0 && e.RowIndex < source.Count + e.ViewInfo.PageIndex * 30)
            {
                e.Value = source[e.RowIndex - e.ViewInfo.PageIndex * 30][e.ColumnIndex];
            }
        }

        private void Method(int? inxPage = null)
        {
            source = new ObservableListSource<Test>();
            if (inxPage != null)
            {
                byte i = 0;

                while (true)
                {
                    source.Add(new Test
                    {
                        Col1 = "Page: " + inxPage + 1 + ", DEC: " + (int) i + 8 * inxPage,
                        Col2 = Convert.ToString(i + 8 * (int)inxPage, 8).ToUpper(),
                        Col3 = Convert.ToString(i + 8 * (int)inxPage, 16).ToUpper()
                    });

                    if (++i == 30) break;
                }
            }
        }

        private void radGridView1_PageChanging(object sender, PageChangingEventArgs e)
        {
            var indx = e.NewPageIndex;
            //var item = radGridView1.GridViewElement.PagingPanelElement;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Method(1024);
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            Method(null);

        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            ObservableListSource<Test> source = new ObservableListSource<Test>();
            byte i = 0;

            while (true)
            {
                source.Add(new Test
                {
                    Col1 = (int)i+128.ToString(),
                    Col2 = Convert.ToString((int)i+128, 8).ToUpper(),
                    Col3 = Convert.ToString((int)i+128, 16).ToUpper()
                });
            
                if(++i == 30) break;
            }


            // = source;
//            radGridView1.GridViewElement.
            //radGridView1.GridViewElement.PagingPanelElement.NumberOfPagesLabel.Text = "200";
            //radGridView1.GridViewElement.PagingPanelElement.PageNumberTextBox.Text = "13";
        }

        private void Met(string item, bool bb)
        {

        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }

    public class Test
    {
        public static string name = "Test";
        public string type = "Class";
        public string Col1 { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }

        public string this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return Col1;
                    case 1:
                        return Col2;
                    case 2:
                        return Col3;
                    default:
                        return string.Empty;
                }
            }
        }
    }

    public static class CustomGridView
    {
        public static void SetTotalPages(this RadGridView grid, int totalPages)
        {
            var type = grid.MasterTemplate.GetType();
            var property = type.GetProperties().SingleOrDefault(rec => rec.Name == "TotalPages");
            //var field = property?.GetConstantValue();

            var fields = type.GetRuntimeFields();

            //property?.SetValue(property, totalPages);

            //grid.MasterTemplate.TotalPages = totalPages;
        }
        
    }
}

