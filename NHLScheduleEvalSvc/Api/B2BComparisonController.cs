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
using NHLScheduleEvalSvc.Models;
using System.Data.Entity.Core.Objects;

namespace NHLScheduleEvalSvc.Controllers
{    
    public class B2BComparisonController : ApiController
    {
        private NHLScheduleEvalSvcContext db = new NHLScheduleEvalSvcContext();

        // GET: api/B2BComparison
        public IQueryable<B2BComparison> GetB2BComparison()
        {
            // eager loading with lambda expression
            return db.B2BComparison.Include(b => b.Team);
        }

        // GET: api/B2BComparison/5
        [ResponseType(typeof(B2BDetailDTO))]
        public async Task<IHttpActionResult> GetB2BComparison(string id)
        {
            var teamDetail = await db.B2BComparison.Include(t => t.Team).Select(t =>
                new B2BDetailDTO()
                {
                    Id = t.Id.ToString(),
                    TeamName = t.TeamName,
                    GameOneDate = t.GameOneDate,
                    GameTwoDate = t.GameTwoDate,
                    GameOneHome = t.GameOneHome ? "Yes" : "No",
                    GameTwoHome = t.GameTwoHome ? "Yes" : "No",
                    GameOneFinal = t.GameOneFinal,
                    GameTwoFinal = t.GameTwoFinal,
                    OppPlayedDayBefore = t.OppPlayedDayBefore ? "Yes" : "No",
                    TeamId = t.TeamId.ToString()
                }).Where(t => t.TeamId == id).ToListAsync();

            teamDetail.Select(t => { t.GameOneDate = t.GameOneDate.Date; return t; }).ToList();

            if (teamDetail == null)
            {
                return NotFound();
            }

            return Ok(teamDetail);
        }

        // PUT: api/B2BComparison/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutB2BComparison(int id, B2BComparison b2BComparison)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != b2BComparison.Id)
            {
                return BadRequest();
            }

            db.Entry(b2BComparison).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!B2BComparisonExists(id))
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

        // POST: api/B2BComparison
        [ResponseType(typeof(B2BComparison))]
        public async Task<IHttpActionResult> PostB2BComparison(B2BComparison b2BComparison)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.B2BComparison.Add(b2BComparison);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = b2BComparison.Id }, b2BComparison);
        }

        // DELETE: api/B2BComparison/5
        [ResponseType(typeof(B2BComparison))]
        public async Task<IHttpActionResult> DeleteB2BComparison(int id)
        {
            B2BComparison b2BComparison = await db.B2BComparison.FindAsync(id);
            if (b2BComparison == null)
            {
                return NotFound();
            }

            db.B2BComparison.Remove(b2BComparison);
            await db.SaveChangesAsync();

            return Ok(b2BComparison);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool B2BComparisonExists(int id)
        {
            return db.B2BComparison.Count(e => e.Id == id) > 0;
        }
    }
}