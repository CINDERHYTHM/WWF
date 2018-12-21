using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WorldWideFloors.Models;

namespace WorldWideFloors.API
{
    public class ProjectsController : ApiController
    {
        private WorldWideFloorsContext db = new WorldWideFloorsContext();

        // GET: api/Projects
        public IQueryable<ProjectDTO> GetProjects()
        {
            var projects = from p in db.Projects
                            select new ProjectDTO()
                            {
                                Id = p.Id,
                                ProjectName = p.ProjectName,
                                ProjectDescription = p.ProjectDescription,
                                ProjectLocation = p.ProjectLocation,
                                ProjectTime = p.ProjectTime

                            };
            return projects;
        }

        // GET: api/Projects/5
        [ResponseType(typeof(ProjectDTO))]
        public IHttpActionResult GetProjects(int id)
        {
            Project p = db.Projects.Find(id);
            if (p == null)
            {
                return NotFound();
            }

            ProjectDTO projects = new ProjectDTO
            {
                Id = p.Id,
                ProjectName = p.ProjectName,
                ProjectDescription = p.ProjectDescription,
                ProjectLocation = p.ProjectLocation,
                ProjectTime = p.ProjectTime
            };
            return Ok(projects);
        }

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProject(int id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.Id)
            {
                return BadRequest();
            }

            db.Entry(project).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Projects
        [ResponseType(typeof(Project))]
        public IHttpActionResult PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Projects.Add(project);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = project.Id }, project);
        }

        // DELETE: api/Projects/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult DeleteProject(int id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            db.Projects.Remove(project);
            db.SaveChanges();

            return Ok(project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(int id)
        {
            return db.Projects.Count(e => e.Id == id) > 0;
        }
    }
}