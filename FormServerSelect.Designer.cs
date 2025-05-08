namespace VideoGameCollection_WinForms
{
    partial class FormServerSelect
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
            grpbxServers = new GroupBox();
            rdbtnLocal = new RadioButton();
            rdbtnNetwork = new RadioButton();
            btnOk = new Button();
            grpbxServers.SuspendLayout();
            SuspendLayout();
            // 
            // grpbxServers
            // 
            grpbxServers.Controls.Add(rdbtnLocal);
            grpbxServers.Controls.Add(rdbtnNetwork);
            grpbxServers.Location = new Point(35, 30);
            grpbxServers.Name = "grpbxServers";
            grpbxServers.Size = new Size(152, 91);
            grpbxServers.TabIndex = 1;
            grpbxServers.TabStop = false;
            // 
            // rdbtnLocal
            // 
            rdbtnLocal.AutoSize = true;
            rdbtnLocal.Location = new Point(34, 52);
            rdbtnLocal.Name = "rdbtnLocal";
            rdbtnLocal.Size = new Size(53, 19);
            rdbtnLocal.TabIndex = 1;
            rdbtnLocal.TabStop = true;
            rdbtnLocal.Text = "Local";
            rdbtnLocal.UseVisualStyleBackColor = true;
            // 
            // rdbtnNetwork
            // 
            rdbtnNetwork.AutoSize = true;
            rdbtnNetwork.Checked = true;
            rdbtnNetwork.Location = new Point(34, 27);
            rdbtnNetwork.Name = "rdbtnNetwork";
            rdbtnNetwork.Size = new Size(70, 19);
            rdbtnNetwork.TabIndex = 0;
            rdbtnNetwork.TabStop = true;
            rdbtnNetwork.Text = "Network";
            rdbtnNetwork.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(74, 127);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // FormServerSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(225, 182);
            Controls.Add(btnOk);
            Controls.Add(grpbxServers);
            MaximizeBox = false;
            MaximumSize = new Size(241, 221);
            MinimizeBox = false;
            MinimumSize = new Size(241, 221);
            Name = "FormServerSelect";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Select Server";
            grpbxServers.ResumeLayout(false);
            grpbxServers.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpbxServers;
        private RadioButton rdbtnLocal;
        private RadioButton rdbtnNetwork;
        private Button btnOk;
    }
}