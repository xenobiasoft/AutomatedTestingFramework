using AutoFixture;

namespace AutomatedTestingFramework.UnitTests
{
	public abstract class AutoMockingFixtureByClass<TTestType> : AutoMockingTestFixture where TTestType : class
	{
		protected TTestType Sut => Fixture.Freeze<TTestType>();
	}
}