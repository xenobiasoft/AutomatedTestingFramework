using Ploeh.AutoFixture;

namespace AutomatedTestingFramework.Tests
{
	public abstract class BaseTestByClass<TTestType> : BaseTest where TTestType : class
	{
		protected TTestType Sut => Fixture.Freeze<TTestType>();
	}
}