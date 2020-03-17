using AutoFixture;

namespace AutomatedTestingFramework.Tests
{
	public abstract class AutoMockingFixtureByClass<TTestType> : AutoMockingTestFixture where TTestType : class
	{
		protected TTestType Sut => Fixture.Freeze<TTestType>();
	}
}