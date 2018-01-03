using System.Collections.Specialized;
using System.Configuration;
using AutomatedTestingFramework.Core.Config;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomatedTestingFramework.Tests.Core.Config
{
	[TestClass]
	public class AppConfigurationTests : BaseTest<AppConfiguration>
	{
		private NameValueCollection _appSettingsConfig;

		[TestMethod]
		[TestCategory(TestCategories.Core)]
		public void LoadsBaseUrl()
		{
			// Assemble
			var expectedValue = _appSettingsConfig["BaseUrl"];

			// Act
			var actual = Uut.BaseUrl;

			// Assert
			expectedValue.Should().Be(actual);
		}

		[TestMethod]
		[TestCategory(TestCategories.Core)]
		public void LoadsDefaultUsername()
		{
			// Assemble
			var expectedValue = _appSettingsConfig["DefaultTestUsername"];

			// Act
			var actual = Uut.DefaultTestUsername;

			// Assert
			expectedValue.Should().Be(actual);
		}

		[TestMethod]
		[TestCategory(TestCategories.Core)]
		public void LoadsDefaultPassword()
		{
			// Assemble
			var expectedValue = _appSettingsConfig["DefaultTestPassword"];

			// Act
			var actual = Uut.DefaultTestPassword;

			// Assert
			expectedValue.Should().Be(actual);
		}

		[TestMethod]
		[TestCategory(TestCategories.Core)]
		public void LoadsMediaFolderPath()
		{
			// Assemble
			var expectedValue = _appSettingsConfig["MediaFolderPath"];

			// Act
			var actual = Uut.MediaFolderPath;

			// Assert
			expectedValue.Should().Be(actual);
		}

		[TestMethod]
		[TestCategory(TestCategories.Core)]
		public void LoadsAllowVideoRecording()
		{
			// Assemble
			var expectedValue = bool.Parse(_appSettingsConfig["AllowVideoRecording"]);

			// Act
			var actual = Uut.AllowVideoRecording;

			// Assert
			expectedValue.Should().Be(actual);
		}

		[TestMethod]
		[TestCategory(TestCategories.Core)]
		public void IsTestModeReturnsDefaultTrueValue()
		{
			// Assemble

			// Act
			var actual = Uut.IsTestMode;

			// Assert
			actual.Should().BeTrue();
		}
		
		[TestInitialize]
		public void Initialize()
		{
			_appSettingsConfig = ConfigurationManager.AppSettings;
		}
	}
}