namespace GasTracker
{
    partial class GasListEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GasListEditor));
            this.labelRpc = new System.Windows.Forms.Label();
            this.checkBoxAlert = new System.Windows.Forms.CheckBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelColor = new System.Windows.Forms.Label();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxRpc = new System.Windows.Forms.TextBox();
            this.labelThreshold = new System.Windows.Forms.Label();
            this.numericUpDownThreshold = new System.Windows.Forms.NumericUpDown();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRpc
            // 
            this.labelRpc.AutoSize = true;
            this.labelRpc.Location = new System.Drawing.Point(14, 47);
            this.labelRpc.Margin = new System.Windows.Forms.Padding(5);
            this.labelRpc.Name = "labelRpc";
            this.labelRpc.Padding = new System.Windows.Forms.Padding(5);
            this.labelRpc.Size = new System.Drawing.Size(37, 23);
            this.labelRpc.TabIndex = 0;
            this.labelRpc.Text = "Rpc";
            // 
            // checkBoxAlert
            // 
            this.checkBoxAlert.AutoSize = true;
            this.checkBoxAlert.Location = new System.Drawing.Point(14, 113);
            this.checkBoxAlert.Margin = new System.Windows.Forms.Padding(5);
            this.checkBoxAlert.Name = "checkBoxAlert";
            this.checkBoxAlert.Padding = new System.Windows.Forms.Padding(5);
            this.checkBoxAlert.Size = new System.Drawing.Size(57, 27);
            this.checkBoxAlert.TabIndex = 1;
            this.checkBoxAlert.Text = "Alert";
            this.checkBoxAlert.UseVisualStyleBackColor = true;
            this.checkBoxAlert.CheckedChanged += new System.EventHandler(this.checkBoxAlert_CheckedChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(65, 17);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(150, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Location = new System.Drawing.Point(14, 80);
            this.labelColor.Margin = new System.Windows.Forms.Padding(5);
            this.labelColor.Name = "labelColor";
            this.labelColor.Padding = new System.Windows.Forms.Padding(5);
            this.labelColor.Size = new System.Drawing.Size(41, 23);
            this.labelColor.TabIndex = 3;
            this.labelColor.Text = "Color";
            // 
            // comboBoxColor
            // 
            this.comboBoxColor.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Items.AddRange(new object[] {
            "White",
            "Black",
            "Blue",
            "Yellow",
            "Purple",
            "Green"});
            this.comboBoxColor.Location = new System.Drawing.Point(65, 82);
            this.comboBoxColor.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(150, 21);
            this.comboBoxColor.TabIndex = 4;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(14, 14);
            this.labelName.Margin = new System.Windows.Forms.Padding(5);
            this.labelName.Name = "labelName";
            this.labelName.Padding = new System.Windows.Forms.Padding(5);
            this.labelName.Size = new System.Drawing.Size(45, 23);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Name";
            // 
            // textBoxRpc
            // 
            this.textBoxRpc.Location = new System.Drawing.Point(65, 50);
            this.textBoxRpc.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxRpc.Name = "textBoxRpc";
            this.textBoxRpc.Size = new System.Drawing.Size(150, 20);
            this.textBoxRpc.TabIndex = 6;
            // 
            // labelThreshold
            // 
            this.labelThreshold.AutoSize = true;
            this.labelThreshold.Location = new System.Drawing.Point(14, 150);
            this.labelThreshold.Margin = new System.Windows.Forms.Padding(5);
            this.labelThreshold.Name = "labelThreshold";
            this.labelThreshold.Padding = new System.Windows.Forms.Padding(5);
            this.labelThreshold.Size = new System.Drawing.Size(64, 23);
            this.labelThreshold.TabIndex = 7;
            this.labelThreshold.Text = "Threshold";
            // 
            // numericUpDownThreshold
            // 
            this.numericUpDownThreshold.Enabled = false;
            this.numericUpDownThreshold.Location = new System.Drawing.Point(88, 153);
            this.numericUpDownThreshold.Margin = new System.Windows.Forms.Padding(5);
            this.numericUpDownThreshold.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownThreshold.Name = "numericUpDownThreshold";
            this.numericUpDownThreshold.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownThreshold.TabIndex = 8;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(32, 183);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 30);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(126, 183);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(80, 30);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // GasListEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 231);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.numericUpDownThreshold);
            this.Controls.Add(this.labelThreshold);
            this.Controls.Add(this.textBoxRpc);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.comboBoxColor);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.checkBoxAlert);
            this.Controls.Add(this.labelRpc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GasListEditor";
            this.ShowInTaskbar = false;
            this.Text = "GasListEditor";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRpc;
        private System.Windows.Forms.CheckBox checkBoxAlert;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.ComboBox comboBoxColor;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxRpc;
        private System.Windows.Forms.Label labelThreshold;
        private System.Windows.Forms.NumericUpDown numericUpDownThreshold;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}