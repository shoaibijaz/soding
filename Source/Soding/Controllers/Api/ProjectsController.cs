using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Soding.Entities.Models;
using Soding.Service.Classes;
using Repository.Pattern.UnitOfWork;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace Soding.Controllers.Api
{
    public class ProjectsController : ApiController
    {
        private readonly IProjectService _projectService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public ProjectsController(IProjectService projectService, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _projectService = projectService;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        // GET, POST: api/Projects/List
        [AcceptVerbs("POST", "GET")]
        public IEnumerable<Project> List()
        {
            return _projectService.Queryable();
        }

        // GET, POST: api/Projects/Find
        [ResponseType(typeof(Project))]
        [AcceptVerbs("POST", "GET")]
        public async Task<IHttpActionResult> Find(int id)
        {
            var project = await _projectService.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }


        // POST: api/Projects
        [AcceptVerbs("POST")]
        [ResponseType(typeof(object))]
        public async Task<IHttpActionResult> AddUpdate([FromBody] Project project)
        {
            _projectService.InsertOrUpdate(project);

            var result = _unitOfWorkAsync.SaveChanges();

            await Task.Delay(1000);

            return Content<int>(HttpStatusCode.OK, result);
        }


        // GET, POST: api/Projects/Delete
        [ResponseType(typeof(Project))]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult Delete(int id)
        {
            var entity = _projectService.Find(id);

             _projectService.Delete(entity);

            var result = _unitOfWorkAsync.SaveChanges();

            return Content<int>(HttpStatusCode.OK, result);
        }

    }
}
