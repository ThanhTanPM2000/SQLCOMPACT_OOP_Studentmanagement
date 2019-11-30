using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_student_class_management2.StudentManagement
{
    class StudentView
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Class { get; set; }
        public StudentView(Student student)
        {
            this.Id = student.ID;
            this.Code = student.Code;
            this.Name = student.Name;
            this.Birthday = student.Birthday;
            this.Class = student.Class.Name;

        }
    }
}
