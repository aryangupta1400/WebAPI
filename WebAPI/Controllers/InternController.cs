using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DBModels;
using Model.Request;
using Model.ResponseModels;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Implementing WebAPI using on DB 
    /// </summary>
    [ApiController]
    [Route("Intern")]
    public class InternController : ControllerBase
    {
        /// <summary>
        /// DB context object for Request and Response
        /// </summary>
        private readonly OrganizationContext organizationContext;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="organizationContext"></param>
        public InternController(OrganizationContext organizationContext)
        {
            this.organizationContext = organizationContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Fetch Intern Details")]
        public async Task<List<InternDTO>> FetchInternDetails()
        {
            List<InternDTO> interns = await organizationContext.Interns.Select(i => new InternDTO()
            {
                InternId = i.InternId,
                Mentor = i.Mentor                
            }).ToListAsync();

            return interns;
        }

        /// <summary>
        /// Adding a new Intern's Details to DB
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddEmployeeDetails")]
        public async Task<InternDTO> AddInternDetails(AddInternRequest addInternRequest)
        {
            Intern intern = new Intern()
            {                
                InternId = (int)addInternRequest.InternId,
                InternName = addInternRequest.InternName,
                Mentor = addInternRequest.Mentor,
                CurrentTrainings = addInternRequest.CurrentTrainings
            };

            organizationContext.Interns.Add(intern);
            await organizationContext.SaveChangesAsync();

            InternDTO internDTO = new InternDTO() 
            {
                InternId=intern.InternId,
                Mentor=intern.Mentor                
            };

            return internDTO;
        }
    }
}
