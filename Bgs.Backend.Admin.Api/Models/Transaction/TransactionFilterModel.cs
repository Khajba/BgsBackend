using System;

namespace Bgs.Backend.Admin.Api.Models.Transaction
{
    public class TransactionFilterModel
    {
        public int? TypeId { get; set; }

        public string PinCode { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public decimal? AmountFrom { get; set; }

        public decimal? AmountTo { get; set; }

        public int? PageNumber { get; set; } = 0;

        public int? PageSize { get; set; } = 10;
    }
}
