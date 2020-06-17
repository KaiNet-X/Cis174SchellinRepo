using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCentral.Areas.Assignment6._1.Models
{
    public class StudentViewModel
    {
        public StudentViewModel(byte AccessLevel)
        {
            this.AccessLevel = AccessLevel;
        }
        private static List<StudentModel> students = new List<StudentModel>()
        {
            new StudentModel { FirstName = "James", LastName = "Espinoza", Grade = 'D'},
            new StudentModel { FirstName = "Abby", LastName = "Smith", Grade = 'C'},
            new StudentModel { FirstName = "Carrie", LastName = "Marrie", Grade = 'A'}
        };
        public List<StudentModel> Students { get { return students; } }
        public byte AccessLevel { get; set; }
    }
}
