using Ploeh.AutoFixture;

namespace AutomatedTestingFramework.Tests
{
	public abstract class BaseTestByInterface<TTestType, TInterfaceType> : BaseTest where TTestType : class, TInterfaceType
	{
		protected TInterfaceType Sut => Fixture.Freeze<TTestType>();
	}
}