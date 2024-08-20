using Microsoft.AspNetCore.Mvc;
using StreetVendorsInEvents.Models;
using StreetVendorsInEvents.Repository.Interface;

namespace StreetVendorsInEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class UserController : ControllerBase

    {
        private readonly IUserRepository _userRepository;   

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            if (user == null)
            {
                return BadRequest("User data is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var addedUser = await _userRepository.Add(user);
            return CreatedAtAction(nameof(AddUser), new { id = addedUser.UserId }, addedUser);
        }


    }
}