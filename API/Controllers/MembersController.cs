using API.Data;
using API.Entitites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class MembersController(AppDbContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members = await context.Users.ToListAsync();

            return members;
        }

        [Authorize]
        [HttpGet("{Id}")]
        public async Task<ActionResult<AppUser>> GetMember(string Id)
        {
            var member = await context.Users.FindAsync(Id);

            if (member == null) return NotFound();

            return member;
        }
        
    }
}
