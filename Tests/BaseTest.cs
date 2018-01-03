using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace AutomatedTestingFramework.Tests
{
	public abstract class BaseTest<TTestType> where TTestType : class
	{
		private readonly IFixture _fixture;

		protected BaseTest()
		{
			_fixture = new Fixture().Customize(new AutoConfiguredMoqCustomization());
			_fixture.Behaviors.OfType<ThrowingRecursionBehavior>()
				.ToList()
				.ForEach(b => _fixture.Behaviors.Remove(b));
			_fixture.Behaviors.Add(new OmitOnRecursionBehavior());
		}

		/// <summary>
		/// Creates a new instance of <see cref="TType"></see>.
		/// </summary>
		/// <typeparam name="TType">Any type</typeparam>
		/// <returns>A new instance of TType</returns>
		protected TType Create<TType>()
		{
			return _fixture.Create<TType>();
		}

		/// <summary>
		/// If the specified type has not already been created, creates a new mocked instance
		/// of that type. Otherwise returns the already created mocked instance of that type.
		/// </summary>
		/// <typeparam name="TType">The class, or interface you want to mock.</typeparam>
		/// <returns>A mocked instance of TType.</returns>
		protected Mock<TType> ResolveMock<TType>() where TType : class
		{
			return _fixture.Freeze<Mock<TType>>();
		}
		
		/// <summary>
		/// If the specified type has not already been created, creates a new instance
		/// of that type. Otherwise returns the already created instance of that type.
		/// </summary>
		/// <typeparam name="TType">The class, or interface.</typeparam>
		/// <returns>An instance of TType.</returns>
		protected TType Resolve<TType>() where TType : class
		{
			return _fixture.Freeze<TType>();
		}
		
		public TestContext TestContext { get; set; }
		
		protected TTestType Uut => _fixture.Freeze<TTestType>();
	}
}