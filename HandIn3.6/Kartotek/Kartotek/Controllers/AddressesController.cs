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
using WebGrease.Css.Extensions;

namespace Kartotek.Controllers
{
    public class AddressesController : ApiController
    {
        private Models.Kartotek db = new Models.Kartotek();

        // GET: api/Addresses
        public IQueryable<AddresseDto> GetAddresses()
        {
            var address = from a in db.Addresses select
            new AddresseDto
            {
                Id = a.Id,
                Vejnavn = a.Vejnavn,
                Bynavn = a.Bynavn,
                Husnummer = a.Husnummer,
                Postnummer = a.Postnummer
            };
            return address;
        }

        // GET: api/Addresses/5
        [ResponseType(typeof(AddresseDtoDetail))]
        public async Task<IHttpActionResult> GetAddresse(int id)
        {

            var addresse =
                await db.Addresses.Select(A => new AddresseDtoDetail
                {
                    Id = A.Id,
                    Vejnavn = A.Vejnavn,
                    Bynavn = A.Bynavn,
                    Husnummer = A.Husnummer,
                    Postnummer = A.Postnummer
                }).SingleOrDefaultAsync(A => A.Id == id);
            var addr =
                await db.Addresses.Include(a => a.People).Include(a => a.EkstraAddresses).SingleOrDefaultAsync(A => A.Id == id);
            addr.People.ForEach(p => addresse.PeopleIds.Add(p.Id));
            addr.EkstraAddresses.ForEach(a => addresse.EkstraAddreseIds.Add(a.Id));
            if (addresse == null)
            {
                return NotFound();
            }

            return Ok(addresse);
        }

        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAddresse(int id, Addresse addresse)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostAddresse(Addresse addresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Addresses.Add(addresse);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = addresse.Id }, addresse);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(Addresse))]
        public async Task<IHttpActionResult> DeleteAddresse(int id)
        {
            Addresse addresse = await db.Addresses.FindAsync(id);
            if (addresse == null)
            {
                return NotFound();
            }

            db.Addresses.Remove(addresse);
            await db.SaveChangesAsync();

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