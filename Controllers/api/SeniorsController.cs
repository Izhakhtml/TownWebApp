using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TownWebApp.Models;

namespace TownWebApp.Controllers.api
{
    public class SeniorsController : ApiController
    {
        static string connectionString = "Data Source=LAPTOP-K0H6TSU4;Initial Catalog=EldersDB;Integrated Security=True;Pooling=False";
        DataClassesDataContext dataContext = new DataClassesDataContext(connectionString);
        // GET: api/Seniors
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new { dataContext.Seniors });
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

        // GET: api/Seniors/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Senior seniorById = dataContext.Seniors.First(item => item.Id == id);
                if (seniorById != null)
                {
                    return Ok(new {seniorById});
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

        // POST: api/Seniors
        public IHttpActionResult Post([FromBody]Senior newSenior)
        {
            try
            {
                dataContext.Seniors.InsertOnSubmit(newSenior);
                dataContext.SubmitChanges();
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

        // PUT: api/Seniors/5
        public IHttpActionResult Put(int id, [FromBody]Senior updateSenior)
        {
            try
            {
               Senior seniorById = dataContext.Seniors.First(item => item.Id == id);
                if (seniorById != null)
                {
                    seniorById.Name = updateSenior.Name;
                    seniorById.BirthYear = updateSenior.BirthYear;
                    seniorById.Seniority = updateSenior.Seniority;
                    dataContext.SubmitChanges();
                    return Ok("UpdatedSuccessfully");
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

        // DELETE: api/Seniors/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Senior seniorById = dataContext.Seniors.First(item => item.Id == id);
                if (seniorById != null)
                {
                  dataContext.Seniors.DeleteOnSubmit(seniorById);
                    dataContext.SubmitChanges();
                    return Ok("Deleted successfully");
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
