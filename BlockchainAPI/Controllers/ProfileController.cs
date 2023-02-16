using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransactionsAPI.Context;
using Microsoft.EntityFrameworkCore;
using TransactionsAPI.DTOs.Users.Creation;

namespace BlockchainAPI.Controllers.Profile
{
    [ApiController]
    [Route("apiBlockchain/profile")]
    public class ProfileController : Controller
    {

        private readonly IMapper mapper;
        private readonly MySQLDbContext context;

        public ProfileController(IMapper mapper_, MySQLDbContext context_)
        {
            mapper = mapper_;
            context = context_;
        }

        [HttpGet("getAllCategories")]
        public async Task<ActionResult<List<ProfileDTO>>> GetAllUsers()
        {
            var userList = await context.UserProfile.ToListAsync();
            return mapper.Map<List<ProfileDTO>>(userList);
        }

        [HttpGet("getUserForId/{account:int}")]
        public async Task<ActionResult<ProfileDTO>> getUserForId([FromRoute] int account)
        {
            var existe = await context.UserProfile.AnyAsync(x => x.account.Equals(account));
            if (!existe)
            {
                return NotFound($"The user with account: {account} does not exists");
            }

            var var = await context.UserProfile.FirstOrDefaultAsync(x => x.account.Equals(account));
            return mapper.Map<ProfileDTO>(var);
        }

    }
}
