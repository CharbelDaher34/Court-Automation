
namespace Auto_Court
{
    partial class Food
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Food));
            this.dgvVendingMachine = new System.Windows.Forms.DataGridView();
            this.dgvDealer = new System.Windows.Forms.DataGridView();
            this.dgvFood = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCourtSectionId = new System.Windows.Forms.ComboBox();
            this.btnAddVendingMachine = new System.Windows.Forms.Button();
            this.btnUpdateVendingMachine = new System.Windows.Forms.Button();
            this.btnDeleteVendingMachine = new System.Windows.Forms.Button();
            this.btnResetVendingMachine = new System.Windows.Forms.Button();
            this.lblDealerName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblContactInfo = new System.Windows.Forms.Label();
            this.lblMarginOfProfit = new System.Windows.Forms.Label();
            this.txtDealerName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtContactInfo = new System.Windows.Forms.TextBox();
            this.txtMarginOfProfit = new System.Windows.Forms.TextBox();
            this.btnAddDealer = new System.Windows.Forms.Button();
            this.btnUpdateDealer = new System.Windows.Forms.Button();
            this.btnDeleteDealer = new System.Windows.Forms.Button();
            this.btnResetDealer = new System.Windows.Forms.Button();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.btnUpdateFood = new System.Windows.Forms.Button();
            this.btnDeleteFood = new System.Windows.Forms.Button();
            this.btnResetFood = new System.Windows.Forms.Button();
            this.lblFoodName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblMaxQuantity = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblVendingMachineId = new System.Windows.Forms.Label();
            this.txtFoodName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtMaxQuantity = new System.Windows.Forms.TextBox();
            this.comboBoxDealerId = new System.Windows.Forms.ComboBox();
            this.comboBoxVendingMachineId = new System.Windows.Forms.ComboBox();
            this.btnCheckCS = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.picBoxBack = new System.Windows.Forms.PictureBox();
            this.picBoxExit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendingMachine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDealer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFood)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxExit)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVendingMachine
            // 
            this.dgvVendingMachine.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.dgvVendingMachine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendingMachine.GridColor = System.Drawing.Color.DarkSlateGray;
            this.dgvVendingMachine.Location = new System.Drawing.Point(22, 88);
            this.dgvVendingMachine.Name = "dgvVendingMachine";
            this.dgvVendingMachine.RowHeadersWidth = 51;
            this.dgvVendingMachine.RowTemplate.Height = 29;
            this.dgvVendingMachine.Size = new System.Drawing.Size(292, 153);
            this.dgvVendingMachine.TabIndex = 0;
            // 
            // dgvDealer
            // 
            this.dgvDealer.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.dgvDealer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDealer.GridColor = System.Drawing.Color.DarkSlateGray;
            this.dgvDealer.Location = new System.Drawing.Point(338, 88);
            this.dgvDealer.Name = "dgvDealer";
            this.dgvDealer.RowHeadersWidth = 51;
            this.dgvDealer.RowTemplate.Height = 29;
            this.dgvDealer.Size = new System.Drawing.Size(438, 153);
            this.dgvDealer.TabIndex = 1;
            // 
            // dgvFood
            // 
            this.dgvFood.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.dgvFood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFood.GridColor = System.Drawing.Color.DarkSlateGray;
            this.dgvFood.Location = new System.Drawing.Point(20, 424);
            this.dgvFood.Name = "dgvFood";
            this.dgvFood.RowHeadersWidth = 51;
            this.dgvFood.RowTemplate.Height = 29;
            this.dgvFood.Size = new System.Drawing.Size(395, 177);
            this.dgvFood.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(22, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Court Section";
            // 
            // comboBoxCourtSectionId
            // 
            this.comboBoxCourtSectionId.FormattingEnabled = true;
            this.comboBoxCourtSectionId.Location = new System.Drawing.Point(164, 244);
            this.comboBoxCourtSectionId.Name = "comboBoxCourtSectionId";
            this.comboBoxCourtSectionId.Size = new System.Drawing.Size(150, 28);
            this.comboBoxCourtSectionId.TabIndex = 4;
            // 
            // btnAddVendingMachine
            // 
            this.btnAddVendingMachine.BackColor = System.Drawing.Color.OrangeRed;
            this.btnAddVendingMachine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddVendingMachine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddVendingMachine.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddVendingMachine.ForeColor = System.Drawing.Color.White;
            this.btnAddVendingMachine.Location = new System.Drawing.Point(47, 279);
            this.btnAddVendingMachine.Name = "btnAddVendingMachine";
            this.btnAddVendingMachine.Size = new System.Drawing.Size(105, 30);
            this.btnAddVendingMachine.TabIndex = 5;
            this.btnAddVendingMachine.Text = "Add";
            this.btnAddVendingMachine.UseVisualStyleBackColor = false;
            this.btnAddVendingMachine.Click += new System.EventHandler(this.btnAddVendingMachine_Click);
            // 
            // btnUpdateVendingMachine
            // 
            this.btnUpdateVendingMachine.BackColor = System.Drawing.Color.OrangeRed;
            this.btnUpdateVendingMachine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateVendingMachine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateVendingMachine.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdateVendingMachine.ForeColor = System.Drawing.Color.White;
            this.btnUpdateVendingMachine.Location = new System.Drawing.Point(185, 279);
            this.btnUpdateVendingMachine.Name = "btnUpdateVendingMachine";
            this.btnUpdateVendingMachine.Size = new System.Drawing.Size(105, 30);
            this.btnUpdateVendingMachine.TabIndex = 6;
            this.btnUpdateVendingMachine.Text = "Update";
            this.btnUpdateVendingMachine.UseVisualStyleBackColor = false;
            this.btnUpdateVendingMachine.Click += new System.EventHandler(this.btnUpdateVendingMachine_Click);
            // 
            // btnDeleteVendingMachine
            // 
            this.btnDeleteVendingMachine.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDeleteVendingMachine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteVendingMachine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteVendingMachine.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteVendingMachine.ForeColor = System.Drawing.Color.White;
            this.btnDeleteVendingMachine.Location = new System.Drawing.Point(47, 317);
            this.btnDeleteVendingMachine.Name = "btnDeleteVendingMachine";
            this.btnDeleteVendingMachine.Size = new System.Drawing.Size(105, 30);
            this.btnDeleteVendingMachine.TabIndex = 7;
            this.btnDeleteVendingMachine.Text = "Delete";
            this.btnDeleteVendingMachine.UseVisualStyleBackColor = false;
            this.btnDeleteVendingMachine.Click += new System.EventHandler(this.btnDeleteVendingMachine_Click);
            // 
            // btnResetVendingMachine
            // 
            this.btnResetVendingMachine.BackColor = System.Drawing.Color.OrangeRed;
            this.btnResetVendingMachine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetVendingMachine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResetVendingMachine.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnResetVendingMachine.ForeColor = System.Drawing.Color.White;
            this.btnResetVendingMachine.Location = new System.Drawing.Point(185, 317);
            this.btnResetVendingMachine.Name = "btnResetVendingMachine";
            this.btnResetVendingMachine.Size = new System.Drawing.Size(105, 30);
            this.btnResetVendingMachine.TabIndex = 8;
            this.btnResetVendingMachine.Text = "Reset";
            this.btnResetVendingMachine.UseVisualStyleBackColor = false;
            this.btnResetVendingMachine.Click += new System.EventHandler(this.btnResetVendingMachine_Click);
            // 
            // lblDealerName
            // 
            this.lblDealerName.AutoSize = true;
            this.lblDealerName.BackColor = System.Drawing.Color.Transparent;
            this.lblDealerName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDealerName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblDealerName.Location = new System.Drawing.Point(338, 244);
            this.lblDealerName.Name = "lblDealerName";
            this.lblDealerName.Size = new System.Drawing.Size(153, 23);
            this.lblDealerName.TabIndex = 9;
            this.lblDealerName.Text = "Dealer\'s Name";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAddress.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblAddress.Location = new System.Drawing.Point(506, 244);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(88, 23);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = "Address";
            // 
            // lblContactInfo
            // 
            this.lblContactInfo.AutoSize = true;
            this.lblContactInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblContactInfo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblContactInfo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblContactInfo.Location = new System.Drawing.Point(338, 307);
            this.lblContactInfo.Name = "lblContactInfo";
            this.lblContactInfo.Size = new System.Drawing.Size(132, 23);
            this.lblContactInfo.TabIndex = 11;
            this.lblContactInfo.Text = "Contact Info";
            // 
            // lblMarginOfProfit
            // 
            this.lblMarginOfProfit.AutoSize = true;
            this.lblMarginOfProfit.BackColor = System.Drawing.Color.Transparent;
            this.lblMarginOfProfit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMarginOfProfit.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblMarginOfProfit.Location = new System.Drawing.Point(506, 307);
            this.lblMarginOfProfit.Name = "lblMarginOfProfit";
            this.lblMarginOfProfit.Size = new System.Drawing.Size(159, 23);
            this.lblMarginOfProfit.TabIndex = 12;
            this.lblMarginOfProfit.Text = "Margin Of Profit";
            // 
            // txtDealerName
            // 
            this.txtDealerName.Location = new System.Drawing.Point(338, 270);
            this.txtDealerName.Name = "txtDealerName";
            this.txtDealerName.Size = new System.Drawing.Size(153, 27);
            this.txtDealerName.TabIndex = 13;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(506, 270);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(159, 27);
            this.txtAddress.TabIndex = 14;
            // 
            // txtContactInfo
            // 
            this.txtContactInfo.Location = new System.Drawing.Point(338, 333);
            this.txtContactInfo.Name = "txtContactInfo";
            this.txtContactInfo.Size = new System.Drawing.Size(153, 27);
            this.txtContactInfo.TabIndex = 15;
            // 
            // txtMarginOfProfit
            // 
            this.txtMarginOfProfit.Location = new System.Drawing.Point(506, 333);
            this.txtMarginOfProfit.Name = "txtMarginOfProfit";
            this.txtMarginOfProfit.Size = new System.Drawing.Size(159, 27);
            this.txtMarginOfProfit.TabIndex = 16;
            // 
            // btnAddDealer
            // 
            this.btnAddDealer.BackColor = System.Drawing.Color.OrangeRed;
            this.btnAddDealer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDealer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddDealer.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddDealer.ForeColor = System.Drawing.Color.White;
            this.btnAddDealer.Location = new System.Drawing.Point(671, 244);
            this.btnAddDealer.Name = "btnAddDealer";
            this.btnAddDealer.Size = new System.Drawing.Size(105, 30);
            this.btnAddDealer.TabIndex = 17;
            this.btnAddDealer.Text = "Add";
            this.btnAddDealer.UseVisualStyleBackColor = false;
            this.btnAddDealer.Click += new System.EventHandler(this.btnAddDealer_Click);
            // 
            // btnUpdateDealer
            // 
            this.btnUpdateDealer.BackColor = System.Drawing.Color.OrangeRed;
            this.btnUpdateDealer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateDealer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateDealer.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdateDealer.ForeColor = System.Drawing.Color.White;
            this.btnUpdateDealer.Location = new System.Drawing.Point(671, 279);
            this.btnUpdateDealer.Name = "btnUpdateDealer";
            this.btnUpdateDealer.Size = new System.Drawing.Size(105, 30);
            this.btnUpdateDealer.TabIndex = 18;
            this.btnUpdateDealer.Text = "Update";
            this.btnUpdateDealer.UseVisualStyleBackColor = false;
            this.btnUpdateDealer.Click += new System.EventHandler(this.btnUpdateDealer_Click);
            // 
            // btnDeleteDealer
            // 
            this.btnDeleteDealer.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDeleteDealer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteDealer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteDealer.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteDealer.ForeColor = System.Drawing.Color.White;
            this.btnDeleteDealer.Location = new System.Drawing.Point(671, 314);
            this.btnDeleteDealer.Name = "btnDeleteDealer";
            this.btnDeleteDealer.Size = new System.Drawing.Size(105, 30);
            this.btnDeleteDealer.TabIndex = 19;
            this.btnDeleteDealer.Text = "Delete";
            this.btnDeleteDealer.UseVisualStyleBackColor = false;
            this.btnDeleteDealer.Click += new System.EventHandler(this.btnDeleteDealer_Click);
            // 
            // btnResetDealer
            // 
            this.btnResetDealer.BackColor = System.Drawing.Color.OrangeRed;
            this.btnResetDealer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetDealer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResetDealer.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnResetDealer.ForeColor = System.Drawing.Color.White;
            this.btnResetDealer.Location = new System.Drawing.Point(671, 349);
            this.btnResetDealer.Name = "btnResetDealer";
            this.btnResetDealer.Size = new System.Drawing.Size(105, 30);
            this.btnResetDealer.TabIndex = 20;
            this.btnResetDealer.Text = "Reset";
            this.btnResetDealer.UseVisualStyleBackColor = false;
            this.btnResetDealer.Click += new System.EventHandler(this.btnResetDealer_Click);
            // 
            // btnAddFood
            // 
            this.btnAddFood.BackColor = System.Drawing.Color.OrangeRed;
            this.btnAddFood.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFood.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddFood.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddFood.ForeColor = System.Drawing.Color.White;
            this.btnAddFood.Location = new System.Drawing.Point(22, 607);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(90, 30);
            this.btnAddFood.TabIndex = 21;
            this.btnAddFood.Text = "Add";
            this.btnAddFood.UseVisualStyleBackColor = false;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // btnUpdateFood
            // 
            this.btnUpdateFood.BackColor = System.Drawing.Color.OrangeRed;
            this.btnUpdateFood.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateFood.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateFood.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdateFood.ForeColor = System.Drawing.Color.White;
            this.btnUpdateFood.Location = new System.Drawing.Point(123, 607);
            this.btnUpdateFood.Name = "btnUpdateFood";
            this.btnUpdateFood.Size = new System.Drawing.Size(90, 30);
            this.btnUpdateFood.TabIndex = 22;
            this.btnUpdateFood.Text = "Update";
            this.btnUpdateFood.UseVisualStyleBackColor = false;
            this.btnUpdateFood.Click += new System.EventHandler(this.btnUpdateFood_Click);
            // 
            // btnDeleteFood
            // 
            this.btnDeleteFood.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDeleteFood.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteFood.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteFood.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteFood.ForeColor = System.Drawing.Color.White;
            this.btnDeleteFood.Location = new System.Drawing.Point(224, 607);
            this.btnDeleteFood.Name = "btnDeleteFood";
            this.btnDeleteFood.Size = new System.Drawing.Size(90, 30);
            this.btnDeleteFood.TabIndex = 23;
            this.btnDeleteFood.Text = "Delete";
            this.btnDeleteFood.UseVisualStyleBackColor = false;
            this.btnDeleteFood.Click += new System.EventHandler(this.btnDeleteFood_Click);
            // 
            // btnResetFood
            // 
            this.btnResetFood.BackColor = System.Drawing.Color.OrangeRed;
            this.btnResetFood.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetFood.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResetFood.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnResetFood.ForeColor = System.Drawing.Color.White;
            this.btnResetFood.Location = new System.Drawing.Point(325, 607);
            this.btnResetFood.Name = "btnResetFood";
            this.btnResetFood.Size = new System.Drawing.Size(90, 30);
            this.btnResetFood.TabIndex = 24;
            this.btnResetFood.Text = "Reset";
            this.btnResetFood.UseVisualStyleBackColor = false;
            this.btnResetFood.Click += new System.EventHandler(this.btnResetFood_Click);
            // 
            // lblFoodName
            // 
            this.lblFoodName.AutoSize = true;
            this.lblFoodName.BackColor = System.Drawing.Color.Transparent;
            this.lblFoodName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFoodName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblFoodName.Location = new System.Drawing.Point(432, 413);
            this.lblFoodName.Name = "lblFoodName";
            this.lblFoodName.Size = new System.Drawing.Size(125, 23);
            this.lblFoodName.TabIndex = 25;
            this.lblFoodName.Text = "Food Name";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblDescription.Location = new System.Drawing.Point(432, 446);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(119, 23);
            this.lblDescription.TabIndex = 26;
            this.lblDescription.Text = "Description";
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblUnitPrice.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUnitPrice.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblUnitPrice.Location = new System.Drawing.Point(432, 479);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(100, 23);
            this.lblUnitPrice.TabIndex = 27;
            this.lblUnitPrice.Text = "Unit Price";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.BackColor = System.Drawing.Color.Transparent;
            this.lblQuantity.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblQuantity.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblQuantity.Location = new System.Drawing.Point(432, 512);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(93, 23);
            this.lblQuantity.TabIndex = 28;
            this.lblQuantity.Text = "Quantity";
            // 
            // lblMaxQuantity
            // 
            this.lblMaxQuantity.AutoSize = true;
            this.lblMaxQuantity.BackColor = System.Drawing.Color.Transparent;
            this.lblMaxQuantity.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMaxQuantity.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblMaxQuantity.Location = new System.Drawing.Point(432, 545);
            this.lblMaxQuantity.Name = "lblMaxQuantity";
            this.lblMaxQuantity.Size = new System.Drawing.Size(196, 23);
            this.lblMaxQuantity.TabIndex = 29;
            this.lblMaxQuantity.Text = "Maximum Quantity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Location = new System.Drawing.Point(432, 578);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 23);
            this.label7.TabIndex = 30;
            this.label7.Text = "Dealer Name";
            // 
            // lblVendingMachineId
            // 
            this.lblVendingMachineId.AutoSize = true;
            this.lblVendingMachineId.BackColor = System.Drawing.Color.Transparent;
            this.lblVendingMachineId.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblVendingMachineId.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblVendingMachineId.Location = new System.Drawing.Point(434, 611);
            this.lblVendingMachineId.Name = "lblVendingMachineId";
            this.lblVendingMachineId.Size = new System.Drawing.Size(209, 23);
            this.lblVendingMachineId.TabIndex = 31;
            this.lblVendingMachineId.Text = "Vending Machine Id";
            // 
            // txtFoodName
            // 
            this.txtFoodName.Location = new System.Drawing.Point(651, 409);
            this.txtFoodName.Name = "txtFoodName";
            this.txtFoodName.Size = new System.Drawing.Size(125, 27);
            this.txtFoodName.TabIndex = 32;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(651, 442);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(125, 27);
            this.txtDescription.TabIndex = 33;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(651, 475);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(125, 27);
            this.txtUnitPrice.TabIndex = 34;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(651, 508);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(125, 27);
            this.txtQuantity.TabIndex = 35;
            // 
            // txtMaxQuantity
            // 
            this.txtMaxQuantity.Location = new System.Drawing.Point(651, 541);
            this.txtMaxQuantity.Name = "txtMaxQuantity";
            this.txtMaxQuantity.Size = new System.Drawing.Size(125, 27);
            this.txtMaxQuantity.TabIndex = 36;
            // 
            // comboBoxDealerId
            // 
            this.comboBoxDealerId.FormattingEnabled = true;
            this.comboBoxDealerId.Location = new System.Drawing.Point(651, 573);
            this.comboBoxDealerId.Name = "comboBoxDealerId";
            this.comboBoxDealerId.Size = new System.Drawing.Size(125, 28);
            this.comboBoxDealerId.TabIndex = 37;
            // 
            // comboBoxVendingMachineId
            // 
            this.comboBoxVendingMachineId.FormattingEnabled = true;
            this.comboBoxVendingMachineId.Location = new System.Drawing.Point(651, 607);
            this.comboBoxVendingMachineId.Name = "comboBoxVendingMachineId";
            this.comboBoxVendingMachineId.Size = new System.Drawing.Size(125, 28);
            this.comboBoxVendingMachineId.TabIndex = 38;
            // 
            // btnCheckCS
            // 
            this.btnCheckCS.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCheckCS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckCS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCheckCS.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCheckCS.ForeColor = System.Drawing.Color.White;
            this.btnCheckCS.Location = new System.Drawing.Point(22, 362);
            this.btnCheckCS.Name = "btnCheckCS";
            this.btnCheckCS.Size = new System.Drawing.Size(292, 29);
            this.btnCheckCS.TabIndex = 39;
            this.btnCheckCS.Text = "Check Available Court Sections";
            this.btnCheckCS.UseVisualStyleBackColor = false;
            this.btnCheckCS.Click += new System.EventHandler(this.btnCheckCS_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(347, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(362, 44);
            this.label2.TabIndex = 40;
            this.label2.Text = "Food Management";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Firebrick;
            this.label3.Location = new System.Drawing.Point(57, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 27);
            this.label3.TabIndex = 41;
            this.label3.Text = "Vending Machines";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Firebrick;
            this.label4.Location = new System.Drawing.Point(509, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 27);
            this.label4.TabIndex = 42;
            this.label4.Text = "Dealers";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Firebrick;
            this.label5.Location = new System.Drawing.Point(178, 394);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 27);
            this.label5.TabIndex = 43;
            this.label5.Text = "Foods";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picBoxBack
            // 
            this.picBoxBack.BackColor = System.Drawing.Color.Transparent;
            this.picBoxBack.Image = ((System.Drawing.Image)(resources.GetObject("picBoxBack.Image")));
            this.picBoxBack.Location = new System.Drawing.Point(1079, 12);
            this.picBoxBack.Name = "picBoxBack";
            this.picBoxBack.Size = new System.Drawing.Size(47, 44);
            this.picBoxBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxBack.TabIndex = 45;
            this.picBoxBack.TabStop = false;
            this.picBoxBack.Click += new System.EventHandler(this.picBoxBack_Click);
            // 
            // picBoxExit
            // 
            this.picBoxExit.BackColor = System.Drawing.Color.Transparent;
            this.picBoxExit.Image = ((System.Drawing.Image)(resources.GetObject("picBoxExit.Image")));
            this.picBoxExit.Location = new System.Drawing.Point(1132, 12);
            this.picBoxExit.Name = "picBoxExit";
            this.picBoxExit.Size = new System.Drawing.Size(47, 44);
            this.picBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxExit.TabIndex = 44;
            this.picBoxExit.TabStop = false;
            this.picBoxExit.Click += new System.EventHandler(this.picBoxExit_Click);
            // 
            // Food
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Auto_Court.Properties.Resources.Design_4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1191, 642);
            this.Controls.Add(this.picBoxBack);
            this.Controls.Add(this.picBoxExit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCheckCS);
            this.Controls.Add(this.comboBoxVendingMachineId);
            this.Controls.Add(this.comboBoxDealerId);
            this.Controls.Add(this.txtMaxQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtFoodName);
            this.Controls.Add(this.lblVendingMachineId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblMaxQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblUnitPrice);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblFoodName);
            this.Controls.Add(this.btnResetFood);
            this.Controls.Add(this.btnDeleteFood);
            this.Controls.Add(this.btnUpdateFood);
            this.Controls.Add(this.btnAddFood);
            this.Controls.Add(this.btnResetDealer);
            this.Controls.Add(this.btnDeleteDealer);
            this.Controls.Add(this.btnUpdateDealer);
            this.Controls.Add(this.btnAddDealer);
            this.Controls.Add(this.txtMarginOfProfit);
            this.Controls.Add(this.txtContactInfo);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtDealerName);
            this.Controls.Add(this.lblMarginOfProfit);
            this.Controls.Add(this.lblContactInfo);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblDealerName);
            this.Controls.Add(this.btnResetVendingMachine);
            this.Controls.Add(this.btnDeleteVendingMachine);
            this.Controls.Add(this.btnUpdateVendingMachine);
            this.Controls.Add(this.btnAddVendingMachine);
            this.Controls.Add(this.comboBoxCourtSectionId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvFood);
            this.Controls.Add(this.dgvDealer);
            this.Controls.Add(this.dgvVendingMachine);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Food";
            this.Text = "Food";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendingMachine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDealer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFood)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVendingMachine;
        private System.Windows.Forms.DataGridView dgvDealer;
        private System.Windows.Forms.DataGridView dgvFood;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCourtSectionId;
        private System.Windows.Forms.Button btnAddVendingMachine;
        private System.Windows.Forms.Button btnUpdateVendingMachine;
        private System.Windows.Forms.Button btnDeleteVendingMachine;
        private System.Windows.Forms.Button btnResetVendingMachine;
        private System.Windows.Forms.Label lblDealerName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblContactInfo;
        private System.Windows.Forms.Label lblMarginOfProfit;
        private System.Windows.Forms.TextBox txtDealerName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtContactInfo;
        private System.Windows.Forms.TextBox txtMarginOfProfit;
        private System.Windows.Forms.Button btnAddDealer;
        private System.Windows.Forms.Button btnUpdateDealer;
        private System.Windows.Forms.Button btnDeleteDealer;
        private System.Windows.Forms.Button btnResetDealer;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.Button btnUpdateFood;
        private System.Windows.Forms.Button btnDeleteFood;
        private System.Windows.Forms.Button btnResetFood;
        private System.Windows.Forms.Label lblFoodName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblMaxQuantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblVendingMachineId;
        private System.Windows.Forms.TextBox txtFoodName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtMaxQuantity;
        private System.Windows.Forms.ComboBox comboBoxDealerId;
        private System.Windows.Forms.ComboBox comboBoxVendingMachineId;
        private System.Windows.Forms.Button btnCheckCS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picBoxBack;
        private System.Windows.Forms.PictureBox picBoxExit;
    }
}