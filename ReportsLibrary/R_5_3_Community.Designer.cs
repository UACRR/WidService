namespace ReportsLibrary
{
    partial class R_5_3_Community
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup3 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup4 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup5 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector1 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector2 = new Telerik.Reporting.Drawing.DescendantSelector();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.sqlDataSource2 = new Telerik.Reporting.SqlDataSource();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.detailSection1 = new Telerik.Reporting.DetailSection();
            this.table1 = new Telerik.Reporting.Table();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.329547882080078D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox1.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox1.StyleName = "Normal.TableHeader";
            this.textBox1.Value = "¬Ë‰Ë Ô‡‚";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.9914131164550781D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox2.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.textBox2.StyleName = "Normal.TableHeader";
            this.textBox2.Value = "¿‚ÚÓË / œ‡‚Ó‚Î‡ÒÌËÍË";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.9687099456787109D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox3.StyleName = "Normal.TableHeader";
            this.textBox3.Value = "«≥·‡ÌÓ";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.7415828704833984D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox4.StyleName = "Normal.TableHeader";
            this.textBox4.Value = " ÓÏ≥Ò≥ˇ ”¿¿—œ";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "ReportsLibrary.Properties.Settings.MediaService";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@dateBegin", System.Data.DbType.Date, "= Parameters.dateBegin.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@dateEnd", System.Data.DbType.Date, "= Parameters.dateEnd.Value")});
            this.sqlDataSource1.SelectCommand = "dbo.pTsk_5_3_Community";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // sqlDataSource2
            // 
            this.sqlDataSource2.ConnectionString = "ReportsLibrary.Properties.Settings.MediaService";
            this.sqlDataSource2.Name = "sqlDataSource2";
            this.sqlDataSource2.SelectCommand = "select pId,convert(int,valuePar) valuePar,valueName\r\nfrom ParametersListBox\r\nwher" +
    "e repId=52\r\n";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.4999001026153565D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox5});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.8999996185302734D), Telerik.Reporting.Drawing.Unit.Cm(1.4999001026153565D));
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "≤Õÿ≤ œ–¿¬Œ¬À¿—Õ» »  ‰Óı≥‰Ì≥ÒÚ¸";
            // 
            // detailSection1
            // 
            this.detailSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(5D);
            this.detailSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.table1});
            this.detailSection1.Name = "detailSection1";
            // 
            // table1
            // 
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(18.329545974731445D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(4.9914131164550781D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(3.96870756149292D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(3.7415814399719238D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.5D)));
            this.table1.Body.SetCellContent(0, 0, this.textBox8);
            this.table1.Body.SetCellContent(0, 1, this.textBox9);
            this.table1.Body.SetCellContent(0, 2, this.textBox10);
            this.table1.Body.SetCellContent(0, 3, this.textBox11);
            tableGroup1.Name = "countRh";
            tableGroup1.ReportItem = this.textBox1;
            tableGroup2.Name = "cRKindCode";
            tableGroup2.ReportItem = this.textBox2;
            tableGroup3.Name = "cRKindName";
            tableGroup3.ReportItem = this.textBox3;
            tableGroup4.Name = "sComm";
            tableGroup4.ReportItem = this.textBox4;
            this.table1.ColumnGroups.Add(tableGroup1);
            this.table1.ColumnGroups.Add(tableGroup2);
            this.table1.ColumnGroups.Add(tableGroup3);
            this.table1.ColumnGroups.Add(tableGroup4);
            this.table1.DataSource = this.sqlDataSource1;
            this.table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4});
            this.table1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.table1.Name = "table1";
            tableGroup5.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup5.Name = "detail";
            this.table1.RowGroups.Add(tableGroup5);
            this.table1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(31.031248092651367D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.table1.StyleName = "Normal.TableNormal";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.329547882080078D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox8.Style.Font.Bold = false;
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox8.StyleName = "Normal.TableBody";
            this.textBox8.Value = "= Fields.nameCommunity";
            // 
            // textBox9
            // 
            this.textBox9.Format = "{0:N0}";
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.9914131164550781D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox9.Style.Font.Bold = false;
            this.textBox9.StyleName = "Normal.TableBody";
            this.textBox9.Value = "= Fields.countRh";
            // 
            // textBox10
            // 
            this.textBox10.Format = "{0:N2}";
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.9687099456787109D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox10.Style.Font.Bold = false;
            this.textBox10.StyleName = "Normal.TableBody";
            this.textBox10.Value = "= Fields.amountPaid";
            // 
            // textBox11
            // 
            this.textBox11.Format = "{0:N2}";
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.7415828704833984D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox11.Style.Font.Bold = false;
            this.textBox11.StyleName = "Normal.TableBody";
            this.textBox11.Value = "= Fields.amountCommiss";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(2D);
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // R_5_3_Community
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detailSection1,
            this.pageFooterSection1});
            this.Name = "R_5_2_CrKind";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Cm(2D), Telerik.Reporting.Drawing.Unit.Cm(2D), Telerik.Reporting.Drawing.Unit.Cm(2D), Telerik.Reporting.Drawing.Unit.Cm(2D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AutoRefresh = true;
            reportParameter1.Name = "dateBegin";
            reportParameter1.Text = "                               Á";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter1.Value = "= Date(2018,1,1)";
            reportParameter1.Visible = true;
            reportParameter2.AutoRefresh = true;
            reportParameter2.Name = "dateEnd";
            reportParameter2.Text = "ÔÓ";
            reportParameter2.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter2.Value = "= Today()";
            reportParameter2.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.Style.Font.Bold = true;
            this.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.Table), "Normal.TableNormal")});
            styleRule3.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule3.Style.Color = System.Drawing.Color.Black;
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            descendantSelector1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Table)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "Normal.TableBody")});
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector1});
            styleRule4.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            descendantSelector2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Table)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "Normal.TableHeader")});
            styleRule5.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector2});
            styleRule5.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule5.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule5.Style.Font.Name = "Tahoma";
            styleRule5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4,
            styleRule5});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(31.100000381469727D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.SqlDataSource sqlDataSource2;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.DetailSection detailSection1;
        private Telerik.Reporting.Table table1;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
    }
}