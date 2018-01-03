using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Core.ExecutionEngine;
using Moq;
using NUnit.Framework;
using TestExecutionEventArgs = AutomatedTestingFramework.Core.ExecutionEngine.TestExecutionEventArgs;

namespace AutomatedTestingFramework.Tests.Media.ExecutionEngine
{
	[TestFixture]
	public class TestExecutionProviderTests : BaseTestByClass<TestExecutionProvider>
	{
		protected Mock<ITestObserver> MockObserver;

		[TestFixture]
		public class PreTestInitTests : TestExecutionProviderTests
		{
			[Test]
			[Category(TestCategories.Core)]
			public void PreTestInitRaisesPreTestInitEvent()
			{
				// Assemble
				
				// Act
				Sut.PreTestInit(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Once);
			}

			[Test]
			[Category(TestCategories.Core)]
			public void PreTestInitDoesNotRaiseEventForOtherEvents()
			{
				// Assemble

				// Act
				Sut.PreTestInit(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
			}

			[Test]
			[Category(TestCategories.Core)]
			public void UnsubscribingDoesNotReceiveAnyCalls()
			{
				// Assemble
				Sut.Unsubscribe(MockObserver.Object);

				// Act
				Sut.PreTestInit(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PreTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
			}
		}

		[TestFixture]
		public class PreTestCleanupTests : TestExecutionProviderTests
		{
			[Test]
			[Category(TestCategories.Core)]
			public void PreTestCleanupRaisesPreTestCleanupEvent()
			{
				// Assemble

				// Act
				Sut.PreTestCleanup(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Once);
			}

			[Test]
			[Category(TestCategories.Core)]
			public void PreTestCleanupDoesNotRaiseEventForOtherEvents()
			{
				// Assemble

				// Act
				Sut.PreTestCleanup(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
			}

			[Test]
			[Category(TestCategories.Core)]
			public void UnsubscribingDoesNotReceiveAnyCalls()
			{
				// Assemble
				Sut.Unsubscribe(MockObserver.Object);

				// Act
				Sut.PreTestCleanup(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PreTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
			}
		}

		[TestFixture]
		public class PostTestInitTests : TestExecutionProviderTests
		{
			[Test]
			[Category(TestCategories.Core)]
			public void PostTestInitRaisesPostTestInitEvent()
			{
				// Assemble

				// Act
				Sut.PostTestInit(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PostTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Once);
			}

			[Test]
			[Category(TestCategories.Core)]
			public void PostTestInitDoesNotRaiseEventForOtherEvents()
			{
				// Assemble

				// Act
				Sut.PostTestInit(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PreTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
			}

			[Test]
			[Category(TestCategories.Core)]
			public void UnsubscribingDoesNotReceiveAnyCalls()
			{
				// Assemble
				Sut.Unsubscribe(MockObserver.Object);

				// Act
				Sut.PostTestInit(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PreTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
			}
		}

		[TestFixture]
		public class PostTestCleanupTests : TestExecutionProviderTests
		{

			[Test]
			[Category(TestCategories.Core)]
			public void PostTestCleanupRaisesPostTestCleanupEvent()
			{
				// Assemble

				// Act
				Sut.PostTestCleanup(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PostTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Once);
			}

			[Test]
			[Category(TestCategories.Core)]
			public void PostTestCleanupDoesNotRaiseEventForOtherEvents()
			{
				// Assemble

				// Act
				Sut.PostTestCleanup(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PreTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
			}

			[Test]
			[Category(TestCategories.Core)]
			public void UnsubscribingDoesNotReceiveAnyCalls()
			{
				// Assemble
				Sut.Unsubscribe(MockObserver.Object);

				// Act
				Sut.PostTestCleanup(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PreTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
			}
		}

		public override void SetUp()
		{
			MockObserver = ResolveMock<ITestObserver>();
			Sut.Subscribe(MockObserver.Object);
		}
	}
}