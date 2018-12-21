using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WorldWideFloors.Models;

namespace WorldWideFloors.API
{
    public class CollectionsController : ApiController
    {
        private WorldWideFloorsContext db = new WorldWideFloorsContext();

        // GET: api/Collections
        public IQueryable<CollectionDTO> GetCollections()
        {
            var collections = from c in db.Collections
                              select new CollectionDTO()
                              {
                                  Id = c.Id,
                                  Name = c.Name,
                                  Desc = c.Desc
                              };
                                return collections;
        }

        // GET: api/Collections/5
        [ResponseType(typeof(CollectionDTO))]
        public async Task<IHttpActionResult> GetCollection(int id)
        {
            Collection c = await db.Collections.FindAsync(id);
            if (c == null)
            {
                return NotFound();
            }

            CollectionDTO collection = new CollectionDTO
            {
                Id = c.Id,
                Name = c.Name,
                Desc = c.Desc
            };
            return Ok(collection);
        }

        // PUT: api/Collections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCollection(int id, Collection collection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != collection.Id)
            {
                return BadRequest();
            }

            db.Entry(collection).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionExists(id))
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

        // POST: api/Collections
        [ResponseType(typeof(Collection))]
        public IHttpActionResult PostCollection(Collection collection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Collections.Add(collection);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = collection.Id }, collection);
        }

        // DELETE: api/Collections/5
        [ResponseType(typeof(Collection))]
        public IHttpActionResult DeleteCollection(int id)
        {
            Collection collection = db.Collections.Find(id);
            if (collection == null)
            {
                return NotFound();
            }

            db.Collections.Remove(collection);
            db.SaveChanges();

            return Ok(collection);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CollectionExists(int id)
        {
            return db.Collections.Count(e => e.Id == id) > 0;
        }
    }
}