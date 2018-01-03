using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomatedTestingFramework.Tests
{
	[TestClass]
	public class TestContainerTests : BaseTest<RootObject>
	{
		[TestMethod]
		public void TestContainerCanCreateInstanceWithClassDependencies()
		{
			// Assemble

			// Act
			Uut.GetDependantName();

			// Assert
		}
	}

	public class RootObject
	{
		private readonly TestDependency _TestDependency;
		private readonly string _SomeString;
		private readonly int _SomeNumber;

		public RootObject(TestDependency dependency, string someString, int someNumber)
		{
			_SomeNumber = someNumber;
			_SomeString = someString;
			_TestDependency = dependency;
		}

		public string GetDependantName()
		{
			return string.IsNullOrEmpty(_SomeString) ? _TestDependency.Name : _SomeString;
		}
	}

	public class TestDependency
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}