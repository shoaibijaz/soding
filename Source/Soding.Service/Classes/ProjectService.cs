using Repository.Pattern.Repositories;
using Service.Pattern;
using Soding.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soding.Service.Classes
{
    /// <summary>Interface for project model entity.</summary>
    public interface IProjectService : IService<Project>
    {
        void InsertOrUpdate(Project entity);
    }

    /// <summary>Provides project entity services.</summary>
    public class ProjectService : Service<Project>, IProjectService
    {
        private readonly IRepositoryAsync<Project> _repository;

        public ProjectService(IRepositoryAsync<Project> repository) : base(repository)
        {
            _repository = repository;
        }


        /// <summary>Insert and update project entity records</summary>
        /// <param name="entity">The project entity object</param>
        public void InsertOrUpdate(Project entity)
        {
            if (entity.Id > 0)
            {
                var updateEntity = base.Find(entity.Id);

                updateEntity.Name = entity.Name;
                updateEntity.Image = entity.Image;
                updateEntity.Status = entity.Status;
                updateEntity.ModifiedOn = DateTime.Now;

                base.Update(updateEntity);

            }
            else
            {
                entity.CreatedOn = DateTime.Now;
                entity.ModifiedOn = DateTime.Now;
                base.Insert(entity);
            }
        }


    }

}
