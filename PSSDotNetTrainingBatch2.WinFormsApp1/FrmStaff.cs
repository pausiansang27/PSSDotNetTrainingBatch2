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
                string message = result > 0 ? "Staff saved successfully!" : "Failed to save staff.";
                MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtStaffCode.Clear();
                txtEmail.Clear();
                txtMobileNo.Clear();
                txtPassword.Clear();
                cboPosition.Text = "";
                txtStaffName.Clear();
                txtStaffCode.Focus();

                BindData();
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

    }
}
