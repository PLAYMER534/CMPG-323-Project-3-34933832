using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TelemetryPortal_MVC.Models;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetProjectsAsync();
    Task<Project> GetProjectByIdAsync(Guid id);
    Task AddProjectAsync(Project project);
    Task UpdateProjectAsync(Project project);
    Task DeleteProjectAsync(Guid id);
    Task<bool> ProjectExistsAsync(Guid projectId);
}


