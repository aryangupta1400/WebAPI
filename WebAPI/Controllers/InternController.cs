﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DBModels;
using Model.Request;
using Model.RequestModels;
using Model.ResponseModels;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Implementing WebAPI using on DB 
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
        [HttpGet("fetch-intern-details")]
        public async Task<List<InternDTO>> FetchInternDetails()
        {
            List<InternDTO> interns = await organizationContext.Interns.Select(i => new InternDTO()
            {
                InternId = i.InternId,
                Mentor = i.Mentor,
                CurrentTrainings = i.CurrentTrainings
            }).ToListAsync();

            return interns;
        }

        /// <summary>
        /// Adding a new Intern's Details to DB
        /// </summary>
        /// <returns></returns>
        [HttpPost("add-intern-details")]
        public async Task<Intern> AddInternDetails(AddInternRequest addInternRequest)
        {
            Intern intern = new Intern()
            {   
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
            return intern;
        }

        /// <summary>
        /// Updating an Intern's Detail
        /// </summary>
        /// <param name="internDTO">Object to refrence existing object and print output</param>
        /// <returns></returns>
        [HttpPut("update-intern-details")]
        public async Task<InternDTO> UpdateInternDetails(InternDTO internDTO)
        {            
            var existingIntern = organizationContext.Interns.Where(i => i.InternId == internDTO.InternId).FirstOrDefault<Intern>();

            if (existingIntern != null)
            {
                existingIntern.Mentor = internDTO.Mentor;
                existingIntern.CurrentTrainings = internDTO.CurrentTrainings;

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
        [HttpDelete("delete-intern-details")]
        public async Task<string> RemoveInternDetails(int internID)
        {       
            var intern = await organizationContext.Interns.FindAsync(internID);

            if (intern == null)
                return "Intern NOT Found.";

            organizationContext.Interns.Remove(intern);
            await organizationContext.SaveChangesAsync();

            return "Intern Details Removed.";
        }
    }
}
