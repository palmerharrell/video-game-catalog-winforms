namespace VideoGameCollection_WinForms
{
    partial class FormBarcodeScanner
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
            lblInstructions = new Label();
            lblStatus = new Label();
            chkbxAutoAdd = new CheckBox();
            grpBxStatus = new GroupBox();
            btnStopScanning = new Button();
            grpBxStatus.SuspendLayout();
            SuspendLayout();
            // 
            // lblInstructions
            // 
            lblInstructions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblInstructions.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInstructions.Location = new Point(96, 19);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(240, 115);
            lblInstructions.TabIndex = 0;
            lblInstructions.Text = "Scan a game case barcode to add game to the catalog.";
            lblInstructions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = SystemColors.ControlDark;
            lblStatus.Location = new Point(6, 19);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(399, 56);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Scan a game...";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chkbxAutoAdd
            // 
            chkbxAutoAdd.AutoSize = true;
            chkbxAutoAdd.Location = new Point(12, 310);
            chkbxAutoAdd.Name = "chkbxAutoAdd";
            chkbxAutoAdd.Size = new Size(178, 19);
            chkbxAutoAdd.TabIndex = 2;
            chkbxAutoAdd.Text = "Auto-add on successful scan";
            chkbxAutoAdd.UseVisualStyleBackColor = true;
            // 
            // grpBxStatus
            // 
            grpBxStatus.Controls.Add(lblStatus);
            grpBxStatus.Location = new Point(12, 165);
            grpBxStatus.Name = "grpBxStatus";
            grpBxStatus.Size = new Size(411, 78);
            grpBxStatus.TabIndex = 3;
            grpBxStatus.TabStop = false;
            grpBxStatus.Text = "Status";
            // 
            // btnStopScanning
            // 
            btnStopScanning.Location = new Point(326, 307);
            btnStopScanning.Name = "btnStopScanning";
            btnStopScanning.Size = new Size(97, 23);
            btnStopScanning.TabIndex = 4;
            btnStopScanning.Text = "Stop Scanning";
            btnStopScanning.UseVisualStyleBackColor = true;
            btnStopScanning.Click += btnStopScanning_Click;
            // 
            // FormBarcodeScanner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 342);
            Controls.Add(btnStopScanning);
            Controls.Add(grpBxStatus);
            Controls.Add(chkbxAutoAdd);
            Controls.Add(lblInstructions);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormBarcodeScanner";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Barcode Scanner";
            TopMost = true;
            grpBxStatus.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInstructions;
        private Label lblStatus;
        private CheckBox chkbxAutoAdd;
        private GroupBox grpBxStatus;
        private Button btnStopScanning;
    }
}