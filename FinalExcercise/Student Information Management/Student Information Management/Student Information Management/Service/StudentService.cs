
using Student_Information_Management.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Student_Information_Management.ViewModel
{
    public class StudentService
    {
        private List<Student> _data;
        public StudentService()
        {
            _data = LoadDataFromXml().Students;
        }

        private static Dataset LoadDataFromXml()
        {
            XmlSerializer reader = new XmlSerializer(typeof(Dataset));
            StreamReader file = new StreamReader(@"F:\18DTHQA1-master\wpf-practice-03\student_sample_data.xml");

            Dataset data = (Dataset)reader.Deserialize(file);
            file.Close();
            return data;
        }

        public Student Add(Student student)
        {
            _data.Add(student);
            return student;
        }

        public List<String> GetAllClasses()
        {

            return _data.OrderBy(m => m.Class).Select(m => m.Class).Distinct().ToList();
        }

        public void Remove(int studentId)
        {
            var removedStudent = _data.FirstOrDefault(s => s.Id == studentId);


           _data.Remove(removedStudent);

        }

        public List<Student> SearchStudent(StudentSearchCriteria criteria)
        {
             
            return _data.Where(s => string.IsNullOrEmpty(criteria.SearchText) ||
                s.StudentId.ToString().Contains(criteria.SearchText) ||
                s.FirstName.ToString().Contains(criteria.SearchText) ||
                s.LastName.ToString().Contains(criteria.SearchText)
                &&
                (string.IsNullOrEmpty(criteria.ClassName)||
                s.Class.Contains(criteria.ClassName))
                ).ToList();
            
        }

        public Student Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}