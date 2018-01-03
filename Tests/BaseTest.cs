using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace AutomatedTestingFramework.Tests
{
	public abstract class BaseTest<TTestType> where TTestType : class
	{
		private readonly IFixture _Fixture;

		protected BaseTest()
		{
			_Fixture = new Fixture().Customize(new AutoConfiguredMoqCustomization());
			_Fixture.Behaviors.OfType<ThrowingRecursionBehavior>()
				.ToList()
				.ForEach(b => _Fixture.Behaviors.Remove(b));
			_Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
		}

		/// <summary>
		/// Creates a new instance of <cref="TType"></cref>.
		/// </summary>
		/// <typeparam name="TType">Any type</typeparam>
		/// <returns>A new instance of TType</returns>
		protected TType Create<TType>()
		{
			return _Fixture.Create<TType>();
		}

		/// <summary>
		/// If the specified type has not already been created, creates a new mocked instance
		/// of that type. Otherwise returns the already created mocked instance of that type.
		/// </summary>
		/// <typeparam name="TType">The class, or interface you want to mock.</typeparam>
		/// <returns>A mocked instance of TType.</returns>
		protected Mock<TType> ResolveMock<TType>() where TType : class
		{
			return _Fixture.Freeze<Mock<TType>>();
		}
		
		/// <summary>
		/// If the specified type has not already been created, creates a new instance
		/// of that type. Otherwise returns the already created instance of that type.
		/// </summary>
		/// <typeparam name="TType">The class, or interface.</typeparam>
		/// <returns>An instance of TType.</returns>
		protected TType Resolve<TType>() where TType : class
		{
			return _Fixture.Freeze<TType>();
		}
		
		public TestContext TestContext { get; set; }
		
		protected TTestType Uut => _Fixture.Freeze<TTestType>();
	}
}