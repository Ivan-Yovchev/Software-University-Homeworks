using System;

class Project : IProject
{
    private string projectName, details;
    private DateTime startDate;
    private State state;

    public Project(string projectName, DateTime startDate, string details, State state)
    {
        this.ProjectName = projectName;
        this.StartDate = startDate;
        this.Details = details;
        this.State = state;
    }

    public string ProjectName
    {
        get { return this.projectName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Project Name cannot be empty");
            }
            this.projectName = value;
        }
    }

    public string Details
    {
        get { return this.details; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Details cannot be empty");
            }
            this.details = value;
        }
    }

    public DateTime StartDate
    {
        get { return this.startDate; }
        set { this.startDate = value; }
    }

    public State State
    {
        get { return this.state; }
        set { this.state = value; }
    }

    public void CloseProject()
    {
        this.state = State.Closed;
        Console.WriteLine("Project closed ...");
    }

    public override string ToString()
    {
        return string.Format("Project Name: {0}, Start Date: {1:dd.MM.yyyy}, Details: {2}, State: {3}",
            this.ProjectName, this.StartDate, this.Details, this.State);
    }

}

