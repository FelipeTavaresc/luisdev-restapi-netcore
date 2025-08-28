﻿using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll();
        Task<Project?> GetDetailsById(int id);
        Task<Project?> GetById(int id);
        Task<int> Insert(Project project);
        Task Update(Project project);
        Task InsertComment(ProjectComment comment);
        Task<bool> Exists(int id);
    }
}
