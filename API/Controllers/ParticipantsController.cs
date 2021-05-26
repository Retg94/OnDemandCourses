using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/participants")]
    public class ParticipantsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ParticipantsController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participant>>> GetParticipants(){
            return Ok(await _unitOfWork.ParticipantRepository.GetParticipantsAsync());
        }

        [HttpPost()]
        public async Task<ActionResult> AddParticipantToCourse(ParticipantViewModel model){
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(model.UserId);
            if(user == null) return BadRequest($"Användaren med id {model.UserId} finns inte i systemet.");

            var course = await _unitOfWork.CourseRepository.GetCourseByIdAsync(model.CourseId);
            if(course == null) return BadRequest($"Kursen med is {model.CourseId} finns inte i systemet.");

            _unitOfWork.ParticipantRepository.Add(model);

            if (await _unitOfWork.Complete())
            {
                return StatusCode(201);
            }

            return StatusCode(500, "Gick inte att spara användaren");
        }
    }
}