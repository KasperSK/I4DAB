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
using Kartotek.Models;

namespace Kartotek.Controllers
{
    public class EkstraAddressesController : ApiController
    {
        private Models.Kartotek db = new Models.Kartotek();

        // GET: api/EkstraAddresses
        public IQueryable<EkstraAddresseDto> GetEkstraAddresses()
        {
            var Eaddr = from ea in db.EkstraAddresses select new EkstraAddresseDto
            {
                Id = ea.Id,
                AddresseID = ea.AddresseID,
                PersonID = ea.PersonID
            };
            return Eaddr;
        }

        // GET: api/EkstraAddresses/5
        [ResponseType(typeof(EkstraAddresseDetail))]
        public async Task<IHttpActionResult> GetEkstraAddresse(int id)
        {
            var ekstraAddresse = await db.EkstraAddresses.Select(ea => new EkstraAddresseDetail
            {
                Id = ea.Id,
                AddresseID = ea.AddresseID,
                PersonID = ea.PersonID,
                Forhold = ea.Forhold
            }).SingleOrDefaultAsync(A => A.Id == id);
            if (ekstraAddresse == null)
            {
                return NotFound();
            }

            return Ok(ekstraAddresse);
        }

        // PUT: api/EkstraAddresses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEkstraAddresse(int id, EkstraAddresse ekstraAddresse)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostEkstraAddresse(EkstraAddresse ekstraAddresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EkstraAddresses.Add(ekstraAddresse);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ekstraAddresse.Id }, ekstraAddresse);
        }

        // DELETE: api/EkstraAddresses/5
        [ResponseType(typeof(EkstraAddresse))]
        public async Task<IHttpActionResult> DeleteEkstraAddresse(int id)
        {
            EkstraAddresse ekstraAddresse = await db.EkstraAddresses.FindAsync(id);
            if (ekstraAddresse == null)
            {
                return NotFound();
            }

            db.EkstraAddresses.Remove(ekstraAddresse);
            await db.SaveChangesAsync();

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