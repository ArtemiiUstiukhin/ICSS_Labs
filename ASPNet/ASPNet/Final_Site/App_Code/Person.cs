using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

[Table(Name = "Person")]
public class Person
{
    private int _PersonID;
    [Column(IsPrimaryKey = true, Storage = "_PersonID", IsDbGenerated = true)]
    public int PersonID
    {
        get
        {
            return this._PersonID;
        }
        set
        {
            this._PersonID = value;
        }
    }

    private string _LastName;
    [Column(Storage = "_LastName")]
    public string LastName
    {
        get
        {
            return this._LastName;
        }
        set
        {
            this._LastName = value;
        }
    }

    private string _FirstName;
    [Column(Storage = "_FirstName")]
    public string FirstName
    {
        get
        {
            return this._FirstName;
        }
        set
        {
            this._FirstName = value;
        }
    }

    private DateTime? _HireDate;
    [Column(Storage = "_HireDate", CanBeNull = true)]
    public DateTime? HireDate
    {
        get
        {
            return this._HireDate;
        }
        set
        {
            this._HireDate = value;
        }
    }

    private DateTime? _EnrollmentDate;
    [Column(Storage = "_EnrollmentDate")]
    public DateTime? EnrollmentDate
    {
        get
        {
            return this._EnrollmentDate;
        }
        set
        {
            this._EnrollmentDate = value;
        }
    }
}