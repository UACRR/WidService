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
        public GridTestForm()
        {
            InitializeComponent();
            radGridView1.GridViewElement.PagingPanelElement.ShowNumericalButtons = false;
            radGridView1.GridViewElement.PagingPanelElement.ShowFastForwardButton = false;
            radGridView1.GridViewElement.PagingPanelElement.ShowFastBackButton = false;
            radGridView1.EnablePaging = true;
            radGridView1.PageSize = 30;
            //radGridView1.MasterTemplate.TotalPages = 2000;

            radGridView1.GridViewElement.PagingPanelElement.NextButton.Click += NextButton_Click;
            radGridView1.GridViewElement.PagingPanelElement.PreviousButton.Click += PreviousButton_Click;
            radGridView1.SetTotalPages(128);
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            var number = Int32.Parse(radGridView1.GridViewElement.PagingPanelElement.PageNumberTextBox.Text) - 1;
            Method(null, number);

            //radGridView1.GridViewElement.PagingPanelElement.PageNumberTextBox.Text = number.ToString();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            var number = Int32.Parse(radGridView1.GridViewElement.PagingPanelElement.PageNumberTextBox.Text) + 1;
            Method(null, number);

            //radGridView1.GridViewElement.PagingPanelElement.PageNumberTextBox.Text = number.ToString();
        }

        private void Method(uint? countRow, int? page = null)
        {   
            ObservableListSource<Test> source = new ObservableListSource<Test>();

            if (countRow != null)
            {
                while (countRow != 0)
                {
                    source.Add(new Test
                    {
                        Col1 = countRow.ToString(),
                        Col2 = Convert.ToString((int)countRow, 8).ToUpper(),
                        Col3 = Convert.ToString((int)countRow, 16).ToUpper()
                    });

                    countRow--;
                }
            }
            else if (page != null)
            {
                byte i = 0;

                while (true)
                {
                    source.Add(new Test
                    {
                        Col1 = "Page:" + page + "DEC: " +(int)i + 8*page,
                        Col2 = Convert.ToString(i + 8*(int)page, 8).ToUpper(),
                        Col3 = Convert.ToString(i + 8*(int)page, 16).ToUpper()
                    });

                    if (++i == 30) break;
                }
            }
            else
            {
                int row = 0;
                while (row <= 512)
                {
                    source.Add(new Test());
                    row++;
                }
            }

            radGridView1.DataSource = source;
        }

        private void radGridView1_PageChanging(object sender, PageChangingEventArgs e)
        {
            var indx = e.NewPageIndex;
            var item = radGridView1.GridViewElement.PagingPanelElement;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Method(1024);
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            Method(null);
            radGridView1.GridViewElement.PagingPanelElement.NumberOfPagesLabel.Text = "200";

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


            radGridView1.DataSource = source;
//            radGridView1.GridViewElement.
            radGridView1.GridViewElement.PagingPanelElement.NumberOfPagesLabel.Text = "200";
            radGridView1.GridViewElement.PagingPanelElement.PageNumberTextBox.Text = "13";
        }
    }

    public class Test
    {
        public string Col1 { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }
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

