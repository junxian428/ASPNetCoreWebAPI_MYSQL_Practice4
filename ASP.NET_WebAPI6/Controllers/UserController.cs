using ASP.NET_WebAPI6.DTO;
using ASP.NET_WebAPI6.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ASP.NET_WebAPI6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DBContext DBContext;

        public UserController(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var List = await DBContext.Users.Select(
                s => new UserDTO
                {
                    Id = s.Id,
                    Username = s.Username,
                    Mail = s.Mail,
                    PhoneNumber = s.PhoneNumber,
                    Skillsets = s.Skillsets,
                    Hobby = s.Hobby
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult<UserDTO>> GetUserById(int Id)
        {
            UserDTO User = await DBContext.Users.Select(
                    s => new UserDTO
                    {
                        Id = s.Id,
                        Username = s.Username,
                        Mail = s.Mail,
                        PhoneNumber = s.PhoneNumber,
                        Skillsets = s.Skillsets,
                        Hobby = s.Hobby
                    })
                .FirstOrDefaultAsync(s => s.Id == Id);

            if (User == null)
            {
                return NotFound();
            }
            else
            {
                return User;
            }
        }

        [HttpPost("InsertUser")]
        public async Task<HttpStatusCode> InsertUser(UserDTO User)
        {
            var entity = new User()
            {
                Id = User.Id,
                Username = User.Username,
                Mail = User.Mail,
                PhoneNumber = User.PhoneNumber,
                Skillsets = User.Skillsets,
                Hobby = User.Hobby
            };

            DBContext.Users.Add(entity);
            await DBContext.SaveChangesAsync();

            return HttpStatusCode.Created;
        }

        [HttpPut("UpdateUser")]
        public async Task<HttpStatusCode> UpdateUser(UserDTO User)
        {
            var entity = await DBContext.Users.FirstOrDefaultAsync(s => s.Id == User.Id);

            entity.Username = User.Username;
            entity.Mail = User.Mail;
            entity.PhoneNumber = User.PhoneNumber;
            entity.Skillsets = User.Skillsets;
            entity.Hobby = User.Hobby;

            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpDelete("DeleteUser/{Id}")]
        public async Task<HttpStatusCode> DeleteUser(int Id)
        {
            var entity = new User()
            {
                Id = Id
            };
            DBContext.Users.Attach(entity);
            DBContext.Users.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
