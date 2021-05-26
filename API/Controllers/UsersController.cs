using Microsoft.AspNetCore.Mvc;
using API.Data;
using System.Collections.Generic;
using API.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.ViewModels;
using API.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(){
            return Ok(await _unitOfWork.UserRepository.GetUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id){
            return Ok(await _unitOfWork.UserRepository.GetUserByIdAsync(id));
        }

        [HttpPost()]
        public async Task<ActionResult> AddUser(UserViewModel model){
            _unitOfWork.UserRepository.Add(model);
            if (await _unitOfWork.Complete())
            {
                return StatusCode(201);
            }

            return StatusCode(500, "Gick inte att spara användaren");
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateUser (int id, UserViewModel updatedUser){

            _unitOfWork.UserRepository.Update(updatedUser, id);
            if (await _unitOfWork.UserRepository.SaveAllAsync()) return NoContent();

            return StatusCode(500, "Det gick inte att uppdatera användaren");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id){
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
            if(user == null) return NotFound($"Tyvärr hittades ingen användare med id {id}");

            _unitOfWork.UserRepository.Delete(user);
            if (await _unitOfWork.UserRepository.SaveAllAsync()) return NoContent();

            return StatusCode(500, "Gick inte att ta bort användaren");
        }

    }
}