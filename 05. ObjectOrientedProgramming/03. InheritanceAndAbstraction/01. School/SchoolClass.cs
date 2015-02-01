using System;
using System.Collections.Generic;

class SchoolClass : IDetail
{
    private string textIdentifier;
    private Student[] students;
    private Teacher[] teachers;
    private static List<string> usedIDs;
    private string details;

    static SchoolClass()
    {
        SchoolClass.usedIDs = new List<string>();
    }

    public SchoolClass(string textIdentifier, Student[] students, Teacher[] teachers, string details = null)
    {
        this.TextIdentifier = textIdentifier;
        this.Students = students;
        this.Teachers = teachers;
        this.Details = details;
    }

    public string TextIdentifier
    {
        get { return this.textIdentifier; }
        set
        {
            if(string.IsNullOrEmpty(value)) 
            {
                throw new ArgumentNullException("Class ID must be a non-empty string");
            }
            else if(SchoolClass.usedIDs.Contains(value))
            {
                throw new ArgumentException("This ID{" + value + "} is alreade taken");
            }
            else
            {
                this.textIdentifier = value;
                SchoolClass.usedIDs.Add(value);
            }
        }
    }

    public Student[] Students 
    {
        get { return this.students; }
        set { this.students = value; }
    }

    public Teacher[] Teachers
    {
        get { return this.teachers; }
        set { this.teachers = value; }
    }


    public string Details
    {
        get { return this.details; }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Details must be a non-empty string");
                }
                this.details = value;
            }
    }
}
