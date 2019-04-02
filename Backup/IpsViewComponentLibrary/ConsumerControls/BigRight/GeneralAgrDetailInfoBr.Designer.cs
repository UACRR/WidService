namespace IpsViewComponentLibrary.ConsumerControls.BigRight
{
    partial class GeneralAgrDetailInfoBr
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.txtAgrNumber = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.txtAgrDate = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtPartnerName = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.txtActiveLicense = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.txtNoAcceptLicense = new Telerik.WinControls.UI.RadLabel();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.txtToProlongLicense = new Telerik.WinControls.UI.RadLabel();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.txtNoAcceptReference = new Telerik.WinControls.UI.RadLabel();
            this.radLabel13 = new Telerik.WinControls.UI.RadLabel();
            this.txtNoAcceptRequest = new Telerik.WinControls.UI.RadLabel();
            this.radLabel15 = new Telerik.WinControls.UI.RadLabel();
            this.txtActiveReqAndRef = new Telerik.WinControls.UI.RadLabel();
            this.radLabel17 = new Telerik.WinControls.UI.RadLabel();
            this.txtPrepayRest = new Telerik.WinControls.UI.RadLabel();
            this.radLabel19 = new Telerik.WinControls.UI.RadLabel();
            this.txtUnAttachAmount = new Telerik.WinControls.UI.RadLabel();
            this.radLabel21 = new Telerik.WinControls.UI.RadLabel();
            this.txtAttachAmount = new Telerik.WinControls.UI.RadLabel();
            this.radLabel23 = new Telerik.WinControls.UI.RadLabel();
            this.bsVbrLicense = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgrNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgrDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPartnerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtActiveLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoAcceptLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToProlongLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoAcceptReference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoAcceptRequest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActiveReqAndRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrepayRest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnAttachAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttachAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVbrLicense)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.txtToProlongLicense);
            this.radPanel1.Controls.Add(this.radLabel11);
            this.radPanel1.Controls.Add(this.txtNoAcceptLicense);
            this.radPanel1.Controls.Add(this.radLabel9);
            this.radPanel1.Controls.Add(this.txtActiveLicense);
            this.radPanel1.Controls.Add(this.radLabel6);
            this.radPanel1.Location = new System.Drawing.Point(3, 28);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(207, 78);
            this.radPanel1.TabIndex = 4;
            this.radPanel1.ThemeName = "Office2013Light";
            // 
            // txtAgrNumber
            // 
            this.txtAgrNumber.BorderVisible = true;
            this.txtAgrNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVbrLicense, "AgrNumber", true));
            this.txtAgrNumber.Location = new System.Drawing.Point(72, 3);
            this.txtAgrNumber.MinimumSize = new System.Drawing.Size(100, 18);
            this.txtAgrNumber.Name = "txtAgrNumber";
            // 
            // 
            // 
            this.txtAgrNumber.RootElement.MinSize = new System.Drawing.Size(100, 18);
            this.txtAgrNumber.Size = new System.Drawing.Size(100, 18);
            this.txtAgrNumber.TabIndex = 42;
            this.txtAgrNumber.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.txtAgrNumber.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtAgrNumber.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtAgrNumber.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtAgrNumber.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrNumber.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrNumber.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrNumber.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrNumber.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrNumber.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrNumber.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrNumber.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrNumber.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrNumber.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrNumber.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(21, 3);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(45, 19);
            this.radLabel7.TabIndex = 41;
            this.radLabel7.Text = "Номер";
            this.radLabel7.ThemeName = "Office2013Light";
            // 
            // txtAgrDate
            // 
            this.txtAgrDate.BorderVisible = true;
            this.txtAgrDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVbrLicense, "AgrDate", true));
            this.txtAgrDate.Location = new System.Drawing.Point(273, 4);
            this.txtAgrDate.MinimumSize = new System.Drawing.Size(70, 18);
            this.txtAgrDate.Name = "txtAgrDate";
            // 
            // 
            // 
            this.txtAgrDate.RootElement.MinSize = new System.Drawing.Size(70, 18);
            this.txtAgrDate.Size = new System.Drawing.Size(70, 18);
            this.txtAgrDate.TabIndex = 44;
            this.txtAgrDate.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.txtAgrDate.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtAgrDate.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtAgrDate.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtAgrDate.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrDate.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrDate.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrDate.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrDate.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrDate.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrDate.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrDate.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrDate.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrDate.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAgrDate.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(178, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(89, 19);
            this.radLabel2.TabIndex = 43;
            this.radLabel2.Text = "Дата договору";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // txtPartnerName
            // 
            this.txtPartnerName.BorderVisible = true;
            this.txtPartnerName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVbrLicense, "PartnerName", true));
            this.txtPartnerName.Location = new System.Drawing.Point(435, 4);
            this.txtPartnerName.MinimumSize = new System.Drawing.Size(250, 18);
            this.txtPartnerName.Name = "txtPartnerName";
            // 
            // 
            // 
            this.txtPartnerName.RootElement.MinSize = new System.Drawing.Size(250, 18);
            this.txtPartnerName.Size = new System.Drawing.Size(250, 18);
            this.txtPartnerName.TabIndex = 46;
            this.txtPartnerName.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.txtPartnerName.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtPartnerName.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtPartnerName.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtPartnerName.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPartnerName.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPartnerName.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPartnerName.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPartnerName.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPartnerName.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPartnerName.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPartnerName.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPartnerName.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPartnerName.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPartnerName.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(349, 3);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(80, 19);
            this.radLabel4.TabIndex = 45;
            this.radLabel4.Text = "Представник";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.txtNoAcceptReference);
            this.radPanel2.Controls.Add(this.radLabel13);
            this.radPanel2.Controls.Add(this.txtNoAcceptRequest);
            this.radPanel2.Controls.Add(this.radLabel15);
            this.radPanel2.Controls.Add(this.txtActiveReqAndRef);
            this.radPanel2.Controls.Add(this.radLabel17);
            this.radPanel2.Location = new System.Drawing.Point(216, 28);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(207, 78);
            this.radPanel2.TabIndex = 47;
            this.radPanel2.ThemeName = "Office2013Light";
            // 
            // radPanel3
            // 
            this.radPanel3.Controls.Add(this.txtPrepayRest);
            this.radPanel3.Controls.Add(this.radLabel19);
            this.radPanel3.Controls.Add(this.txtUnAttachAmount);
            this.radPanel3.Controls.Add(this.radLabel21);
            this.radPanel3.Controls.Add(this.txtAttachAmount);
            this.radPanel3.Controls.Add(this.radLabel23);
            this.radPanel3.Location = new System.Drawing.Point(429, 28);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(259, 78);
            this.radPanel3.TabIndex = 48;
            this.radPanel3.ThemeName = "Office2013Light";
            // 
            // txtActiveLicense
            // 
            this.txtActiveLicense.AutoSize = false;
            this.txtActiveLicense.BorderVisible = true;
            this.txtActiveLicense.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVbrLicense, "CountLic1Active", true));
            this.txtActiveLicense.Location = new System.Drawing.Point(162, 3);
            this.txtActiveLicense.Name = "txtActiveLicense";
            // 
            // 
            // 
            this.txtActiveLicense.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.txtActiveLicense.Size = new System.Drawing.Size(42, 18);
            this.txtActiveLicense.TabIndex = 44;
            this.txtActiveLicense.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.txtActiveLicense.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtActiveLicense.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtActiveLicense.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtActiveLicense.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveLicense.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveLicense.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveLicense.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveLicense.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveLicense.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveLicense.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveLicense.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveLicense.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveLicense.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveLicense.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(3, 3);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(109, 19);
            this.radLabel6.TabIndex = 43;
            this.radLabel6.Text = "Активних ліцензій";
            this.radLabel6.ThemeName = "Office2013Light";
            // 
            // txtNoAcceptLicense
            // 
            this.txtNoAcceptLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoAcceptLicense.AutoSize = false;
            this.txtNoAcceptLicense.BorderVisible = true;
            this.txtNoAcceptLicense.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVbrLicense, "CountLic1NoActive", true));
            this.txtNoAcceptLicense.Location = new System.Drawing.Point(162, 28);
            this.txtNoAcceptLicense.Name = "txtNoAcceptLicense";
            // 
            // 
            // 
            this.txtNoAcceptLicense.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.txtNoAcceptLicense.Size = new System.Drawing.Size(42, 18);
            this.txtNoAcceptLicense.TabIndex = 46;
            this.txtNoAcceptLicense.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.txtNoAcceptLicense.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtNoAcceptLicense.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtNoAcceptLicense.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtNoAcceptLicense.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptLicense.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptLicense.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptLicense.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptLicense.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptLicense.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptLicense.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptLicense.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptLicense.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptLicense.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptLicense.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // radLabel9
            // 
            this.radLabel9.Location = new System.Drawing.Point(3, 28);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(153, 19);
            this.radLabel9.TabIndex = 45;
            this.radLabel9.Text = "Ліцензій не акцептованих";
            this.radLabel9.ThemeName = "Office2013Light";
            // 
            // txtToProlongLicense
            // 
            this.txtToProlongLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToProlongLicense.AutoSize = false;
            this.txtToProlongLicense.BorderVisible = true;
            this.txtToProlongLicense.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVbrLicense, "CountLic1ToProlong", true));
            this.txtToProlongLicense.Location = new System.Drawing.Point(162, 53);
            this.txtToProlongLicense.Name = "txtToProlongLicense";
            // 
            // 
            // 
            this.txtToProlongLicense.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.txtToProlongLicense.Size = new System.Drawing.Size(42, 18);
            this.txtToProlongLicense.TabIndex = 48;
            this.txtToProlongLicense.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.txtToProlongLicense.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtToProlongLicense.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtToProlongLicense.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtToProlongLicense.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtToProlongLicense.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtToProlongLicense.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtToProlongLicense.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtToProlongLicense.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtToProlongLicense.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtToProlongLicense.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtToProlongLicense.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtToProlongLicense.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtToProlongLicense.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtToProlongLicense.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // radLabel11
            // 
            this.radLabel11.Location = new System.Drawing.Point(3, 53);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(142, 19);
            this.radLabel11.TabIndex = 47;
            this.radLabel11.Text = "Ліцензій до пролонгації";
            this.radLabel11.ThemeName = "Office2013Light";
            // 
            // txtNoAcceptReference
            // 
            this.txtNoAcceptReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoAcceptReference.AutoSize = false;
            this.txtNoAcceptReference.BorderVisible = true;
            this.txtNoAcceptReference.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVbrLicense, "CountLic3NoActive", true));
            this.txtNoAcceptReference.Location = new System.Drawing.Point(162, 53);
            this.txtNoAcceptReference.Name = "txtNoAcceptReference";
            // 
            // 
            // 
            this.txtNoAcceptReference.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.txtNoAcceptReference.Size = new System.Drawing.Size(42, 18);
            this.txtNoAcceptReference.TabIndex = 54;
            this.txtNoAcceptReference.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.txtNoAcceptReference.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtNoAcceptReference.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtNoAcceptReference.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtNoAcceptReference.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptReference.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptReference.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptReference.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptReference.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptReference.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptReference.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptReference.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptReference.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptReference.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptReference.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // radLabel13
            // 
            this.radLabel13.Location = new System.Drawing.Point(3, 53);
            this.radLabel13.Name = "radLabel13";
            this.radLabel13.Size = new System.Drawing.Size(151, 19);
            this.radLabel13.TabIndex = 53;
            this.radLabel13.Text = "Довідок не акцептованих";
            this.radLabel13.ThemeName = "Office2013Light";
            // 
            // txtNoAcceptRequest
            // 
            this.txtNoAcceptRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoAcceptRequest.AutoSize = false;
            this.txtNoAcceptRequest.BorderVisible = true;
            this.txtNoAcceptRequest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVbrLicense, "CountLic2NoActive", true));
            this.txtNoAcceptRequest.Location = new System.Drawing.Point(162, 28);
            this.txtNoAcceptRequest.Name = "txtNoAcceptRequest";
            // 
            // 
            // 
            this.txtNoAcceptRequest.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.txtNoAcceptRequest.Size = new System.Drawing.Size(42, 18);
            this.txtNoAcceptRequest.TabIndex = 52;
            this.txtNoAcceptRequest.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.txtNoAcceptRequest.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtNoAcceptRequest.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtNoAcceptRequest.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtNoAcceptRequest.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptRequest.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptRequest.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptRequest.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptRequest.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptRequest.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptRequest.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptRequest.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptRequest.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptRequest.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtNoAcceptRequest.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // radLabel15
            // 
            this.radLabel15.Location = new System.Drawing.Point(3, 28);
            this.radLabel15.Name = "radLabel15";
            this.radLabel15.Size = new System.Drawing.Size(145, 19);
            this.radLabel15.TabIndex = 51;
            this.radLabel15.Text = "Заявок не акцептованих";
            this.radLabel15.ThemeName = "Office2013Light";
            // 
            // txtActiveReqAndRef
            // 
            this.txtActiveReqAndRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActiveReqAndRef.AutoSize = false;
            this.txtActiveReqAndRef.BorderVisible = true;
            this.txtActiveReqAndRef.Location = new System.Drawing.Point(162, 3);
            this.txtActiveReqAndRef.Name = "txtActiveReqAndRef";
            // 
            // 
            // 
            this.txtActiveReqAndRef.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.txtActiveReqAndRef.Size = new System.Drawing.Size(42, 18);
            this.txtActiveReqAndRef.TabIndex = 50;
            this.txtActiveReqAndRef.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.txtActiveReqAndRef.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtActiveReqAndRef.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtActiveReqAndRef.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtActiveReqAndRef.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveReqAndRef.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveReqAndRef.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveReqAndRef.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveReqAndRef.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveReqAndRef.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveReqAndRef.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveReqAndRef.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveReqAndRef.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveReqAndRef.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtActiveReqAndRef.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // radLabel17
            // 
            this.radLabel17.Location = new System.Drawing.Point(3, 3);
            this.radLabel17.Name = "radLabel17";
            this.radLabel17.Size = new System.Drawing.Size(149, 19);
            this.radLabel17.TabIndex = 49;
            this.radLabel17.Text = "Активних заявок/довідок";
            this.radLabel17.ThemeName = "Office2013Light";
            // 
            // txtPrepayRest
            // 
            this.txtPrepayRest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrepayRest.AutoSize = false;
            this.txtPrepayRest.BorderVisible = true;
            this.txtPrepayRest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVbrLicense, "PrePayRest", true));
            this.txtPrepayRest.Location = new System.Drawing.Point(141, 53);
            this.txtPrepayRest.Name = "txtPrepayRest";
            // 
            // 
            // 
            this.txtPrepayRest.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.txtPrepayRest.Size = new System.Drawing.Size(115, 18);
            this.txtPrepayRest.TabIndex = 54;
            this.txtPrepayRest.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.txtPrepayRest.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtPrepayRest.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtPrepayRest.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtPrepayRest.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPrepayRest.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPrepayRest.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPrepayRest.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPrepayRest.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPrepayRest.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPrepayRest.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPrepayRest.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPrepayRest.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPrepayRest.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtPrepayRest.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // radLabel19
            // 
            this.radLabel19.Location = new System.Drawing.Point(3, 53);
            this.radLabel19.Name = "radLabel19";
            this.radLabel19.Size = new System.Drawing.Size(101, 19);
            this.radLabel19.TabIndex = 53;
            this.radLabel19.Text = "Залишок авансів";
            this.radLabel19.ThemeName = "Office2013Light";
            // 
            // txtUnAttachAmount
            // 
            this.txtUnAttachAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnAttachAmount.AutoSize = false;
            this.txtUnAttachAmount.BorderVisible = true;
            this.txtUnAttachAmount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVbrLicense, "UnattachAmount", true));
            this.txtUnAttachAmount.Location = new System.Drawing.Point(141, 28);
            this.txtUnAttachAmount.Name = "txtUnAttachAmount";
            // 
            // 
            // 
            this.txtUnAttachAmount.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.txtUnAttachAmount.Size = new System.Drawing.Size(115, 18);
            this.txtUnAttachAmount.TabIndex = 52;
            this.txtUnAttachAmount.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.txtUnAttachAmount.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtUnAttachAmount.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtUnAttachAmount.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtUnAttachAmount.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtUnAttachAmount.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtUnAttachAmount.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtUnAttachAmount.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtUnAttachAmount.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtUnAttachAmount.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtUnAttachAmount.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtUnAttachAmount.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtUnAttachAmount.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtUnAttachAmount.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtUnAttachAmount.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // radLabel21
            // 
            this.radLabel21.Location = new System.Drawing.Point(3, 28);
            this.radLabel21.Name = "radLabel21";
            this.radLabel21.Size = new System.Drawing.Size(132, 19);
            this.radLabel21.TabIndex = 51;
            this.radLabel21.Text = "Неприв\'язаних коштів";
            this.radLabel21.ThemeName = "Office2013Light";
            // 
            // txtAttachAmount
            // 
            this.txtAttachAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttachAmount.AutoSize = false;
            this.txtAttachAmount.BorderVisible = true;
            this.txtAttachAmount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVbrLicense, "Borg", true));
            this.txtAttachAmount.Location = new System.Drawing.Point(141, 3);
            this.txtAttachAmount.Name = "txtAttachAmount";
            // 
            // 
            // 
            this.txtAttachAmount.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.txtAttachAmount.Size = new System.Drawing.Size(115, 18);
            this.txtAttachAmount.TabIndex = 50;
            this.txtAttachAmount.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.txtAttachAmount.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtAttachAmount.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtAttachAmount.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            ((Telerik.WinControls.UI.RadLabelElement)(this.txtAttachAmount.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAttachAmount.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAttachAmount.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAttachAmount.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAttachAmount.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAttachAmount.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAttachAmount.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAttachAmount.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAttachAmount.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAttachAmount.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.txtAttachAmount.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // radLabel23
            // 
            this.radLabel23.Location = new System.Drawing.Point(3, 3);
            this.radLabel23.Name = "radLabel23";
            this.radLabel23.Size = new System.Drawing.Size(93, 19);
            this.radLabel23.TabIndex = 49;
            this.radLabel23.Text = "Заборгованість";
            this.radLabel23.ThemeName = "Office2013Light";
            // 
            // bsVbrLicense
            // 
            this.bsVbrLicense.DataSource = typeof(ipsFormsDesign.Interfaces.ConsumerBigRightView);
            // 
            // GeneralAgrDetailInfoBr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radPanel3);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.txtPartnerName);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.txtAgrDate);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.txtAgrNumber);
            this.Controls.Add(this.radLabel7);
            this.Controls.Add(this.radPanel1);
            this.Name = "GeneralAgrDetailInfoBr";
            this.Size = new System.Drawing.Size(691, 110);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgrNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgrDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPartnerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            this.radPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtActiveLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoAcceptLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToProlongLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoAcceptReference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoAcceptRequest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActiveReqAndRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrepayRest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnAttachAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttachAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVbrLicense)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadLabel txtAgrNumber;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel txtToProlongLicense;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        private Telerik.WinControls.UI.RadLabel txtNoAcceptLicense;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadLabel txtActiveLicense;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel txtAgrDate;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel txtPartnerName;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadLabel txtNoAcceptReference;
        private Telerik.WinControls.UI.RadLabel radLabel13;
        private Telerik.WinControls.UI.RadLabel txtNoAcceptRequest;
        private Telerik.WinControls.UI.RadLabel radLabel15;
        private Telerik.WinControls.UI.RadLabel txtActiveReqAndRef;
        private Telerik.WinControls.UI.RadLabel radLabel17;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private Telerik.WinControls.UI.RadLabel txtPrepayRest;
        private Telerik.WinControls.UI.RadLabel radLabel19;
        private Telerik.WinControls.UI.RadLabel txtUnAttachAmount;
        private Telerik.WinControls.UI.RadLabel radLabel21;
        private Telerik.WinControls.UI.RadLabel txtAttachAmount;
        private Telerik.WinControls.UI.RadLabel radLabel23;
        private System.Windows.Forms.BindingSource bsVbrLicense;
    }
}
