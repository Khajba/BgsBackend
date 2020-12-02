using Bgs.Bll.Abstract;
using Bgs.Common.Dtos;
using Bgs.Dal.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Bll
{
    public class TransactionService : ITransactionService
    {

        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<TransactionDto> GetTransactions(int? typeId, string pinCode, DateTime? dateFrom, DateTime? dateTo, decimal? amountFrom, decimal? amountTo)
        {
            return _transactionRepository.GetTransactions(null, typeId, pinCode, dateFrom, dateTo, amountFrom, amountTo);
        }
    }
}
