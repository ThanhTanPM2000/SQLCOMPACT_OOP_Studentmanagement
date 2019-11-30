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
    public partial class CreateForm : Form
    {
        private LogicLayer Business;
        public CreateForm()
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.Load += CreateForm_Load;
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {
            this.cbClass.DataSource = this.Business.GetClasses();
            this.cbClass.DisplayMember = "Name";
            this.cbClass.ValueMember = "Id";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var code = this.txtCode.Text;
            var name = this.txtName.Text;
            var birthday = this.dtpBirthday.Value;
            var classid = (int)this.cbClass.SelectedValue;
            this.Business.CreateStudent(code, name, birthday, classid);
            MessageBox.Show("Create student successfully !!");
            this.Close();
        }
    }
}
