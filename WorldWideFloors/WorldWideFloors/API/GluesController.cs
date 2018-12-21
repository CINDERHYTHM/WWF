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
    public class GluesController : ApiController
    {
        private WorldWideFloorsContext db = new WorldWideFloorsContext();

        // GET: api/Glues
        public IQueryable<GlueDTO> GetGlue()
        {
            var glues = from g in db.Glues
                              select new GlueDTO()
                              {
                                  Id = g.Id,
                                  MaterialType = g.MaterialType,
                                  MaterialAmount = g.MaterialAmount,
                                  Price = g.Price

                              };
            return glues;
        }

        // GET: api/Glues/5
        [ResponseType(typeof(GlueDTO))]
        public IHttpActionResult GetGlue(int id)
        {
            Glue g = db.Glues.Find(id);
            if (g == null)
            {
                return NotFound();
            }

            GlueDTO glues = new GlueDTO
            {
                Id = g.Id,
                MaterialType = g.MaterialType,
                MaterialAmount = g.MaterialAmount,
                Price = g.Price
            };
            return Ok(glues);
        }

        // PUT: api/Glues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGlue(int id, Glue glue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != glue.Id)
            {
                return BadRequest();
            }

            db.Entry(glue).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GlueExists(id))
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

        // POST: api/Glues
        [ResponseType(typeof(Glue))]
        public IHttpActionResult PostGlue(Glue glue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Glues.Add(glue);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = glue.Id }, glue);
        }

        // DELETE: api/Glues/5
        [ResponseType(typeof(Glue))]
        public IHttpActionResult DeleteGlue(int id)
        {
            Glue glue = db.Glues.Find(id);
            if (glue == null)
            {
                return NotFound();
            }

            db.Glues.Remove(glue);
            db.SaveChanges();

            return Ok(glue);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GlueExists(int id)
        {
            return db.Glues.Count(e => e.Id == id) > 0;
        }
    }
}