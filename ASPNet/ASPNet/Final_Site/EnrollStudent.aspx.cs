using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
public partial class EnrollStudent : System.Web.UI.Page
{
    DataController data;
    List<CourseModel> courses;

    public bool checkValid(out string errMsg)
    {
        errMsg = "";
        bool res = true;
        if (LastName.Text.Length == 0)
        {
            errMsg += "Введите Фамилию! \n";
            res = false;
        }
        if (FirstName.Text.Length == 0)
        {
            errMsg += "Введите Имя! \n";
            res = false;
        }
        if (Grade.Text.Length == 0)
        {
            errMsg += "Введите Балл! \n";
            res = false;
        } else if (!Int16.TryParse(Grade.Text, out short i) || Int16.Parse(Grade.Text) < 2 || Int16.Parse(Grade.Text) > 5)
        {
            errMsg = "Введите Корректный балл! \n";
            res = false;
        }
        return res;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        data = new DataController();

        if (IsPostBack)
        {
            string errMsg;
            if (checkValid(out errMsg))
            {
                ListItem selectedItem = Courses.SelectedItem;
                data.enrollStudentToCourse(Int16.Parse(selectedItem.Value), LastName.Text, FirstName.Text, Int16.Parse(Grade.Text));
            } else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", String.Format("alert('{0}')",errMsg), true);
            }
            
        } else
        {
            Courses.DataSource = CreateDataSource();
            Courses.DataTextField = "ColorTextField";
            Courses.DataValueField = "ColorValueField";
            Courses.DataBind();
            Courses.SelectedIndex = 0;
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