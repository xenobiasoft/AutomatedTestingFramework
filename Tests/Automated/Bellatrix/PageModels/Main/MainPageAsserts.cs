using NUnit.Framework;

namespace Bellatrix.PageModels.Main
{
	public class MainPageAsserts
	{
		private readonly MainPageElements _elements;

		public MainPageAsserts(MainPageElements elements)
		{
			_elements = elements;
		}

		public void AssertProductBoxLink(string name, string expectedLink)
		{
			var actualLink = _elements.GetProductBoxByName(name).Href;

			Assert.That(expectedLink, Is.EqualTo(actualLink));
		}
	}
}
