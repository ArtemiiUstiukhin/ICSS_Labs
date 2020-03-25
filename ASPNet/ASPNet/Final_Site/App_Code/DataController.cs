using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Linq;

public class CourseModel
{
    public int CourseID { get; set; }
    public string Title { get; set; }
    public int Credit { get; set; }
    public CourseModel(int id, string title, int credit)
    {
        CourseID = id;
        Title = title;
        Credit = credit;
    }

}

public class StudentModel
{
    public int StudentID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public StudentModel(int id, string firstName, string lastName)
    {
        StudentID = id;
        FirstName = firstName;
        LastName = lastName;
    }

}
public class DataController
{
    DataContext db;
    public DataController()
    {
        db = new DataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=School;Integrated Security=True");
    }

    public List<CourseModel> getAllCourses()
    {
        var res = from c in db.GetTable<Course>()
                  select c;

        List<CourseModel> courses = new List<CourseModel>();
        foreach (var c in res)
            courses.Add(new CourseModel(c.CourseID, c.Title, c.Credits));

        return courses;
    }

    public void enrollStudentToCourse(int courseID, string lastName, string firstName, int grade)
    {
        Table<Person> tablePerson = db.GetTable<Person>();

        Person person = new Person();
        person.LastName = lastName;
        person.FirstName = firstName;
        person.HireDate = null;
        person.EnrollmentDate = DateTime.Now;

        tablePerson.InsertOnSubmit(person);
        db.SubmitChanges();

        Table<StudentGrade> studentGradePerson = db.GetTable<StudentGrade>();

        StudentGrade studentGrade = new StudentGrade();
        studentGrade.CourseID = courseID;
        studentGrade.StudentID = person.PersonID;
        studentGrade.Grade = grade;

        studentGradePerson.InsertOnSubmit(studentGrade);
        db.SubmitChanges();
    }

    public List<StudentModel> getStudentsByCourseID(int courseID)
    {
        var res = from p in db.GetTable<Person>()
                  from s in db.GetTable<StudentGrade>()
                  where s.CourseID == courseID && 
                        s.StudentID == p.PersonID
                  select p;

        List<StudentModel> students = new List<StudentModel>();
        foreach (var s in res)
            students.Add(new StudentModel(s.PersonID, s.FirstName, s.LastName));

        return students;
    }

    public void removeStudentFromCourse(int studentID, int courseID)
    {
        Table<StudentGrade> tableStudentGrade = db.GetTable<StudentGrade>();

        var grades = from g in tableStudentGrade
                     where g.CourseID == courseID && g.StudentID == studentID
                     select g;

        if (grades.Count() > 0)
        {
            StudentGrade s = (StudentGrade) grades.First();
            tableStudentGrade.DeleteOnSubmit(s);
            db.SubmitChanges();
        } 
    }
}