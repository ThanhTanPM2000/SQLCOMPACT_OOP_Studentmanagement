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
    public partial class IndexForm : Form
    {
        private LogicLayer Business;
        public IndexForm()
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.Load += IndexForm_Load;
            this.btnCreate.Click += BtnCreate_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.grdStudent.DoubleClick += GrdStudent_DoubleClick;
        }
        private void LoadAllForm()
        {
            var students = this.Business.GetStudents();
            var studentview = new StudentView[students.Length];
            for (int i = 0; i < studentview.Length; i++)
            {
                studentview[i] = new StudentView(students[i]);
            }
            this.grdStudent.DataSource = studentview;
        }
        private void GrdStudent_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdStudent.SelectedRows.Count == 1)
            {
                var stview = (StudentView)grdStudent.SelectedRows[0].DataBoundItem;
                (new UpdateForm(stview.Id)).ShowDialog();
                LoadAllForm();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(this.grdStudent.SelectedRows.Count == 1)
            {
                var stview = (StudentView)grdStudent.SelectedRows[0].DataBoundItem;
                this.Business.DeleteStudent(stview.Id);
                LoadAllForm();
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var CreateSt = new CreateForm();
            CreateSt.ShowDialog();
            this.LoadAllForm();
        }

        private void IndexForm_Load(object sender, EventArgs e)
        {
            LoadAllForm();
        }
    }
}
