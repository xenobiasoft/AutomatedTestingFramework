using System.Collections.Specialized;
using System.Configuration;
using AutomatedTestingFramework.Core.Config;
using FluentAssertions;
using NUnit.Framework;

namespace AutomatedTestingFramework.Tests.Core.Config
{
	[TestFixture]
	public class AppConfigurationTests : AutoMockingFixtureByInterface<AppConfiguration, IAppConfiguration>
	{
		private NameValueCollection _appSettingsConfig;

		[Test]
		[Category(TestCategories.Core)]
		public void LoadsBaseUrl()
		{
			// Assemble
			var expectedValue = _appSettingsConfig["BaseUrl"];

			// Act
			var actual = Sut.BaseUrl;

			// Assert
			expectedValue.Should().Be(actual);
		}

		[Test]
		[Category(TestCategories.Core)]
		public void LoadsMediaFolderPath()
		{
			// Assemble
			var expectedValue = _appSettingsConfig["MediaFolderPath"];

			// Act
			var actual = Sut.MediaFolderPath;

			// Assert
			expectedValue.Should().Be(actual);
		}

		[Test]
		[Category(TestCategories.Core)]
		public void LoadsAllowVideoRecording()
		{
			// Assemble
			var expectedValue = bool.Parse(_appSettingsConfig["AllowVideoRecording"]);

			// Act
			var actual = Sut.AllowVideoRecording;

			// Assert
			expectedValue.Should().Be(actual);
		}

		[Test]
		[Category(TestCategories.Core)]
		public void IsTestModeReturnsDefaultTrueValue()
		{
			// Assemble

			// Act
			var actual = Sut.IsTestMode;

			// Assert
			actual.Should().BeTrue();
		}
		
		public override void SetUp()
		{
			_appSettingsConfig = ConfigurationManager.AppSettings;
		}
	}
}