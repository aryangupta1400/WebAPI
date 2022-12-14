using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DBModels;
using Model.Request;
using Model.RequestModels;
using Model.ResponseModels;

// Scaffold-DbContext "Server=BRD-3917L13-L\SQLEXPRESS;Database=Organization;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DBModels -force


namespace WebAPI.Controllers
{
    /// <summary>
    /// Implementing WebAPI using DB 
    /// </summary>
    [ApiController]
    [Route("interns")]
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
        /// Fetching all Interns Details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<InternDTO>> FetchInternDetails()
        {
            #region Fetching details for insters
            
            //Fetching all intern details from DB
            List<InternDTO> interns = await organizationContext.Interns.Select(i => new InternDTO()
            {
                InternId = i.InternId,
                Mentor = i.Mentor,
                CurrentTrainings = i.CurrentTrainings
            }).ToListAsync();

            #endregion

            return interns;
        }

        /// <summary>
        /// Adding a new Intern's Details to DB
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<InternDTO> AddInternDetails(AddInternRequest addInternRequest)
        {
            Intern intern = new Intern()
            {
                InternName = addInternRequest.InternName,
                Mentor = addInternRequest.Mentor,
                CurrentTrainings = addInternRequest.CurrentTrainings
            };

            //Adding intern details to DB
            organizationContext.Interns.Add(intern);
            await organizationContext.SaveChangesAsync();

            InternDTO internDTO = new InternDTO()
            {
                InternId = intern.InternId,
                Mentor = intern.Mentor,
                CurrentTrainings = intern.CurrentTrainings
            };
            return internDTO;
        }

        /// <summary>
        /// Updating an Intern's Detail
        /// </summary>
        /// <param name="interID">Which Intern value need to be updated</param>
        /// <param name="updateInternRequest">Object to refrence existing object and print output</param>
        /// <returns></returns>
        [HttpPut("{interID}")]
        public async Task<InternDTO> UpdateInternDetails(int interID, UpdateInternRequest updateInternRequest)
        {
            InternDTO internDTO = new InternDTO()
            {
                InternId = interID,
                Mentor = updateInternRequest.Mentor,
                CurrentTrainings = updateInternRequest.CurrentTrainings
            };            

            var existingIntern = organizationContext.Interns.Where(i => i.InternId == interID).FirstOrDefault<Intern>();

            //Updating intern details to DB
            if (existingIntern != null)
            {
                existingIntern.Mentor = updateInternRequest.Mentor;
                existingIntern.CurrentTrainings = updateInternRequest.CurrentTrainings;

                await organizationContext.SaveChangesAsync();
            }
            else
            {
                return internDTO;
            }
            return internDTO;
        }

        /// <summary>
        /// Remove an Inter's Details
        /// </summary>
        /// <param name="internID"></param>
        /// <returns></returns>
        [HttpDelete("{interID}")]
        public async Task<string> RemoveInternDetails(int internID)
        {
            var intern = await organizationContext.Interns.FindAsync(internID);

            if (intern == null)
                return "Intern NOT Found.";

            //Deleting intern details to DB
            organizationContext.Interns.Remove(intern);
            await organizationContext.SaveChangesAsync();

            return "Intern Details Removed.";
        }
    }
}
