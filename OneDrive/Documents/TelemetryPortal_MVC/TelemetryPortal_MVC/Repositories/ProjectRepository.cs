using System.Collections.Generic;
using System.Linq;
using TelemetryPortal_MVC.Data; 
namespace TelemetryPortal_MVC.Models;

public class ProjectRepository
{
    private readonly ApplicationDbContext _context;

    public ProjectRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Method to retrieve all projects
    public IEnumerable<Project> GetProjects()
    {
        return _context.Projects.ToList();
    }

    // Method to retrieve a specific project by ID
    public Project GetProjectById(int id)
    {
        return _context.Projects.Find(id);
    }

    // Method to add a new project
    public void AddProject(Project project)
    {
        _context.Projects.Add(project);
        _context.SaveChanges();
    }

    // Method to update an existing project
    public void UpdateProject(Project project)
    {
        _context.Projects.Update(project);
        _context.SaveChanges();
    }

    // Method to delete a project by ID
    public void DeleteProject(int id)
    {
        var project = _context.Projects.Find(id);
        if (project != null)
        {
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }
    }

    internal async Task<string?>? GetProjectById(Guid value)
    {
        throw new NotImplementedException();
    }

    internal void DeleteProject(Guid id)
    {
        throw new NotImplementedException();
    }
}

