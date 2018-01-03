using AutomatedTestingFramework.Behaviors.ExecutionEngine;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Core.ExecutionEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestExecutionEventArgs = AutomatedTestingFramework.Core.ExecutionEngine.TestExecutionEventArgs;

namespace AutomatedTestingFramework.Tests.Behaviors.ExecutionEngine
{
	[TestClass]
	public class TestExecutionProviderTests : BaseTest<TestExecutionProvider>
	{
		protected Mock<ITestObserver> MockObserver;

		[TestClass]
		public class PreTestInitTests : TestExecutionProviderTests
		{
			[TestMethod]
			[TestCategory(TestCategories.Behaviors)]
			public void PreTestInitRaisesPreTestInitEvent()
			{
				// Assemble
				
				// Act
				Uut.PreTestInit(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Once);
			}

			[TestMethod]
			[TestCategory(TestCategories.Behaviors)]
			public void PreTestInitDoesNotRaiseEventForOtherEvents()
			{
				// Assemble

				// Act
				Uut.PreTestInit(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
			}

			[TestMethod]
			[TestCategory(TestCategories.Behaviors)]
			public void UnsubscribingDoesNotReceiveAnyCalls()
			{
				// Assemble
				Uut.Unsubscribe(MockObserver.Object);

				// Act
				Uut.PreTestInit(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PreTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
			}
		}

		[TestClass]
		public class PreTestCleanupTests : TestExecutionProviderTests
		{
			[TestMethod]
			[TestCategory(TestCategories.Behaviors)]
			public void PreTestCleanupRaisesPreTestCleanupEvent()
			{
				// Assemble

				// Act
				Uut.PreTestCleanup(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Once);
			}

			[TestMethod]
			[TestCategory(TestCategories.Behaviors)]
			public void PreTestCleanupDoesNotRaiseEventForOtherEvents()
			{
				// Assemble

				// Act
				Uut.PreTestCleanup(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
			}

			[TestMethod]
			[TestCategory(TestCategories.Behaviors)]
			public void UnsubscribingDoesNotReceiveAnyCalls()
			{
				// Assemble
				Uut.Unsubscribe(MockObserver.Object);

				// Act
				Uut.PreTestCleanup(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PreTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
			}
		}

		[TestClass]
		public class PostTestInitTests : TestExecutionProviderTests
		{
			[TestMethod]
			[TestCategory(TestCategories.Behaviors)]
			public void PostTestInitRaisesPostTestInitEvent()
			{
				// Assemble

				// Act
				Uut.PostTestInit(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PostTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Once);
			}

			[TestMethod]
			[TestCategory(TestCategories.Behaviors)]
			public void PostTestInitDoesNotRaiseEventForOtherEvents()
			{
				// Assemble

				// Act
				Uut.PostTestInit(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PreTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
			}

			[TestMethod]
			[TestCategory(TestCategories.Behaviors)]
			public void UnsubscribingDoesNotReceiveAnyCalls()
			{
				// Assemble
				Uut.Unsubscribe(MockObserver.Object);

				// Act
				Uut.PostTestInit(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PreTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
			}
		}

		[TestClass]
		public class PostTestCleanupTests : TestExecutionProviderTests
		{

			[TestMethod]
			[TestCategory(TestCategories.Behaviors)]
			public void PostTestCleanupRaisesPostTestCleanupEvent()
			{
				// Assemble

				// Act
				Uut.PostTestCleanup(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PostTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Once);
			}

			[TestMethod]
			[TestCategory(TestCategories.Behaviors)]
			public void PostTestCleanupDoesNotRaiseEventForOtherEvents()
			{
				// Assemble

				// Act
				Uut.PostTestCleanup(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PreTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
			}

			[TestMethod]
			[TestCategory(TestCategories.Behaviors)]
			public void UnsubscribingDoesNotReceiveAnyCalls()
			{
				// Assemble
				Uut.Unsubscribe(MockObserver.Object);

				// Act
				Uut.PostTestCleanup(TestOutcome.InProgress, Create<string>(), null);

				// Assert
				MockObserver.Verify(x => x.PreTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PreTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestInit(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
				MockObserver.Verify(x => x.PostTestCleanup(It.IsAny<object>(), It.IsAny<TestExecutionEventArgs>()), Times.Never);
			}
		}

		[TestInitialize]
		public void Initialize()
		{
			MockObserver = ResolveMock<ITestObserver>();
			Uut.Subscribe(MockObserver.Object);
		}
	}
}