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
    public class AddressesController : ApiController
    {
        private Models.Kartotek db = new Models.Kartotek();

        // GET: api/Addresses
        public IQueryable<Addresse> GetAddresses()
        {
            return db.Addresses;
        }

        // GET: api/Addresses/5
        [ResponseType(typeof(Addresse))]
        public IHttpActionResult GetAddresse(int id)
        {
            Addresse addresse = db.Addresses.Find(id);
            if (addresse == null)
            {
                return NotFound();
            }

            return Ok(addresse);
        }

        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddresse(int id, Addresse addresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != addresse.Id)
            {
                return BadRequest();
            }

            db.Entry(addresse).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddresseExists(id))
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

        // POST: api/Addresses
        [ResponseType(typeof(Addresse))]
        public IHttpActionResult PostAddresse(Addresse addresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Addresses.Add(addresse);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = addresse.Id }, addresse);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(Addresse))]
        public IHttpActionResult DeleteAddresse(int id)
        {
            Addresse addresse = db.Addresses.Find(id);
            if (addresse == null)
            {
                return NotFound();
            }

            db.Addresses.Remove(addresse);
            db.SaveChanges();

            return Ok(addresse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddresseExists(int id)
        {
            return db.Addresses.Count(e => e.Id == id) > 0;
        }
    }
}