using Bgs.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Dal.Abstract
{
    public interface ITransactionRepository
    {
        public void AddTransaction(int typeId, int userId, DateTime createDate, decimal amount);

        public IEnumerable<TransactionDto> GetTransactions(int? typeId, string pincode, DateTime startDate, DateTime endDate, decimal? amountFrom, decimal? amountTo);


    }
}
