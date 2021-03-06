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
using WebGrease.Css.Extensions;

namespace Kartotek.Controllers
{
    public class PeopleController : ApiController
    {
        private Models.Kartotek db = new Models.Kartotek();

        // GET: api/People
        public IQueryable<PersonDto> GetPeople()
        {
            var Persons = from b in db.People
                        select new PersonDto()
                        {
                            Id = b.Id,
                            Navn = b.Fornavn,
                        };
            return Persons;
        }

        // GET: api/People/5
        [ResponseType(typeof(PersonDetailDto))]
        public async Task<IHttpActionResult> GetPerson(int id)
        {
            var person = await db.People.Include(b => b.Addresse).Select(b =>
              new PersonDetailDto()
                    {
                        Id = b.Id,
                        ForNavn = b.Fornavn,
                        MellemNavn = b.Mellemnavn,
                        EfterNavn = b.Efternavn,
                        Forhold = b.Forhold,
                        FolkeregisterId = b.FolkeAID,
                    }).SingleOrDefaultAsync(b => b.Id == id);
            var tele = await db.People.Include(b => b.Telefonnummers).Include(b => b.EkstraAddresses).SingleOrDefaultAsync(b => b.Id == id);
            tele.Telefonnummers.ForEach(n => person.TlfIdList.Add(n.Id));
            tele.EkstraAddresses.ForEach(a => person.AddrIdList.Add(a.Id));
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/People/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPerson(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.Id)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> PostPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.People.Add(person);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> DeletePerson(int id)
        {
            Person person = await db.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            db.People.Remove(person);
            await db.SaveChangesAsync();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return db.People.Count(e => e.Id == id) > 0;
        }
    }
}