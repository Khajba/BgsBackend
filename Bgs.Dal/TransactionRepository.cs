using Bgs.Common.Dtos;
using Bgs.Dal.Abstract;
using Bgs.DataConnectionManager.SqlServer;
using Bgs.DataConnectionManager.SqlServer.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Dal
{
    public class TransactionRepository: SqlServerRepository, ITransactionRepository
    {
        private const string _schemaTransaction = "Transaction";

        public TransactionRepository(IConfiguration configuration)
             : base(configuration, configuration.GetConnectionString("MainDatabase"))
        {

        }

        public void AddTransaction(int typeId, int userId, DateTime createDate, decimal amount)
        {
            using (var cmd = GetSpCommand($"{_schemaTransaction}.AddTransaction"))
            {
                cmd.AddParameter("TypeId", typeId);
                cmd.AddParameter("UserId", userId);
                cmd.AddParameter("CreateDate", createDate);
                cmd.AddParameter("Amount", amount);               

                cmd.ExecuteNonQuery();
            };
        }

        public IEnumerable<TransactionDto> GetTransactions(int? typeId, string pincode, DateTime startDate, DateTime endDate, decimal? amountFrom, decimal? amountTo)
        {
            using (var cmd = GetSpCommand($"{_schemaTransaction}.GetTransactions"))
            {
                cmd.AddParameter("TypeId", typeId);
                cmd.AddParameter("Pincode", pincode);
                cmd.AddParameter("StartDate", startDate);
                cmd.AddParameter("EndDate", endDate);
                cmd.AddParameter("AmountFrom", amountFrom);
                cmd.AddParameter("AmountTo", amountTo);
             

                return cmd.ExecuteReaderClosed<TransactionDto>();
            }
        }
    }
}
