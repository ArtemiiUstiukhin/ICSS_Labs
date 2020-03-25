using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Data.Linq.Mapping;
/// <summary>
/// Сводное описание для Course
/// </summary>
[Table(Name = "Course")]
public class Course
{
    private int _CourseID;
    [Column(IsPrimaryKey = true, Storage = "_CourseID")]
    public int CourseID
    {
        get
        {
            return this._CourseID;
        }
        set
        {
            this._CourseID = value;
        }
    }

    private string _Title;
    [Column(Storage = "_Title")]
    public string Title
    {
        get
        {
            return this._Title;
        }
        set
        {
            this._Title = value;
        }
    }

    private int _Credits;
    [Column(Storage = "_Credits")]
    public int Credits
    {
        get
        {
            return this._Credits;
        }
        set
        {
            this._Credits = value;
        }
    }

    private int _DepartmentID;
    [Column(Storage = "_DepartmentID")]
    public int DepartmentID
    {
        get
        {
            return this._DepartmentID;
        }
        set
        {
            this._DepartmentID = value;
        }
    }
    public override string ToString()
    {
        return CourseID + "\t" + Title;
    }

}