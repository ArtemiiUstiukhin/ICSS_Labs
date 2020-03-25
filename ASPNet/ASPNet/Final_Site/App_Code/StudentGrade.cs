using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

[Table(Name = "StudentGrade")]
public class StudentGrade
{
    private int _EnrollmentID;
    [Column(IsPrimaryKey = true, Storage = "_EnrollmentID", IsDbGenerated = true)]
    public int EnrollmentID
    {
        get
        {
            return this._EnrollmentID;
        }
        set
        {
            this._EnrollmentID = value;
        }
    }

    private int _CourseID;
    [Column(Storage = "_CourseID")]
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

    private int _StudentID;
    [Column(Storage = "_StudentID")]
    public int StudentID
    {
        get
        {
            return this._StudentID;
        }
        set
        {
            this._StudentID = value;
        }
    }

    private Decimal? _Grade;
    [Column(Storage = "_Grade")]
    public Decimal? Grade
    {
        get
        {
            return this._Grade;
        }
        set
        {
            this._Grade = value;
        }
    }
}