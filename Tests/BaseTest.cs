using System.Linq;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace AutomatedTestingFramework.Tests
{
	public abstract class BaseTest
	{
		private IFixture _fixture;

		[SetUp]
		public void Initialize()
		{
			Fixture.Behaviors.OfType<ThrowingRecursionBehavior>()
				.ToList()
				.ForEach(x => Fixture.Behaviors.Remove(x));
			Fixture.Behaviors.Add(new OmitOnRecursionBehavior());

			SetUp();
		}

		[TearDown]
		public void Cleanup()
		{
			_fixture = null;

			TearDown();
		}

		public virtual void SetUp()
		{ }

		public virtual void TearDown()
		{ }

		protected TType Create<TType>()
		{
			return Fixture.Create<TType>();
		}

		protected TType Resolve<TType>() where TType : class
		{
			return Fixture.Freeze<TType>();
		}

		protected Mock<TType> ResolveMock<TType>() where TType : class
		{
			return Fixture.Freeze<Mock<TType>>();
		}

		protected IFixture Fixture => _fixture ?? (_fixture = new Fixture().Customize(new AutoConfiguredMoqCustomization()));

		public TestContext TestContext => TestContext.CurrentContext;
	}
}