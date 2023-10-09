using Dapper;
using DataAccess.Data;
using DataAccess.DbAccess;
using DataAccess.Models;
using System.Data;
using System.Diagnostics;

namespace AsynchronousDapper
{
    public partial class FormAsync : Form
    {
        private bool _isNew = false;
        private readonly IUserData _data;

        public FormAsync()
        {
            InitializeComponent();

            // dataGridView 컬럼 중복 추가 방지
            // AutoGenerateColumns의 기본값이 true이다.
            // 그러므로, Form 디자이너에서 컬럼을 추가한 후
            // 1) DataSource 셋팅을 런타임에서 하면 기본값이 true이므로 자동으로 컬럼이 추가된다. => 이를 방지하기 위해서 false로 바꿔준다.
            // 2) DataSource 셋팅을 Form 디자이너에서 하면 AutoGenerateColumns = false;로 자동으로 되므로 필요없다.
            dataGridView.AutoGenerateColumns = false;
            _data = new UserData(new SqlDataAccess());
        }

        private async void LoadDataGridView()
        {
            dataGridView.DataSource = await _data.GetUsersAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell != null)
            {
                var row = dataGridView.CurrentCell.RowIndex;

                idTextBox.Text = dataGridView.Rows[row].Cells[0].Value.ToString();
                firstNameTextBox.Text = dataGridView.Rows[row].Cells[1].Value.ToString();
                lastNameTextBox.Text = dataGridView.Rows[row].Cells[2].Value.ToString();
                _isNew = false;
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            idTextBox.Text = string.Empty;
            firstNameTextBox.Text = string.Empty;
            lastNameTextBox.Text = string.Empty;
            _isNew = true;
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idTextBox.Text))
            {
                try
                {
                    await _data.DeleteUserAsync(Convert.ToInt32(idTextBox.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류가 발생하였습니다." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                _isNew = false;
                LoadDataGridView();
            }
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            int? currentId = null;
            try
            {
                if (_isNew)
                    currentId = await _data.InsertUser_GetIdAsync(new UserModel { FirstName = firstNameTextBox.Text, LastName = lastNameTextBox.Text });
                else
                    await _data.UpdateUserAsync(new UserModel { Id = Convert.ToInt32(idTextBox.Text), FirstName = firstNameTextBox.Text, LastName = lastNameTextBox.Text });
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류가 발생하였습니다." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _isNew = false;
            LoadDataGridView();

            Debug.WriteLine(currentId);
        }

        private void showFormSyncbutton_Click(object sender, EventArgs e)
        {
            FormSync formSync = new FormSync();
            formSync.ShowDialog();
        }
    }
}