using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Common.Dtos
{
    public class AdminUserDetailsDto
    {
        public UserDto UserDetails { get; set; }

        public IEnumerable<OrderDto> UserOrders { get; set; }

        public IEnumerable<TransactionDto> Transactions { get; set; }
    }
}
