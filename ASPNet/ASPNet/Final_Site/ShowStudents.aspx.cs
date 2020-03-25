using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ShowStudents : System.Web.UI.Page
{
    DataController data;
    List<CourseModel> courses;
    readonly string removeButtonPrefix = "removeButtonPress_";
    protected void Page_Load(object sender, EventArgs e)
    {
        data = new DataController();

        if (IsPostBack)
        {
            string eTarget = Request.Params["__EVENTTARGET"].ToString();
            ListItem selectedItem = Courses.SelectedItem;

            if (eTarget.Contains(Courses.ID))
            {
                List<StudentModel> students = data.getStudentsByCourseID(Int16.Parse(selectedItem.Value));

                foreach (StudentModel s in students)
                {
                    TableRow r = new TableRow();
                    TableCell firstName = new TableCell();
                    firstName.Text = s.FirstName;
                    TableCell lastName = new TableCell();
                    lastName.Text = s.LastName;
                    TableCell removeButton = new TableCell();
                    Button b = new Button();
                    b.ID = removeButtonPrefix + s.StudentID.ToString();
                    b.UseSubmitBehavior = false;
                    b.Text = "Unsubscribe";
                    removeButton.Controls.Add(b);
                    r.Cells.Add(firstName);
                    r.Cells.Add(lastName);
                    r.Cells.Add(removeButton);
                    CourseTable.Rows.Add(r);
                }
            } else if (eTarget.Contains(removeButtonPrefix))
            {
                int pos = eTarget.IndexOf(removeButtonPrefix) + removeButtonPrefix.Length;
                data.removeStudentFromCourse(Int16.Parse(eTarget.Substring(pos, eTarget.Length - pos)), Int16.Parse(selectedItem.Value));
                Courses.SelectedValue = selectedItem.Value;
            }          
        }
        else
        {
            Courses.DataSource = CreateDataSource();
            Courses.DataTextField = "ColorTextField";
            Courses.DataValueField = "ColorValueField";
            Courses.DataBind();
        }
    }

    System.Collections.ICollection CreateDataSource()
    {
        // Create a table to store data for the DropDownList control.
        DataTable dt = new DataTable();

        // Define the columns of the table.
        dt.Columns.Add(new DataColumn("ColorTextField", typeof(String)));
        dt.Columns.Add(new DataColumn("ColorValueField", typeof(String)));

        courses = data.getAllCourses();
        foreach (CourseModel c in courses)
        {
            dt.Rows.Add(CreateRow(c.Title, c.CourseID.ToString(), dt));
        }

        DataView dv = new DataView(dt);
        return dv;

    }

    DataRow CreateRow(String Text, String Value, DataTable dt)
    {
        DataRow dr = dt.NewRow();
        dr[0] = Text;
        dr[1] = Value;
        return dr;

    }
}