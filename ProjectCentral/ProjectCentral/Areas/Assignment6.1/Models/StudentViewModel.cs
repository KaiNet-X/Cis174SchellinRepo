using System.Collections.Generic;

namespace ProjectCentral.Areas.Assignment6._1.Models
{
    public class StudentViewModel
    {
        //constructor sets the accesslevel to be used in the view
        public StudentViewModel(byte AccessLevel)
        {
            this.AccessLevel = AccessLevel;
        }
        //creates static list of students, doesnt need to use database
        private static List<StudentModel> students = new List<StudentModel>()
        {
            new StudentModel { FirstName = "James", LastName = "Espinoza", Grade = 'D'},
            new StudentModel { FirstName = "Abby", LastName = "Smith", Grade = 'C'},
            new StudentModel { FirstName = "Carrie", LastName = "Marrie", Grade = 'A'}
        };
        //access the static list of students from instance
        public List<StudentModel> Students { get { return students; } }
        //holds accesslevel value
        public byte AccessLevel { get; set; }
    }
}
