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

            // dataGridView �÷� �ߺ� �߰� ����
            // AutoGenerateColumns�� �⺻���� true�̴�.
            // �׷��Ƿ�, Form �����̳ʿ��� �÷��� �߰��� ��
            // 1) DataSource ������ ��Ÿ�ӿ��� �ϸ� �⺻���� true�̹Ƿ� �ڵ����� �÷��� �߰��ȴ�. => �̸� �����ϱ� ���ؼ� false�� �ٲ��ش�.
            // 2) DataSource ������ Form �����̳ʿ��� �ϸ� AutoGenerateColumns = false;�� �ڵ����� �ǹǷ� �ʿ����.
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
                    MessageBox.Show("������ �߻��Ͽ����ϴ�." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("������ �߻��Ͽ����ϴ�." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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