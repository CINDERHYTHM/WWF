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
    public class MaterialsController : ApiController
    {
        private WorldWideFloorsContext db = new WorldWideFloorsContext();

        // GET: api/Materials
        public IQueryable<MaterialsDTO> GetMaterials()
        {
            var materials = from m in db.Materials
                        select new MaterialsDTO()
                        {
                            Id = m.Id,
                            Type = m.Type,
                            Price = m.Price,
                            AmountLeft = m.AmountLeft

                        };
            return materials;
        }

        // GET: api/Materials/5
        [ResponseType(typeof(MaterialsDTO))]
        public IHttpActionResult GetMaterials(int id)
        {
            Materials m = db.Materials.Find(id);
            if (m == null)
            {
                return NotFound();
            }

            MaterialsDTO materials = new MaterialsDTO
            {
                Id = m.Id,
                Type = m.Type,
                Price = m.Price,
                AmountLeft = m.AmountLeft
            };
            return Ok(materials);
        }

        // PUT: api/Materials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaterials(int id, Materials materials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != materials.Id)
            {
                return BadRequest();
            }

            db.Entry(materials).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialsExists(id))
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

        // POST: api/Materials
        [ResponseType(typeof(Materials))]
        public IHttpActionResult PostMaterials(Materials materials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Materials.Add(materials);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = materials.Id }, materials);
        }

        // DELETE: api/Materials/5
        [ResponseType(typeof(Materials))]
        public IHttpActionResult DeleteMaterials(int id)
        {
            Materials materials = db.Materials.Find(id);
            if (materials == null)
            {
                return NotFound();
            }

            db.Materials.Remove(materials);
            db.SaveChanges();

            return Ok(materials);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaterialsExists(int id)
        {
            return db.Materials.Count(e => e.Id == id) > 0;
        }
    }
}