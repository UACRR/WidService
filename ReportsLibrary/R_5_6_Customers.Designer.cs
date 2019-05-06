namespace ReportsLibrary
{
    partial class R_5_6_Customers
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
            Telerik.Reporting.TableGroup tableGroup6 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.SortingAction sortingAction1 = new Telerik.Reporting.SortingAction();
            Telerik.Reporting.SortingAction sortingAction2 = new Telerik.Reporting.SortingAction();
            Telerik.Reporting.SortingAction sortingAction3 = new Telerik.Reporting.SortingAction();
            Telerik.Reporting.NavigateToReportAction navigateToReportAction1 = new Telerik.Reporting.NavigateToReportAction();
            Telerik.Reporting.TypeReportSource typeReportSource1 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector1 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector2 = new Telerik.Reporting.Drawing.DescendantSelector();
            this.table1 = new Telerik.Reporting.Table();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.detailSection1 = new Telerik.Reporting.DetailSection();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.ReportNameTextBox = new Telerik.Reporting.TextBox();
            this.textBox28 = new Telerik.Reporting.TextBox();
            this.textBox29 = new Telerik.Reporting.TextBox();
            this.textBox30 = new Telerik.Reporting.TextBox();
            this.textBox31 = new Telerik.Reporting.TextBox();
            this.textBox32 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // table1
            // 
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(7.371D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.926D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.159D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(2.926D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.5D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.738D)));
            this.table1.Body.SetCellContent(1, 0, this.textBox5);
            this.table1.Body.SetCellContent(1, 1, this.textBox6);
            this.table1.Body.SetCellContent(1, 2, this.textBox7);
            this.table1.Body.SetCellContent(1, 3, this.textBox8);
            this.table1.Body.SetCellContent(0, 3, this.textBox12);
            this.table1.Body.SetCellContent(0, 2, this.textBox11);
            this.table1.Body.SetCellContent(0, 0, this.textBox9, 1, 2);
            tableGroup1.Name = "custName";
            tableGroup1.ReportItem = this.textBox1;
            tableGroup2.Name = "iNNOKPO";
            tableGroup2.ReportItem = this.textBox2;
            tableGroup3.Name = "cntDog";
            tableGroup3.ReportItem = this.textBox3;
            tableGroup4.Name = "amount";
            tableGroup4.ReportItem = this.textBox4;
            this.table1.ColumnGroups.Add(tableGroup1);
            this.table1.ColumnGroups.Add(tableGroup2);
            this.table1.ColumnGroups.Add(tableGroup3);
            this.table1.ColumnGroups.Add(tableGroup4);
            this.table1.DataSource = this.sqlDataSource1;
            this.table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox9,
            this.textBox11,
            this.textBox12,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4});
            this.table1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.8D));
            this.table1.Name = "table1";
            tableGroup5.Name = "group";
            tableGroup6.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup6.Name = "detail";
            this.table1.RowGroups.Add(tableGroup5);
            this.table1.RowGroups.Add(tableGroup6);
            this.table1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.382D), Telerik.Reporting.Drawing.Unit.Cm(2.267D));
            this.table1.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.table1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(89)))));
            this.table1.StyleName = "Normal.TableNormal";
            // 
            // textBox5
            // 
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.371D), Telerik.Reporting.Drawing.Unit.Cm(0.738D));
            this.textBox5.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.textBox5.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox5.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.StyleName = "Normal.TableBody";
            this.textBox5.Value = "= Fields.custName";
            // 
            // textBox6
            // 
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.926D), Telerik.Reporting.Drawing.Unit.Cm(0.738D));
            this.textBox6.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.textBox6.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox6.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.StyleName = "Normal.TableBody";
            this.textBox6.Value = "= Fields.INNOKPO";
            // 
            // textBox7
            // 
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.159D), Telerik.Reporting.Drawing.Unit.Cm(0.738D));
            this.textBox7.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.textBox7.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox7.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.StyleName = "Normal.TableBody";
            this.textBox7.Value = "= Fields.cntDog";
            // 
            // textBox8
            // 
            this.textBox8.Format = "{0:N2}";
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.926D), Telerik.Reporting.Drawing.Unit.Cm(0.738D));
            this.textBox8.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.textBox8.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox8.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox8.StyleName = "Normal.TableBody";
            this.textBox8.Value = "= Fields.amount";
            // 
            // textBox12
            // 
            this.textBox12.Format = "{0:N2}";
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.926D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox12.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.textBox12.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox12.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.StyleName = "Normal.TableBody";
            this.textBox12.Value = "= Sum(Fields.amount)";
            // 
            // textBox11
            // 
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.159D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox11.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.textBox11.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox11.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox11.Style.Font.Bold = true;
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox11.StyleName = "Normal.TableBody";
            this.textBox11.Value = "= Sum(Fields.cntDog)";
            // 
            // textBox9
            // 
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(10.297D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox9.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.textBox9.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox9.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox9.Style.Font.Bold = true;
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.StyleName = "Normal.TableBody";
            this.textBox9.Value = "Всього:";
            // 
            // textBox1
            // 
            sortingAction1.SortingExpression = "= Fields.custName";
            sortingAction1.Targets.AddRange(new Telerik.Reporting.IActionTarget[] {
            this.table1});
            this.textBox1.Action = sortingAction1;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.371D), Telerik.Reporting.Drawing.Unit.Cm(1.029D));
            this.textBox1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.textBox1.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.textBox1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.StyleName = "Normal.TableHeader";
            this.textBox1.Value = "Користувач";
            // 
            // textBox2
            // 
            sortingAction2.SortingExpression = "= Fields.INNOKPO";
            sortingAction2.Targets.AddRange(new Telerik.Reporting.IActionTarget[] {
            this.table1});
            this.textBox2.Action = sortingAction2;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.926D), Telerik.Reporting.Drawing.Unit.Cm(1.029D));
            this.textBox2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.textBox2.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.textBox2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.StyleName = "Normal.TableHeader";
            this.textBox2.Value = "ЄДРПО";
            // 
            // textBox3
            // 
            this.textBox3.Action = null;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.159D), Telerik.Reporting.Drawing.Unit.Cm(1.029D));
            this.textBox3.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.textBox3.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.textBox3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.StyleName = "Normal.TableHeader";
            this.textBox3.Value = "Кількість договорів";
            // 
            // textBox4
            // 
            sortingAction3.SortingExpression = "= Fields.amount";
            sortingAction3.Targets.AddRange(new Telerik.Reporting.IActionTarget[] {
            this.table1});
            this.textBox4.Action = sortingAction3;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.926D), Telerik.Reporting.Drawing.Unit.Cm(1.029D));
            this.textBox4.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.textBox4.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.textBox4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox4.StyleName = "Normal.TableHeader";
            this.textBox4.Value = "Надійшло";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "ReportsLibrary.Properties.Settings.MediaService";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@beginDate", System.Data.DbType.Date, "= Parameters.dateBegin.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@endDate", System.Data.DbType.Date, "= Parameters.dateEnd.Value")});
            this.sqlDataSource1.SelectCommand = "dbo.pTsk_5_6_Customers";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // detailSection1
            // 
            this.detailSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(4.2D);
            this.detailSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.table1});
            this.detailSection1.KeepTogether = true;
            this.detailSection1.Name = "detailSection1";
            this.detailSection1.PageBreak = Telerik.Reporting.PageBreak.Before;
            this.detailSection1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(89)))));
            this.detailSection1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(1.5D);
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(2.1D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.ReportNameTextBox,
            this.textBox28,
            this.textBox29,
            this.textBox30,
            this.textBox31,
            this.textBox32});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            this.pageHeaderSection1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(89)))));
            this.pageHeaderSection1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(1.5D);
            // 
            // ReportNameTextBox
            // 
            this.ReportNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.114D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.ReportNameTextBox.Name = "ReportNameTextBox";
            this.ReportNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.1D), Telerik.Reporting.Drawing.Unit.Cm(0.738D));
            this.ReportNameTextBox.Style.Font.Bold = true;
            this.ReportNameTextBox.Style.Font.Name = "Segoe UI";
            this.ReportNameTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.ReportNameTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.ReportNameTextBox.Value = "8. Користувачі";
            // 
            // textBox28
            // 
            typeReportSource1.TypeName = "ReportsLibrary.ReportS, ReportsLibrary, Version=1.0.0.0, Culture=neutral, PublicK" +
    "eyToken=null";
            navigateToReportAction1.ReportSource = typeReportSource1;
            this.textBox28.Action = navigateToReportAction1;
            this.textBox28.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.7D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox28.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.textBox28.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.textBox28.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox28.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox28.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox28.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.textBox28.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox28.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.textBox28.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox28.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox28.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox28.Value = "Звіти. Головна.";
            // 
            // textBox29
            // 
            this.textBox29.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.214D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.8D), Telerik.Reporting.Drawing.Unit.Cm(0.738D));
            this.textBox29.Style.Font.Bold = true;
            this.textBox29.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox29.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox29.Value = "за період з ";
            // 
            // textBox30
            // 
            this.textBox30.Format = "{0:d}";
            this.textBox30.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.814D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.6D), Telerik.Reporting.Drawing.Unit.Cm(0.738D));
            this.textBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox30.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox30.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox30.Value = "= Parameters.dateBegin.Value";
            // 
            // textBox31
            // 
            this.textBox31.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.414D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(0.986D), Telerik.Reporting.Drawing.Unit.Cm(0.738D));
            this.textBox31.Style.Font.Bold = true;
            this.textBox31.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox31.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox31.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox31.Value = "по";
            // 
            // textBox32
            // 
            this.textBox32.Format = "{0:d}";
            this.textBox32.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.4D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.035D), Telerik.Reporting.Drawing.Unit.Cm(0.738D));
            this.textBox32.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox32.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox32.Value = "= Parameters.dateEnd.Value";
            // 
            // R_5_6_Customers
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detailSection1,
            this.pageHeaderSection1});
            this.Name = "R_5_6_Customers";
            this.PageNumberingStyle = Telerik.Reporting.PageNumberingStyle.ResetNumberingAndCount;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Cm(2D), Telerik.Reporting.Drawing.Unit.Cm(2D), Telerik.Reporting.Drawing.Unit.Cm(2D), Telerik.Reporting.Drawing.Unit.Cm(2D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AutoRefresh = true;
            reportParameter1.Name = "dateBegin";
            reportParameter1.Text = "             з";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter1.Value = "=Date(Today().Year,Today().Month,1)";
            reportParameter1.Visible = true;
            reportParameter2.AutoRefresh = true;
            reportParameter2.Name = "dateEnd";
            reportParameter2.Text = "по";
            reportParameter2.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter2.Value = "= Today()";
            reportParameter2.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(17D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.DetailSection detailSection1;
        private Telerik.Reporting.Table table1;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.TextBox ReportNameTextBox;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox28;
        private Telerik.Reporting.TextBox textBox29;
        private Telerik.Reporting.TextBox textBox30;
        private Telerik.Reporting.TextBox textBox31;
        private Telerik.Reporting.TextBox textBox32;
    }
}