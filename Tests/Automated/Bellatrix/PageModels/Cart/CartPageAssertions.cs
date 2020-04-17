using NUnit.Framework;

namespace Bellatrix.PageModels.Cart
{
	public class CartPageAssertions
	{
		private readonly CartPageElements _elements;

		public CartPageAssertions(CartPageElements elements)
		{
			_elements = elements;
		}

		public void AssertCouponAppliedSuccessfully()
		{
			Assert.That(_elements.MessageAlert.Text, Is.EqualTo(("Coupon code applied successfully.")));
		}

		public void AssertTotalPrice(string expectedTotalPrice)
		{
			Assert.That(_elements.Total.Text, Is.EqualTo(expectedTotalPrice));
		}
	}
}
