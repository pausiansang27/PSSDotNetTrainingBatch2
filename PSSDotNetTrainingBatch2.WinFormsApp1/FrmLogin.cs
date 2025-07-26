using PSSDotNetTrainingBatch2.WinFormsApp1.Database.AppDbContextModels;

namespace PSSDotNetTrainingBatch2.WinFormsApp1
{
    public partial class FrmLogin : Form
    {
        private readonly AppDbContext _db;
        public FrmLogin()
        {
            InitializeComponent();
            _db = new AppDbContext();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string staffCode = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            var item = _db.TblStaffs.FirstOrDefault(x => x.StaffCode == staffCode && x.Password == password);
            if (item == null)
            {
                MessageBox.Show("Username or Password was wrong!", "Authentication Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Hide();
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.ShowDialog();
            this.Show();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
