using Reqnroll;
using Shopping.Models;
using Shopping.Services;
using Xunit;

namespace Shopping.BddTests.StepDefinitions;

[Binding]
public sealed class DiscountSteps
{
    private readonly DiscountService _service = new();
    private decimal _subtotal;
    private MembershipLevel _membershipLevel;
    private decimal _finalPrice;

    [Given("the cart subtotal is {int}")]
    public void GivenTheCartSubtotalIs(int subtotal)
    {
        _subtotal = subtotal;
    }

    [Given("the membership level is {string}")]
    public void GivenTheMembershipLevelIs(string level)
    {
        _membershipLevel = Enum.Parse<MembershipLevel>(
            level, ignoreCase: true);
    }

    [When("the final price is calculated")]
    public void WhenTheFinalPriceIsCalculated()
    {
        _finalPrice = _service.CalculateFinalPrice(
            _subtotal, _membershipLevel);
    }

    [Then("the final price should be {int}")]
    public void ThenTheFinalPriceShouldBe(int expected)
    {
        Assert.Equal((decimal)expected, _finalPrice);
    }
}
