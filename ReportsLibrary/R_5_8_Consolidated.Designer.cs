namespace ReportsLibrary
{
    partial class R_5_8_Consolidated
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
            Telerik.Reporting.TableGroup tableGroup7 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup8 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup9 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup10 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup11 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup12 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup13 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.NavigateToReportAction navigateToReportAction1 = new Telerik.Reporting.NavigateToReportAction();
            Telerik.Reporting.TypeReportSource typeReportSource1 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector1 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector2 = new Telerik.Reporting.Drawing.DescendantSelector();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.detailSection1 = new Telerik.Reporting.DetailSection();
            this.table1 = new Telerik.Reporting.Table();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.textBox22 = new Telerik.Reporting.TextBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.textBox25 = new Telerik.Reporting.TextBox();
            this.textBox26 = new Telerik.Reporting.TextBox();
            this.textBox27 = new Telerik.Reporting.TextBox();
            this.textBox28 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.ReportNameTextBox = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.groupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.groupFooterSection = new Telerik.Reporting.GroupFooterSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "ReportsLibrary.Properties.Settings.MediaService";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@beginDate", System.Data.DbType.DateTime, "= Parameters.beginDate.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@endDate", System.Data.DbType.DateTime, "= Parameters.endDate.Value")});
            this.sqlDataSource1.SelectCommand = "pTsk_5_8_Consolidated";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // detailSection1
            // 
            this.detailSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(4.2999997138977051D);
            this.detailSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.table1});
            this.detailSection1.Name = "detailSection1";
            // 
            // table1
            // 
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(6.7624979019165039D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(6.6831207275390625D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(4.8574976921081543D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(4.8045797348022461D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(5.2279138565063477D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.68520838022232056D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.658750057220459D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.50000005960464478D)));
            this.table1.Body.SetCellContent(2, 0, this.textBox10);
            this.table1.Body.SetCellContent(2, 1, this.textBox11);
            this.table1.Body.SetCellContent(2, 2, this.textBox12);
            this.table1.Body.SetCellContent(2, 3, this.textBox13);
            this.table1.Body.SetCellContent(2, 4, this.textBox14);
            this.table1.Body.SetCellContent(1, 0, this.textBox19);
            this.table1.Body.SetCellContent(1, 1, this.textBox20);
            this.table1.Body.SetCellContent(1, 2, this.textBox21);
            this.table1.Body.SetCellContent(1, 3, this.textBox22);
            this.table1.Body.SetCellContent(1, 4, this.textBox23);
            this.table1.Body.SetCellContent(0, 0, this.textBox24);
            this.table1.Body.SetCellContent(0, 1, this.textBox25);
            this.table1.Body.SetCellContent(0, 2, this.textBox26);
            this.table1.Body.SetCellContent(0, 3, this.textBox27);
            this.table1.Body.SetCellContent(0, 4, this.textBox28);
            tableGroup1.Name = "categoryName";
            tableGroup1.ReportItem = this.textBox3;
            tableGroup2.Name = "cmFlagName";
            tableGroup2.ReportItem = this.textBox4;
            tableGroup3.Name = "sCollectm";
            tableGroup3.ReportItem = this.textBox5;
            tableGroup4.Name = "sCommiss";
            tableGroup4.ReportItem = this.textBox6;
            tableGroup5.Name = "sDistrib";
            tableGroup5.ReportItem = this.textBox7;
            this.table1.ColumnGroups.Add(tableGroup1);
            this.table1.ColumnGroups.Add(tableGroup2);
            this.table1.ColumnGroups.Add(tableGroup3);
            this.table1.ColumnGroups.Add(tableGroup4);
            this.table1.ColumnGroups.Add(tableGroup5);
            this.table1.DataSource = this.sqlDataSource1;
            this.table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox24,
            this.textBox25,
            this.textBox26,
            this.textBox27,
            this.textBox28,
            this.textBox19,
            this.textBox20,
            this.textBox21,
            this.textBox22,
            this.textBox23,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7});
            this.table1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.1838703155517578D), Telerik.Reporting.Drawing.Unit.Cm(0.19999949634075165D));
            this.table1.Name = "table1";
            tableGroup8.Name = "group6";
            tableGroup7.ChildGroups.Add(tableGroup8);
            tableGroup7.Name = "group5";
            tableGroup6.ChildGroups.Add(tableGroup7);
            tableGroup6.Name = "group4";
            tableGroup11.Name = "group3";
            tableGroup10.ChildGroups.Add(tableGroup11);
            tableGroup10.Name = "group2";
            tableGroup13.Name = "group";
            tableGroup12.ChildGroups.Add(tableGroup13);
            tableGroup12.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup12.Name = "detail";
            tableGroup12.Sortings.Add(new Telerik.Reporting.Sorting("= Fields.categoryCode", Telerik.Reporting.SortDirection.Asc));
            tableGroup12.Sortings.Add(new Telerik.Reporting.Sorting("= Fields.cmFlag", Telerik.Reporting.SortDirection.Asc));
            tableGroup9.ChildGroups.Add(tableGroup10);
            tableGroup9.ChildGroups.Add(tableGroup12);
            tableGroup9.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.categoryCode"));
            tableGroup9.Name = "categoryCode1";
            tableGroup9.Sortings.Add(new Telerik.Reporting.Sorting("= Fields.categoryCode", Telerik.Reporting.SortDirection.Asc));
            tableGroup9.Sortings.Add(new Telerik.Reporting.Sorting("= Fields.cmFlag", Telerik.Reporting.SortDirection.Asc));
            this.table1.RowGroups.Add(tableGroup6);
            this.table1.RowGroups.Add(tableGroup9);
            this.table1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(28.335609436035156D), Telerik.Reporting.Drawing.Unit.Cm(2.7408335208892822D));
            this.table1.StyleName = "Normal.TableNormal";
            // 
            // textBox10
            // 
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("beginDate", "= Parameters.beginDate.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("endDate", "= Parameters.endDate.Value"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("cmFlag", "= Fields.cmFlag"));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("categoryCode", "= Fields.categoryCode"));
            typeReportSource1.TypeName = "ReportsLibrary.R_5_8_DistribMain, ReportsLibrary, Version=1.0.0.0, Culture=neutra" +
    "l, PublicKeyToken=null";
            navigateToReportAction1.ReportSource = typeReportSource1;
            this.textBox10.Action = navigateToReportAction1;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.7624979019165039D), Telerik.Reporting.Drawing.Unit.Cm(0.50000011920928955D));
            this.textBox10.StyleName = "Normal.TableBody";
            this.textBox10.Value = " ";
            // 
            // textBox11
            // 
            this.textBox11.Action = navigateToReportAction1;
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.6831221580505371D), Telerik.Reporting.Drawing.Unit.Cm(0.50000005960464478D));
            this.textBox11.StyleName = "Normal.TableBody";
            this.textBox11.Value = "= Fields.cmFlagName";
            // 
            // textBox12
            // 
            this.textBox12.Action = navigateToReportAction1;
            this.textBox12.Format = "{0:N2}";
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.8574981689453125D), Telerik.Reporting.Drawing.Unit.Cm(0.50000005960464478D));
            this.textBox12.StyleName = "Normal.TableBody";
            this.textBox12.Value = "= Fields.sCollectm";
            // 
            // textBox13
            // 
            this.textBox13.Action = navigateToReportAction1;
            this.textBox13.Format = "{0:N2}";
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.80457878112793D), Telerik.Reporting.Drawing.Unit.Cm(0.50000005960464478D));
            this.textBox13.StyleName = "Normal.TableBody";
            this.textBox13.Value = "= Fields.sCommiss";
            // 
            // textBox14
            // 
            this.textBox14.Action = navigateToReportAction1;
            this.textBox14.Format = "{0:N2}";
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.2279138565063477D), Telerik.Reporting.Drawing.Unit.Cm(0.50000005960464478D));
            this.textBox14.StyleName = "Normal.TableBody";
            this.textBox14.Value = "= Fields.sDistrib";
            // 
            // textBox19
            // 
            this.textBox19.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.7624969482421875D), Telerik.Reporting.Drawing.Unit.Cm(0.658750057220459D));
            this.textBox19.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox19.Style.Font.Bold = true;
            this.textBox19.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox19.StyleName = "Normal.TableBody";
            this.textBox19.Value = "= Fields.categoryName";
            // 
            // textBox20
            // 
            this.textBox20.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.6831221580505371D), Telerik.Reporting.Drawing.Unit.Cm(0.658750057220459D));
            this.textBox20.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox20.Style.Font.Bold = true;
            this.textBox20.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox20.StyleName = "Normal.TableBody";
            // 
            // textBox21
            // 
            this.textBox21.Format = "{0:N2}";
            this.textBox21.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.8574981689453125D), Telerik.Reporting.Drawing.Unit.Cm(0.658750057220459D));
            this.textBox21.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox21.Style.Font.Bold = true;
            this.textBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox21.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox21.StyleName = "Normal.TableBody";
            this.textBox21.Value = "= Sum(Fields.sCollectm)";
            // 
            // textBox22
            // 
            this.textBox22.Format = "{0:N2}";
            this.textBox22.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.80457878112793D), Telerik.Reporting.Drawing.Unit.Cm(0.658750057220459D));
            this.textBox22.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox22.Style.Font.Bold = true;
            this.textBox22.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox22.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox22.StyleName = "Normal.TableBody";
            this.textBox22.Value = "= Sum(Fields.sCommiss)";
            // 
            // textBox23
            // 
            this.textBox23.Format = "{0:N2}";
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.2279138565063477D), Telerik.Reporting.Drawing.Unit.Cm(0.658750057220459D));
            this.textBox23.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox23.Style.Font.Bold = true;
            this.textBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox23.StyleName = "Normal.TableBody";
            this.textBox23.Value = "= Sum(Fields.sDistrib)";
            // 
            // textBox24
            // 
            this.textBox24.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.76249885559082D), Telerik.Reporting.Drawing.Unit.Cm(0.68520838022232056D));
            this.textBox24.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox24.Style.Font.Bold = true;
            this.textBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox24.StyleName = "Normal.TableBody";
            this.textBox24.Value = "Всього";
            // 
            // textBox25
            // 
            this.textBox25.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.6831226348876953D), Telerik.Reporting.Drawing.Unit.Cm(0.68520838022232056D));
            this.textBox25.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox25.Style.Font.Bold = true;
            this.textBox25.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox25.StyleName = "Normal.TableBody";
            // 
            // textBox26
            // 
            this.textBox26.Format = "{0:N2}";
            this.textBox26.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.8574981689453125D), Telerik.Reporting.Drawing.Unit.Cm(0.68520838022232056D));
            this.textBox26.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox26.Style.Font.Bold = true;
            this.textBox26.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox26.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox26.StyleName = "Normal.TableBody";
            this.textBox26.Value = "= Sum(Fields.sCollectm)";
            // 
            // textBox27
            // 
            this.textBox27.Format = "{0:N2}";
            this.textBox27.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.80457878112793D), Telerik.Reporting.Drawing.Unit.Cm(0.68520838022232056D));
            this.textBox27.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox27.Style.Font.Bold = true;
            this.textBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox27.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox27.StyleName = "Normal.TableBody";
            this.textBox27.Value = "= Sum(Fields.sCommiss)";
            // 
            // textBox28
            // 
            this.textBox28.Format = "{0:N2}";
            this.textBox28.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.2279138565063477D), Telerik.Reporting.Drawing.Unit.Cm(0.68520838022232056D));
            this.textBox28.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox28.Style.Font.Bold = true;
            this.textBox28.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox28.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox28.StyleName = "Normal.TableBody";
            this.textBox28.Value = "= Sum(Fields.sDistrib)";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.7624979019165039D), Telerik.Reporting.Drawing.Unit.Cm(0.89687508344650269D));
            this.textBox3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.StyleName = "Normal.TableHeader";
            this.textBox3.Value = "Права";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.6831221580505371D), Telerik.Reporting.Drawing.Unit.Cm(0.89687520265579224D));
            this.textBox4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox4.StyleName = "Normal.TableHeader";
            this.textBox4.Value = "Співтовариство";
            // 
            // textBox5
            // 
            this.textBox5.Format = "{0:N2}";
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.8574981689453125D), Telerik.Reporting.Drawing.Unit.Cm(0.89687502384185791D));
            this.textBox5.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox5.StyleName = "Normal.TableHeader";
            this.textBox5.Value = "Сума збору";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.80457878112793D), Telerik.Reporting.Drawing.Unit.Cm(0.89687502384185791D));
            this.textBox6.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox6.Style.Font.Bold = true;
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox6.StyleName = "Normal.TableHeader";
            this.textBox6.Value = "Комісія УААСП";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.2279138565063477D), Telerik.Reporting.Drawing.Unit.Cm(0.89687502384185791D));
            this.textBox7.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox7.Style.Font.Bold = true;
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.StyleName = "Normal.TableHeader";
            this.textBox7.Value = "До перер.";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.70000028610229492D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.ReportNameTextBox});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // ReportNameTextBox
            // 
            this.ReportNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.1838703155517578D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.ReportNameTextBox.Name = "ReportNameTextBox";
            this.ReportNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15D), Telerik.Reporting.Drawing.Unit.Cm(0.70000022649765015D));
            this.ReportNameTextBox.Style.Font.Bold = true;
            this.ReportNameTextBox.Style.Font.Name = "Segoe UI";
            this.ReportNameTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.ReportNameTextBox.Value = "Перерозподіл роялті";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(2.5D);
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // groupHeaderSection
            // 
            this.groupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(1.8999998569488525D);
            this.groupHeaderSection.Name = "groupHeaderSection";
            // 
            // groupFooterSection
            // 
            this.groupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(2.5D);
            this.groupFooterSection.Name = "groupFooterSection";
            // 
            // R_5_8_Consolidated
            // 
            group1.GroupFooter = this.groupFooterSection;
            group1.GroupHeader = this.groupHeaderSection;
            group1.Name = "group1";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection,
            this.groupFooterSection,
            this.detailSection1,
            this.pageHeaderSection1,
            this.pageFooterSection1});
            this.Name = "R_5_8_Consolidated";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Cm(2D), Telerik.Reporting.Drawing.Unit.Cm(2D), Telerik.Reporting.Drawing.Unit.Cm(2D), Telerik.Reporting.Drawing.Unit.Cm(2D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AutoRefresh = true;
            reportParameter1.Name = "beginDate";
            reportParameter1.Text = "            з";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter1.Value = "= Date(2018,1,1)";
            reportParameter1.Visible = true;
            reportParameter2.AutoRefresh = true;
            reportParameter2.Name = "endDate";
            reportParameter2.Text = "по";
            reportParameter2.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter2.Value = "=Today()";
            reportParameter2.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
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
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(29.51957893371582D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.DetailSection detailSection1;
        private Telerik.Reporting.Table table1;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox21;
        private Telerik.Reporting.TextBox textBox22;
        private Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.TextBox textBox24;
        private Telerik.Reporting.TextBox textBox25;
        private Telerik.Reporting.TextBox textBox26;
        private Telerik.Reporting.TextBox textBox27;
        private Telerik.Reporting.TextBox textBox28;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.TextBox ReportNameTextBox;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection;
        private Telerik.Reporting.GroupFooterSection groupFooterSection;
    }
}