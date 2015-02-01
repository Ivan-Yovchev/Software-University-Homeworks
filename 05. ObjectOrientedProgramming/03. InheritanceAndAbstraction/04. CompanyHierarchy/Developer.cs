using System;
using System.Collections.Generic;

class Developer : RegularEmployee, IDeveloper
{
    private List<IProject> projects;

    public Developer(string id, string firstName, string lastName, decimal salary, Department department, List<IProject> projects)
        : base(id, firstName, lastName, salary, department)
    {
        this.Projects = projects;
    }

    public List<IProject> Projects
    {
        get { return this.projects; }
        set { this.projects = value; }
    }

    public override string ToString()
    {
        string baseStr = base.ToString() + "\n\n";
        string projectsStr = "";
        foreach (var project in projects)
        {
            projectsStr += project.ToString() + "\n";
        }

        return baseStr + "Projects:\n" + projectsStr;
    }
}
