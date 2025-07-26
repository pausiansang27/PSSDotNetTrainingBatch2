using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using PSSDotNetTrainingBatch2.WinFormsApp1.Database.AppDbContextModels;
using System.Xml.Linq;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace PSSDotNetTrainingBatch2.WinFormsApp1
{
    public partial class FrmStaff : Form
    {
        private readonly AppDbContext _db;
        private int _editId;
        public FrmStaff()
        {
            InitializeComponent();
            _db = new AppDbContext();
            dgvData.AutoGenerateColumns = false;
        }

        private void BindData()
        {
            try
            {
                dgvData.DataSource = _db.TblStaffs.ToList();
            }
            catch (Exception ex)
            {

            }
        }

        private void FrmStaff_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    #region --- Save Staff operation ---
                    txtPassword.Text = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
                    _db.TblStaffs.Add(new TblStaff
                    {
                        StaffCode = txtStaffCode.Text.Trim(),
                        StaffName = txtStaffName.Text.Trim(),
                        EmailAddress = txtEmail.Text.Trim(),
                        Password = txtPassword.Text.Trim(),
                        Position = cboPosition.Text.Trim(),
                        MobileNo = txtMobileNo.Text.Trim(),
                        IsDelete = false
                    });
                    int result = _db.SaveChanges();
                    string messageStr = result > 0 ? "Staff saved successfully!" : "Failed to save staff.";
                    MessageBox.Show(messageStr, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Jack Sparrow", "paungshinsan27@gmail.com"));
                    message.To.Add(new MailboxAddress(txtStaffName.Text.Trim(), txtEmail.Text.Trim()));
                    message.Subject = "Mini POS - User Creation";

                    string body = $@"Your Staff Code is {txtStaffCode.Text.Trim()}.
Your password is {txtPassword.Text}.";

                    message.Body = new TextPart("plain")
                    {
                        Text = body
                    };

                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                        // Note: only needed if the SMTP server requires authentication
                        client.Authenticate("paungshinsan27@gmail.com", "dbbb jqen vsrg odor");
                        client.Send(message);
                        client.Disconnect(true);
                    }

                    txtStaffCode.Clear();
                    txtEmail.Clear();
                    txtMobileNo.Clear();
                    txtPassword.Clear();
                    cboPosition.Text = "";
                    txtStaffName.Clear();
                    txtStaffCode.Focus();
                    BindData();
                    #endregion
                }
                else
                {
                    #region --- Update Staff operation ---
                    TblStaff? staffData = _db.TblStaffs.FirstOrDefault(x => x.StaffId == _editId && x.IsDelete == false);
                    if (staffData == null) return;

                    staffData.StaffCode = txtStaffCode.Text.Trim();
                    staffData.StaffName = txtStaffName.Text.Trim();
                    staffData.EmailAddress = txtEmail.Text.Trim();
                    staffData.Password = txtPassword.Text.Trim();
                    staffData.Position = cboPosition.Text.Trim();
                    staffData.MobileNo = txtMobileNo.Text.Trim();
                    int result = _db.SaveChanges();
                    string message = result > 0 ? "Update Successful." : "Update Failed.";
                    MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtStaffCode.Clear();
                    txtStaffName.Clear();
                    txtEmail.Clear();
                    txtPassword.Clear();
                    cboPosition.Text = "";
                    txtMobileNo.Clear();
                    txtStaffCode.Focus();
                    _editId = 0;
                    btnSave.Text = "Save";
                    txtStaffCode.Focus();
                    BindData();
                    #endregion
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            if (e.ColumnIndex == dgvData.Columns["colEdit"].Index)
            {
                int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value.ToString()!);
                var item = _db.TblStaffs.FirstOrDefault(x => x.StaffId == id);
                if (item is null) return;

                txtStaffCode.Text = item.StaffCode;
                txtStaffName.Text = item.StaffName;
                txtEmail.Text = item.EmailAddress;
                txtPassword.Text = item.Password;
                cboPosition.Text = item.Position;
                txtMobileNo.Text = item.MobileNo;
                _editId = id;
                btnSave.Text = "Update";
            }
            if (e.ColumnIndex == dgvData.Columns["colDelete"].Index)
            {
                var confirm = MessageBox.Show("Are you sure want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.No) return;
                int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value.ToString()!);
                var item = _db.TblStaffs.FirstOrDefault(x => x.StaffId == id);
                if (item is null) return;
                _db.TblStaffs.Remove(item);
                int result = _db.SaveChanges();
                string message = result > 0 ? "Staff deleted successfully!" : "Deleting Staff failed.";
                MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindData();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStaffCode.Clear();
            txtStaffName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            cboPosition.Text = "";
            txtMobileNo.Clear();
            txtStaffCode.Focus();
            btnSave.Text = "Save";
            txtStaffCode.Focus();
        }
    }
}
