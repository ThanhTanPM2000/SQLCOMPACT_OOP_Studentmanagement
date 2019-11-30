using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_student_class_management2.StudentManagement
{
    class LogicLayer
    {
        public Student[] GetStudents()
        {
            var db = new thanhtanpmEntities();
            return db.Students.ToArray();
        }
        public Student GetStudent(int id)
        {
            var db = new thanhtanpmEntities();
            var dataStudent = db.Students.Find(id);
            return dataStudent;
        }
        public void CreateStudent(string code, string name, DateTime birthday, int classid)
        {
            var st = new Student();
            st.Code = code;
            st.Name = name;
            st.Birthday = birthday;
            st.Class_id = classid;

            var db = new thanhtanpmEntities();
            db.Students.Add(st);
            db.SaveChanges();
        }
        public void UpdateStudent(int id, string name, DateTime birthday, int classid)
        {
            var db = new thanhtanpmEntities();
            var st = db.Students.Find(id);
            st.Name = name;
            st.Birthday = birthday;
            st.Class_id = classid;

            db.Entry(st).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteStudent(int id)
        {
            var db = new thanhtanpmEntities();
            var st = db.Students.Find(id);
            db.Students.Remove(st);
            db.SaveChanges();
        }
        public Class[] GetClasses()
        {
            var db = new thanhtanpmEntities();
            return db.Classes.ToArray();
        }
    }
}
