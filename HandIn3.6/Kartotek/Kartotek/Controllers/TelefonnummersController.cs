﻿using System;
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
    public class TelefonnummersController : ApiController
    {
        private Models.Kartotek db = new Models.Kartotek();

        // GET: api/Telefonnummers
        public IQueryable<TelefonnummerDto> GetTelefonnummers()
        {
            var Tele = from t in db.Telefonnummers
                select new TelefonnummerDto
                {
                    Id = t.Id,
                    Nummer = t.Nummer
                };
            return Tele;
        }

        // GET: api/Telefonnummers/5
        [ResponseType(typeof(TelefonnummerDetailsDto))]
        public async Task<IHttpActionResult> GetTelefonnummer(int id)
        {
            var telefonnummer = await db.Telefonnummers.Select(t => new TelefonnummerDetailsDto
            {
                Id = t.Id,
                Forhold = t.Forhold,
                Nummer = t.Nummer,
                PersonId = t.PersonID
            }
            ).SingleOrDefaultAsync(t => t.Id == id);
            if (telefonnummer == null)
            {
                return NotFound();
            }

            return Ok(telefonnummer);
        }

        // PUT: api/Telefonnummers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTelefonnummer(int id, Telefonnummer telefonnummer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telefonnummer.Id)
            {
                return BadRequest();
            }

            db.Entry(telefonnummer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefonnummerExists(id))
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

        // POST: api/Telefonnummers
        [ResponseType(typeof(Telefonnummer))]
        public async Task<IHttpActionResult> PostTelefonnummer(Telefonnummer telefonnummer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Telefonnummers.Add(telefonnummer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = telefonnummer.Id }, telefonnummer);
        }

        // DELETE: api/Telefonnummers/5
        [ResponseType(typeof(Telefonnummer))]
        public async Task<IHttpActionResult> DeleteTelefonnummer(int id)
        {
            Telefonnummer telefonnummer = await db.Telefonnummers.FindAsync(id);
            if (telefonnummer == null)
            {
                return NotFound();
            }

            db.Telefonnummers.Remove(telefonnummer);
            await db.SaveChangesAsync();

            return Ok(telefonnummer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelefonnummerExists(int id)
        {
            return db.Telefonnummers.Count(e => e.Id == id) > 0;
        }
    }
}