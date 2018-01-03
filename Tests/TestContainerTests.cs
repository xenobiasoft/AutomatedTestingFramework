using NUnit.Framework;

namespace AutomatedTestingFramework.Tests
{
	[TestFixture]
	public class TestContainerTests : BaseTestByClass<RootObject>
	{
		[Test]
		public void TestContainerCanCreateInstanceWithClassDependencies()
		{
			// Assemble

			// Act
			Sut.GetDependantName();

			// Assert
		}
	}

	public class RootObject
	{
		private readonly TestDependency _testDependency;
		private readonly string _someString;
		private readonly int _someNumber;

		public RootObject(TestDependency dependency, string someString, int someNumber)
		{
			_someNumber = someNumber;
			_someString = someString;
			_testDependency = dependency;
		}

		public string GetDependantName()
		{
			return string.IsNullOrEmpty(_someString) ? _testDependency.Name : _someString;
		}
	}

	public class TestDependency
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}