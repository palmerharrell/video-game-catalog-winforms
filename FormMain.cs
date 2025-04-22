namespace VideoGameCollection_WinForms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            MainDebugger.MainDebug();
        }
    }
}
