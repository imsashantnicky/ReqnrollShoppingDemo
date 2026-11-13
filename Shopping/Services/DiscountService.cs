using Shopping.Models;

namespace Shopping.Services;

public sealed class DiscountService
{
    public decimal CalculateFinalPrice(
        decimal subtotal,
        MembershipLevel membershipLevel)
    {
        if (subtotal < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(subtotal), "Subtotal cannot be negative.");
        }

        decimal rate = membershipLevel switch
        {
            MembershipLevel.Regular => 0.00m,
            MembershipLevel.Silver => 0.05m,
            MembershipLevel.Gold => 0.10m,
            _ => throw new ArgumentOutOfRangeException(
                nameof(membershipLevel), "Membership level is invalid.")
        };

        return subtotal - (subtotal * rate);
    }
}
