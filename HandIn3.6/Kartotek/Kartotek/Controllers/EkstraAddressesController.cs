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
using Kartotek.Models;

namespace Kartotek.Controllers
{
    public class EkstraAddressesController : ApiController
    {
        private Models.Kartotek db = new Models.Kartotek();

        // GET: api/EkstraAddresses
        public IQueryable<EkstraAddresse> GetEkstraAddresses()
        {
            return db.EkstraAddresses;
        }

        // GET: api/EkstraAddresses/5
        [ResponseType(typeof(EkstraAddresse))]
        public IHttpActionResult GetEkstraAddresse(int id)
        {
            EkstraAddresse ekstraAddresse = db.EkstraAddresses.Find(id);
            if (ekstraAddresse == null)
            {
                return NotFound();
            }

            return Ok(ekstraAddresse);
        }

        // PUT: api/EkstraAddresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEkstraAddresse(int id, EkstraAddresse ekstraAddresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ekstraAddresse.Id)
            {
                return BadRequest();
            }

            db.Entry(ekstraAddresse).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EkstraAddresseExists(id))
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

        // POST: api/EkstraAddresses
        [ResponseType(typeof(EkstraAddresse))]
        public IHttpActionResult PostEkstraAddresse(EkstraAddresse ekstraAddresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EkstraAddresses.Add(ekstraAddresse);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ekstraAddresse.Id }, ekstraAddresse);
        }

        // DELETE: api/EkstraAddresses/5
        [ResponseType(typeof(EkstraAddresse))]
        public IHttpActionResult DeleteEkstraAddresse(int id)
        {
            EkstraAddresse ekstraAddresse = db.EkstraAddresses.Find(id);
            if (ekstraAddresse == null)
            {
                return NotFound();
            }

            db.EkstraAddresses.Remove(ekstraAddresse);
            db.SaveChanges();

            return Ok(ekstraAddresse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EkstraAddresseExists(int id)
        {
            return db.EkstraAddresses.Count(e => e.Id == id) > 0;
        }
    }
}