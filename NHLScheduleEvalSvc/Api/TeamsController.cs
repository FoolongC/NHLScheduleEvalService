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

namespace NHLScheduleEvalSvc.Controllers
{
    public class TeamsController : ApiController
    {
        private NHLScheduleEvalSvcContext db = new NHLScheduleEvalSvcContext();

        public IQueryable<B2BTeamDTO> GetTeams()
        {
            var nhlTeams = from t in db.Teams
                select new B2BTeamDTO
                {
                    Id = t.Id,
                    TeamName = t.TeamName,
                    Count = t.Count
                };
            return nhlTeams;
        }

        [ResponseType(typeof(B2BTeamDTO))]
        public async Task<IHttpActionResult> GetTeam(int id)
        {
            var nhlTeam = await db.Teams.Include(t => t.TeamName).Select(t =>
                new B2BTeamDTO()
                {
                    Id = t.Id,
                    TeamName = t.TeamName,
                    Count = t.Count
                }).SingleOrDefaultAsync(t => t.Id == id);
            return Ok(nhlTeam);
        }

        // PUT: api/Teams/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTeam(int id, Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != team.Id)
            {
                return BadRequest();
            }

            db.Entry(team).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: api/Teams
        [ResponseType(typeof(Team))]
        public async Task<IHttpActionResult> PostTeam(Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teams.Add(team);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = team.Id }, team);
        }

        // DELETE: api/Teams/5
        [ResponseType(typeof(Team))]
        public async Task<IHttpActionResult> DeleteTeam(int id)
        {
            Team team = await db.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            db.Teams.Remove(team);
            await db.SaveChangesAsync();

            return Ok(team);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeamExists(int id)
        {
            return db.Teams.Count(e => e.Id == id) > 0;
        }
    }
}