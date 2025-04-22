namespace VideoGameCollection_WinForms
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnDebug = new Button();
            SuspendLayout();
            // 
            // btnDebug
            // 
            btnDebug.Location = new Point(358, 330);
            btnDebug.Name = "btnDebug";
            btnDebug.Size = new Size(75, 23);
            btnDebug.TabIndex = 0;
            btnDebug.Text = "Debug";
            btnDebug.UseVisualStyleBackColor = true;
            btnDebug.Click += btnDebug_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDebug);
            Name = "FormMain";
            Text = "Video Game Catalog";
            ResumeLayout(false);
        }

        #endregion

        private Button btnDebug;
    }
}
