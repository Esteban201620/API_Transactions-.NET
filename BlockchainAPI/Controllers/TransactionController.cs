using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransactionsAPI.Context;
using Microsoft.EntityFrameworkCore;
using TransactionsAPI.DTOs.Users.Creation;
using TransactionsAPI.Entities.Users;

namespace BlockchainAPI.Controllers.Profile
{
    [ApiController]
    [Route("apiBlockchain/transaction")]
    public class TransactionController : Controller
    {

        private readonly IMapper mapper;
        private readonly MySQLDbContext context;

        public TransactionController(IMapper mapper_, MySQLDbContext context_)
        {
            mapper = mapper_;
            context = context_;
        }

        [HttpGet("getAllTransactions")]
        public async Task<ActionResult<List<TransactionQueryDTO>>> GetAllTransactions()
        {
            var userList = await context.Transaction.ToListAsync();
            return mapper.Map<List<TransactionQueryDTO>>(userList);
        }

        [HttpGet("getTransactionForId/{account:int}")]
        public async Task<ActionResult<List<TransactionQueryDTO>>> getUserForId([FromRoute] int account)
        {
            var existe = await context.Transaction.AnyAsync(x => x.fkUser.Equals(account));
            if (existe)
            {
                var var = await context.Transaction.Where(x => x.fkUser.Equals(account)).ToListAsync();
                return mapper.Map<List<TransactionQueryDTO>>(var);
            }

            return NotFound($"Don't Exist transactions for {account} account");
        }

        [HttpPost("createTransaction")]
        public async Task<ActionResult> createTransaction([FromBody] TransactionDTO transDTO)
        {
            //if (await context.Transaction.AnyAsync(x => x.fkUser == transDTO.fkUser))
            //{
            //    return BadRequest($"{transDTO.fkUser} tran already created");
            //}
            var map = mapper.Map<Transaction>(transDTO);
            context.Add(map);
            await context.SaveChangesAsync();
            return Ok("Send Tranaction Successfully");
        }

    }
}
