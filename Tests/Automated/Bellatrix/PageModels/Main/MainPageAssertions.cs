using NUnit.Framework;

namespace Bellatrix.PageModels.Main
{
	public class MainPageAssertions
	{
		private readonly MainPageElements _elements;

		public MainPageAssertions(MainPageElements elements)
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
