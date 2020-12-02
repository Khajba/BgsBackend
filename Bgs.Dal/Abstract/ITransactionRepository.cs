using Bgs.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Dal.Abstract
{
    public interface ITransactionRepository
    {
        public void AddTransaction(int typeId, int userId, DateTime createDate, decimal amount);

        public IEnumerable<TransactionDto> GetTransactions(int? userId, int? typeId, string pincode, DateTime? dateFrom, DateTime? dateTo, decimal? amountFrom, decimal? amountTo);


    }
}
