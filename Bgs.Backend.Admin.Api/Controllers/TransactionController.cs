using Bgs.Backend.Admin.Api.Models.Transaction;
using Bgs.Bll.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bgs.Backend.Admin.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll([FromQuery] TransactionFilterModel filter)
        {
            var transactions = _transactionService.GetTransactions(filter.TypeId, filter.PinCode, filter.DateFrom, filter.DateTo, filter.AmountFrom, filter.AmountTo);

            return Ok(transactions);
        }

    }
}
