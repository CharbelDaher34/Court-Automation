
namespace Auto_Court
{
    partial class Court
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Court));
            this.dgvCourt = new System.Windows.Forms.DataGridView();
            this.dgvCourtSection = new System.Windows.Forms.DataGridView();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.comboBoxAdmin = new System.Windows.Forms.ComboBox();
            this.lblSectionName = new System.Windows.Forms.Label();
            this.lblSectionType = new System.Windows.Forms.Label();
            this.lblFansCapacity = new System.Windows.Forms.Label();
            this.lblCourtId = new System.Windows.Forms.Label();
            this.txtSectionName = new System.Windows.Forms.TextBox();
            this.txtSectionType = new System.Windows.Forms.TextBox();
            this.txtFansCapacity = new System.Windows.Forms.TextBox();
            this.comboBoxCourtId = new System.Windows.Forms.ComboBox();
            this.btnAddCourt = new System.Windows.Forms.Button();
            this.btnAddCourtSection = new System.Windows.Forms.Button();
            this.btnResetCourt = new System.Windows.Forms.Button();
            this.dtPOpenTime = new System.Windows.Forms.DateTimePicker();
            this.dtPCloseTime = new System.Windows.Forms.DateTimePicker();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.Price = new System.Windows.Forms.Label();
            this.lblOpenTime = new System.Windows.Forms.Label();
            this.lblCloseTime = new System.Windows.Forms.Label();
            this.btnDeleteCourt = new System.Windows.Forms.Button();
            this.btnEditCourt = new System.Windows.Forms.Button();
            this.btnDeleteCourtSection = new System.Windows.Forms.Button();
            this.btnEditCourtSection = new System.Windows.Forms.Button();
            this.btnResetCourtSection = new System.Windows.Forms.Button();
            this.btnBackToFood = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picBoxBack = new System.Windows.Forms.PictureBox();
            this.picBoxExit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourtSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxExit)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCourt
            // 
            this.dgvCourt.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.dgvCourt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourt.Location = new System.Drawing.Point(22, 101);
            this.dgvCourt.Name = "dgvCourt";
            this.dgvCourt.RowHeadersWidth = 51;
            this.dgvCourt.RowTemplate.Height = 29;
            this.dgvCourt.Size = new System.Drawing.Size(300, 188);
            this.dgvCourt.TabIndex = 0;
            // 
            // dgvCourtSection
            // 
            this.dgvCourtSection.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.dgvCourtSection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourtSection.Location = new System.Drawing.Point(22, 327);
            this.dgvCourtSection.Name = "dgvCourtSection";
            this.dgvCourtSection.RowHeadersWidth = 51;
            this.dgvCourtSection.RowTemplate.Height = 29;
            this.dgvCourtSection.Size = new System.Drawing.Size(300, 197);
            this.dgvCourtSection.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblName.Location = new System.Drawing.Point(339, 101);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(129, 23);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Court Name";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblLocation.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLocation.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblLocation.Location = new System.Drawing.Point(564, 101);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(94, 23);
            this.lblLocation.TabIndex = 3;
            this.lblLocation.Text = "Location";
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.BackColor = System.Drawing.Color.Transparent;
            this.lblAdmin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAdmin.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblAdmin.Location = new System.Drawing.Point(468, 181);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(74, 23);
            this.lblAdmin.TabIndex = 4;
            this.lblAdmin.Text = "Admin";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(342, 127);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(156, 27);
            this.txtName.TabIndex = 5;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(564, 127);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(156, 27);
            this.txtLocation.TabIndex = 6;
            // 
            // comboBoxAdmin
            // 
            this.comboBoxAdmin.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBoxAdmin.FormattingEnabled = true;
            this.comboBoxAdmin.Location = new System.Drawing.Point(468, 204);
            this.comboBoxAdmin.Name = "comboBoxAdmin";
            this.comboBoxAdmin.Size = new System.Drawing.Size(125, 28);
            this.comboBoxAdmin.TabIndex = 7;
            // 
            // lblSectionName
            // 
            this.lblSectionName.AutoSize = true;
            this.lblSectionName.BackColor = System.Drawing.Color.Transparent;
            this.lblSectionName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSectionName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblSectionName.Location = new System.Drawing.Point(339, 324);
            this.lblSectionName.Name = "lblSectionName";
            this.lblSectionName.Size = new System.Drawing.Size(148, 23);
            this.lblSectionName.TabIndex = 8;
            this.lblSectionName.Text = "Section Name";
            // 
            // lblSectionType
            // 
            this.lblSectionType.AutoSize = true;
            this.lblSectionType.BackColor = System.Drawing.Color.Transparent;
            this.lblSectionType.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSectionType.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblSectionType.Location = new System.Drawing.Point(564, 324);
            this.lblSectionType.Name = "lblSectionType";
            this.lblSectionType.Size = new System.Drawing.Size(134, 23);
            this.lblSectionType.TabIndex = 9;
            this.lblSectionType.Text = "Section Type";
            // 
            // lblFansCapacity
            // 
            this.lblFansCapacity.AutoSize = true;
            this.lblFansCapacity.BackColor = System.Drawing.Color.Transparent;
            this.lblFansCapacity.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFansCapacity.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblFansCapacity.Location = new System.Drawing.Point(336, 398);
            this.lblFansCapacity.Name = "lblFansCapacity";
            this.lblFansCapacity.Size = new System.Drawing.Size(151, 23);
            this.lblFansCapacity.TabIndex = 10;
            this.lblFansCapacity.Text = "Fans Capacity";
            // 
            // lblCourtId
            // 
            this.lblCourtId.AutoSize = true;
            this.lblCourtId.BackColor = System.Drawing.Color.Transparent;
            this.lblCourtId.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCourtId.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblCourtId.Location = new System.Drawing.Point(564, 394);
            this.lblCourtId.Name = "lblCourtId";
            this.lblCourtId.Size = new System.Drawing.Size(129, 23);
            this.lblCourtId.TabIndex = 11;
            this.lblCourtId.Text = "Court Name";
            // 
            // txtSectionName
            // 
            this.txtSectionName.Location = new System.Drawing.Point(339, 350);
            this.txtSectionName.Name = "txtSectionName";
            this.txtSectionName.Size = new System.Drawing.Size(159, 27);
            this.txtSectionName.TabIndex = 12;
            // 
            // txtSectionType
            // 
            this.txtSectionType.Location = new System.Drawing.Point(564, 350);
            this.txtSectionType.Name = "txtSectionType";
            this.txtSectionType.Size = new System.Drawing.Size(156, 27);
            this.txtSectionType.TabIndex = 13;
            // 
            // txtFansCapacity
            // 
            this.txtFansCapacity.Location = new System.Drawing.Point(339, 422);
            this.txtFansCapacity.Name = "txtFansCapacity";
            this.txtFansCapacity.Size = new System.Drawing.Size(148, 27);
            this.txtFansCapacity.TabIndex = 14;
            // 
            // comboBoxCourtId
            // 
            this.comboBoxCourtId.FormattingEnabled = true;
            this.comboBoxCourtId.Location = new System.Drawing.Point(564, 420);
            this.comboBoxCourtId.Name = "comboBoxCourtId";
            this.comboBoxCourtId.Size = new System.Drawing.Size(156, 28);
            this.comboBoxCourtId.TabIndex = 15;
            // 
            // btnAddCourt
            // 
            this.btnAddCourt.BackColor = System.Drawing.Color.OrangeRed;
            this.btnAddCourt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCourt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddCourt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddCourt.ForeColor = System.Drawing.Color.White;
            this.btnAddCourt.Location = new System.Drawing.Point(330, 254);
            this.btnAddCourt.Name = "btnAddCourt";
            this.btnAddCourt.Size = new System.Drawing.Size(94, 35);
            this.btnAddCourt.TabIndex = 16;
            this.btnAddCourt.Text = "Add";
            this.btnAddCourt.UseVisualStyleBackColor = false;
            this.btnAddCourt.Click += new System.EventHandler(this.btnAddCourt_Click);
            // 
            // btnAddCourtSection
            // 
            this.btnAddCourtSection.BackColor = System.Drawing.Color.OrangeRed;
            this.btnAddCourtSection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCourtSection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddCourtSection.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddCourtSection.ForeColor = System.Drawing.Color.White;
            this.btnAddCourtSection.Location = new System.Drawing.Point(330, 537);
            this.btnAddCourtSection.Name = "btnAddCourtSection";
            this.btnAddCourtSection.Size = new System.Drawing.Size(94, 35);
            this.btnAddCourtSection.TabIndex = 17;
            this.btnAddCourtSection.Text = "Add";
            this.btnAddCourtSection.UseVisualStyleBackColor = false;
            this.btnAddCourtSection.Click += new System.EventHandler(this.btnAddCourtSection_Click);
            // 
            // btnResetCourt
            // 
            this.btnResetCourt.BackColor = System.Drawing.Color.OrangeRed;
            this.btnResetCourt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResetCourt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnResetCourt.ForeColor = System.Drawing.Color.White;
            this.btnResetCourt.Location = new System.Drawing.Point(630, 254);
            this.btnResetCourt.Name = "btnResetCourt";
            this.btnResetCourt.Size = new System.Drawing.Size(94, 35);
            this.btnResetCourt.TabIndex = 18;
            this.btnResetCourt.Text = "Reset";
            this.btnResetCourt.UseVisualStyleBackColor = false;
            this.btnResetCourt.Click += new System.EventHandler(this.btnResetCourt_Click);
            // 
            // dtPOpenTime
            // 
            this.dtPOpenTime.CustomFormat = "HH:mm ";
            this.dtPOpenTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPOpenTime.Location = new System.Drawing.Point(339, 497);
            this.dtPOpenTime.Name = "dtPOpenTime";
            this.dtPOpenTime.ShowUpDown = true;
            this.dtPOpenTime.Size = new System.Drawing.Size(116, 27);
            this.dtPOpenTime.TabIndex = 19;
            // 
            // dtPCloseTime
            // 
            this.dtPCloseTime.CustomFormat = "HH:mm ";
            this.dtPCloseTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPCloseTime.Location = new System.Drawing.Point(479, 497);
            this.dtPCloseTime.Name = "dtPCloseTime";
            this.dtPCloseTime.ShowUpDown = true;
            this.dtPCloseTime.Size = new System.Drawing.Size(117, 27);
            this.dtPCloseTime.TabIndex = 20;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(627, 497);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(97, 27);
            this.txtPrice.TabIndex = 21;
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.BackColor = System.Drawing.Color.Transparent;
            this.Price.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Price.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Price.Location = new System.Drawing.Point(627, 471);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(91, 23);
            this.Price.TabIndex = 22;
            this.Price.Text = "Price ($)";
            // 
            // lblOpenTime
            // 
            this.lblOpenTime.AutoSize = true;
            this.lblOpenTime.BackColor = System.Drawing.Color.Transparent;
            this.lblOpenTime.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOpenTime.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblOpenTime.Location = new System.Drawing.Point(339, 471);
            this.lblOpenTime.Name = "lblOpenTime";
            this.lblOpenTime.Size = new System.Drawing.Size(116, 23);
            this.lblOpenTime.TabIndex = 23;
            this.lblOpenTime.Text = "Open Time";
            // 
            // lblCloseTime
            // 
            this.lblCloseTime.AutoSize = true;
            this.lblCloseTime.BackColor = System.Drawing.Color.Transparent;
            this.lblCloseTime.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCloseTime.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblCloseTime.Location = new System.Drawing.Point(479, 471);
            this.lblCloseTime.Name = "lblCloseTime";
            this.lblCloseTime.Size = new System.Drawing.Size(117, 23);
            this.lblCloseTime.TabIndex = 24;
            this.lblCloseTime.Text = "Close Time";
            // 
            // btnDeleteCourt
            // 
            this.btnDeleteCourt.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDeleteCourt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteCourt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteCourt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteCourt.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCourt.Location = new System.Drawing.Point(430, 254);
            this.btnDeleteCourt.Name = "btnDeleteCourt";
            this.btnDeleteCourt.Size = new System.Drawing.Size(94, 35);
            this.btnDeleteCourt.TabIndex = 25;
            this.btnDeleteCourt.Text = "Delete";
            this.btnDeleteCourt.UseVisualStyleBackColor = false;
            this.btnDeleteCourt.Click += new System.EventHandler(this.btnDeleteCourt_Click);
            // 
            // btnEditCourt
            // 
            this.btnEditCourt.BackColor = System.Drawing.Color.OrangeRed;
            this.btnEditCourt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditCourt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditCourt.ForeColor = System.Drawing.Color.White;
            this.btnEditCourt.Location = new System.Drawing.Point(530, 254);
            this.btnEditCourt.Name = "btnEditCourt";
            this.btnEditCourt.Size = new System.Drawing.Size(94, 35);
            this.btnEditCourt.TabIndex = 26;
            this.btnEditCourt.Text = "Edit";
            this.btnEditCourt.UseVisualStyleBackColor = false;
            this.btnEditCourt.Click += new System.EventHandler(this.btnEditCourt_Click);
            // 
            // btnDeleteCourtSection
            // 
            this.btnDeleteCourtSection.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDeleteCourtSection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteCourtSection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteCourtSection.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteCourtSection.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCourtSection.Location = new System.Drawing.Point(430, 537);
            this.btnDeleteCourtSection.Name = "btnDeleteCourtSection";
            this.btnDeleteCourtSection.Size = new System.Drawing.Size(94, 35);
            this.btnDeleteCourtSection.TabIndex = 27;
            this.btnDeleteCourtSection.Text = "Delete";
            this.btnDeleteCourtSection.UseVisualStyleBackColor = false;
            this.btnDeleteCourtSection.Click += new System.EventHandler(this.btnDeleteCourtSection_Click);
            // 
            // btnEditCourtSection
            // 
            this.btnEditCourtSection.BackColor = System.Drawing.Color.OrangeRed;
            this.btnEditCourtSection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditCourtSection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditCourtSection.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditCourtSection.ForeColor = System.Drawing.Color.White;
            this.btnEditCourtSection.Location = new System.Drawing.Point(530, 537);
            this.btnEditCourtSection.Name = "btnEditCourtSection";
            this.btnEditCourtSection.Size = new System.Drawing.Size(94, 35);
            this.btnEditCourtSection.TabIndex = 28;
            this.btnEditCourtSection.Text = "Edit";
            this.btnEditCourtSection.UseVisualStyleBackColor = false;
            this.btnEditCourtSection.Click += new System.EventHandler(this.btnEditCourtSection_Click);
            // 
            // btnResetCourtSection
            // 
            this.btnResetCourtSection.BackColor = System.Drawing.Color.OrangeRed;
            this.btnResetCourtSection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetCourtSection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResetCourtSection.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnResetCourtSection.ForeColor = System.Drawing.Color.White;
            this.btnResetCourtSection.Location = new System.Drawing.Point(630, 537);
            this.btnResetCourtSection.Name = "btnResetCourtSection";
            this.btnResetCourtSection.Size = new System.Drawing.Size(94, 35);
            this.btnResetCourtSection.TabIndex = 29;
            this.btnResetCourtSection.Text = "Reset";
            this.btnResetCourtSection.UseVisualStyleBackColor = false;
            this.btnResetCourtSection.Click += new System.EventHandler(this.btnResetCourtSection_Click);
            // 
            // btnBackToFood
            // 
            this.btnBackToFood.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnBackToFood.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackToFood.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBackToFood.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBackToFood.ForeColor = System.Drawing.Color.White;
            this.btnBackToFood.Location = new System.Drawing.Point(22, 537);
            this.btnBackToFood.Name = "btnBackToFood";
            this.btnBackToFood.Size = new System.Drawing.Size(300, 35);
            this.btnBackToFood.TabIndex = 30;
            this.btnBackToFood.Text = "Go Back To Food Form";
            this.btnBackToFood.UseVisualStyleBackColor = false;
            this.btnBackToFood.Click += new System.EventHandler(this.btnBackToFood_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(350, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 44);
            this.label1.TabIndex = 31;
            this.label1.Text = "Court Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.Location = new System.Drawing.Point(125, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 34);
            this.label2.TabIndex = 32;
            this.label2.Text = "Courts";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Firebrick;
            this.label3.Location = new System.Drawing.Point(70, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 34);
            this.label3.TabIndex = 33;
            this.label3.Text = "Court Sections";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picBoxBack
            // 
            this.picBoxBack.BackColor = System.Drawing.Color.Transparent;
            this.picBoxBack.Image = ((System.Drawing.Image)(resources.GetObject("picBoxBack.Image")));
            this.picBoxBack.Location = new System.Drawing.Point(999, 12);
            this.picBoxBack.Name = "picBoxBack";
            this.picBoxBack.Size = new System.Drawing.Size(47, 44);
            this.picBoxBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxBack.TabIndex = 35;
            this.picBoxBack.TabStop = false;
            this.picBoxBack.Click += new System.EventHandler(this.picBoxBack_Click);
            // 
            // picBoxExit
            // 
            this.picBoxExit.BackColor = System.Drawing.Color.Transparent;
            this.picBoxExit.Image = ((System.Drawing.Image)(resources.GetObject("picBoxExit.Image")));
            this.picBoxExit.Location = new System.Drawing.Point(1052, 12);
            this.picBoxExit.Name = "picBoxExit";
            this.picBoxExit.Size = new System.Drawing.Size(47, 44);
            this.picBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxExit.TabIndex = 34;
            this.picBoxExit.TabStop = false;
            this.picBoxExit.Click += new System.EventHandler(this.picBoxExit_Click);
            // 
            // Court
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Auto_Court.Properties.Resources.Design_4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1111, 595);
            this.Controls.Add(this.picBoxBack);
            this.Controls.Add(this.picBoxExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBackToFood);
            this.Controls.Add(this.btnResetCourtSection);
            this.Controls.Add(this.btnEditCourtSection);
            this.Controls.Add(this.btnDeleteCourtSection);
            this.Controls.Add(this.btnEditCourt);
            this.Controls.Add(this.btnDeleteCourt);
            this.Controls.Add(this.lblCloseTime);
            this.Controls.Add(this.lblOpenTime);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.dtPCloseTime);
            this.Controls.Add(this.dtPOpenTime);
            this.Controls.Add(this.btnResetCourt);
            this.Controls.Add(this.btnAddCourtSection);
            this.Controls.Add(this.btnAddCourt);
            this.Controls.Add(this.comboBoxCourtId);
            this.Controls.Add(this.txtFansCapacity);
            this.Controls.Add(this.txtSectionType);
            this.Controls.Add(this.txtSectionName);
            this.Controls.Add(this.lblCourtId);
            this.Controls.Add(this.lblFansCapacity);
            this.Controls.Add(this.lblSectionType);
            this.Controls.Add(this.lblSectionName);
            this.Controls.Add(this.comboBoxAdmin);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblAdmin);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.dgvCourtSection);
            this.Controls.Add(this.dgvCourt);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Court";
            this.Text = "Court";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourtSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCourt;
        private System.Windows.Forms.DataGridView dgvCourtSection;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.ComboBox comboBoxAdmin;
        private System.Windows.Forms.Label lblSectionName;
        private System.Windows.Forms.Label lblSectionType;
        private System.Windows.Forms.Label lblFansCapacity;
        private System.Windows.Forms.Label lblCourtId;
        private System.Windows.Forms.TextBox txtSectionName;
        private System.Windows.Forms.TextBox txtSectionType;
        private System.Windows.Forms.TextBox txtFansCapacity;
        private System.Windows.Forms.ComboBox comboBoxCourtId;
        private System.Windows.Forms.Button btnAddCourt;
        private System.Windows.Forms.Button btnAddCourtSection;
        private System.Windows.Forms.Button btnResetCourt;
        private System.Windows.Forms.DateTimePicker dtPOpenTime;
        private System.Windows.Forms.DateTimePicker dtPCloseTime;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label lblOpenTime;
        private System.Windows.Forms.Label lblCloseTime;
        private System.Windows.Forms.Button btnDeleteCourt;
        private System.Windows.Forms.Button btnEditCourt;
        private System.Windows.Forms.Button btnDeleteCourtSection;
        private System.Windows.Forms.Button btnEditCourtSection;
        private System.Windows.Forms.Button btnResetCourtSection;
        private System.Windows.Forms.Button btnBackToFood;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picBoxBack;
        private System.Windows.Forms.PictureBox picBoxExit;
    }
}