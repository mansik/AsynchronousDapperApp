using AsynchronousDapper.DataAccess.Data;
using AsynchronousDapper.DataAccess.DbAccess;
using AsynchronousDapper.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsynchronousDapper
{
    public partial class FormSync : Form
    {
        private bool _isNew = false;
        private readonly IUserData _data;

        public FormSync()
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

        private void LoadDataGridView()
        {
            dataGridView.DataSource = _data.GetUsers();
        }
        private void FormSync_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idTextBox.Text))
            {
                bool isComplete = false;
                try
                {
                    isComplete = _data.DeleteUser(Convert.ToInt32(idTextBox.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류가 발생하였습니다." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (isComplete)
                {
                    _isNew = false;
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("삭제 되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            int? currentId = null;
            bool isComplete = false;

            try
            {
                if (_isNew)
                    currentId = _data.InsertUser_GetId(new UserModel { FirstName = firstNameTextBox.Text, LastName = lastNameTextBox.Text });
                else
                    isComplete = _data.UpdateUser(new UserModel { Id = Convert.ToInt32(idTextBox.Text), FirstName = firstNameTextBox.Text, LastName = lastNameTextBox.Text });
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류가 발생하였습니다." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (currentId > 0 || isComplete)
            {
                _isNew = false;
                LoadDataGridView();
            }
            else
            {
                MessageBox.Show("저장이 되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Debug.WriteLine(currentId);
        }

    }
}
