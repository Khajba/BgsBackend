namespace Bgs.Common.Dtos
{
    public class UserAccountDto
    {
        public UserDto UserDetails { get; set; }

        public UserAddressDto UserAddress { get; set; }

        public UserPaymentDto PaymentDetails { get; set; }
    }
}