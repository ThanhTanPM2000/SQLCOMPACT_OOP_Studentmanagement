using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_student_class_management2.StudentManagement
{
    public partial class UpdateForm : Form
    {
        private LogicLayer Business;
        private int MyID;
        public UpdateForm(int id)
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            MyID = id;
            this.Load += UpdateForm_Load;
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var Name = txtName.Text;
            var Birthday = dtpBirthday.Value;
            var ClassID = (int)cbClass.SelectedValue;
            this.Business.UpdateStudent(this.MyID, Name, Birthday, ClassID);
            MessageBox.Show("Update successfully");
            this.Close();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            var student = this.Business.GetStudent(MyID);
            txtCode.Text = student.Code;
            txtName.Text = student.Name;
            dtpBirthday.Value = student.Birthday;
            this.cbClass.DataSource = this.Business.GetClasses();
            this.cbClass.DisplayMember = "Name";
            this.cbClass.ValueMember = "ID";
            this.cbClass.SelectedValue = student.Class_id;

        }
    }
}
