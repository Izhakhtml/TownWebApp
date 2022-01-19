using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TownWebApp.Models;

namespace TownWebApp.Controllers.api
{
    public class ResidentController : ApiController
    {
        TownModel dbContext = new TownModel();
        // GET: api/Resident
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new {dbContext.Resident});
            }
            catch(SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Resident/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Resident GetById = await dbContext.Resident.FindAsync(id);
                if (GetById != null)
                {
                    return Ok(new { GetById });
                }
                return NotFound();
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Resident
        public async Task<IHttpActionResult> Post([FromBody]Resident newResident)
        {
            try
            {
                dbContext.Resident.Add(newResident);
                await dbContext.SaveChangesAsync();
                return Ok("Added successfully");
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Resident/5
        public  async Task<IHttpActionResult>  Put(int id, [FromBody] Resident updateResident)
        {
            try
            {
                Resident CatchResidentById = await dbContext.Resident.FindAsync(id);
                if (CatchResidentById != null)
                {
                    CatchResidentById.FirstName = updateResident.FirstName;
                    CatchResidentById.FatherName = updateResident.FatherName;
                    CatchResidentById.Gender = updateResident.Gender;
                    CatchResidentById.IfBornInTown = updateResident.IfBornInTown;
                    CatchResidentById.BirthYear = updateResident.BirthYear;
                    await dbContext.SaveChangesAsync();
                    return Ok("Updated successfully"); 
                }
                return NotFound();
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Resident/5
        public  async Task<IHttpActionResult>  Delete(int id)
        {
            try
            {
                Resident RemovedById =await dbContext.Resident.FindAsync(id);
                if (RemovedById != null)
                {
                  dbContext.Resident.Remove(RemovedById);
                  await dbContext.SaveChangesAsync();
                  return Ok("Removed successfully");
                }
                return NotFound();
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
