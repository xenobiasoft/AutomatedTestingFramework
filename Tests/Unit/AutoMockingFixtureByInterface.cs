using AutoFixture;

namespace AutomatedTestingFramework.UnitTests
{
	public abstract class AutoMockingFixtureByInterface<TTestType, TInterfaceType> : AutoMockingTestFixture where TTestType : class, TInterfaceType
	{
		protected TInterfaceType Sut => Fixture.Freeze<TTestType>();
	}
}