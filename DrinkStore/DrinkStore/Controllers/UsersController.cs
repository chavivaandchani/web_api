using AutoMapper;
using DTO;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrinkStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _UserService;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;
        private User user;

        public UsersController(IUserService UserService, IMapper mapper,ILogger<UsersController>logger)
        {
            _UserService = UserService;
            _mapper = mapper;
            _logger = logger;
        }
        // User user = new User();

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<User>> getUsers([FromQuery] string Name, [FromQuery] string password)
        {
            _logger.LogInformation($"Loggin attemped with user name, {Name}");
            try
            {
                user = await _UserService.getUsers(Name, password);
                UserDTO res = _mapper.Map<User, UserDTO>(user);
                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.LogError($"user {Name} not found");
                return NotFound();
            }
          
            return NoContent();
            /*  _logger.LogInformation($"User name: {Name} entered");
              User Suser = await _UserService.getUsers(Name, password);
              UserDTO res = _mapper.Map<User, UserDTO>(Suser);
              if (Suser == null)
                  return NotFound();
              return Ok(Suser);*/
        }
           

    

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO user)

        {
            User resMap = _mapper.Map<UserDTO, User>(user);
            User newUser = await _UserService.insertUser(resMap);
           UserDTO UserAfter = _mapper.Map<User, UserDTO>(newUser);
            if (UserAfter != null)
            {
                return Ok(UserAfter);
            }
            return NoContent();



           // if (newUser == null)
           //     return NotFound();
           // return CreatedAtAction(nameof(Get), new { id = User.Id }, User);

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        
        public void Put(int id, [FromBody] User user)
        {
            _UserService.updateUser(id, user);
        }
        //  public async Task<ActionResult<User>> updateUser([FromQuery] int id, [FromBody] User User)
        // {

        //User newUser = await _UserService.updateUser(id,User);
        // if (newUser == null)
        //    return NotFound();
        // return CreatedAtAction(nameof(Get), new { id = User.Id }, User);
        // }

        // DELETE api/<UsersController>/5
        //  [HttpDelete("{id}")]
        // public void Delete(int id)
        //{
        //  }
    }
}
