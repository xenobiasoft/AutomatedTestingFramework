using NUnit.Framework;

namespace Bellatrix.PageModels.Checkout
{
	public class CheckoutPageAssertions
	{
		private readonly CheckoutPageElements _elements;

		public CheckoutPageAssertions(CheckoutPageElements elements)
		{
			_elements = elements;
		}

		public void AssertOrderReceived()
		{
			Assert.That(_elements.ReceivedMessage.Text, Is.EqualTo("Order received"));
		}
	}
}
