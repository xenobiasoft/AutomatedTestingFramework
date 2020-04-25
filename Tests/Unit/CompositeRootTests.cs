using System;
using System.Linq;
using Autofac;
using Autofac.Core;
using AutomatedTestingFramework.Selenium.CompositeRoot;
using NUnit.Framework;

namespace AutomatedTestingFramework.UnitTests
{
	[TestFixture]
	public class CompositeRootTests
	{
		private IContainer _container;

		[Test]
		public void Container_CanResolveAllTypes()
		{
			var componentRegistrations = _container
				.ComponentRegistry
				.Registrations
				.Where(x => x.Ownership == InstanceOwnership.OwnedByLifetimeScope)
				.ToList();

			foreach (var registration in componentRegistrations)
			{
				var registrationServices = registration
					.Services
					.Where(x => !x.Description.StartsWith("Decorator"))
					.ToList();
				foreach (var service in registrationServices)
				{
					var registeredTargetType = service.Description;
					var type = GetType(registeredTargetType);

					if (type == null)
					{
						Assert.Fail($"Failed to parse type {registeredTargetType}");
					}

					var instance = _container.Resolve(type);

					Assert.That(instance, Is.AssignableTo(type));
				}
			}
		}

		[SetUp]
		public void Setup()
		{
			_container = CompositeRoot.Root;
		}

		private static Type GetType(string typeName)
		{
			var type = Type.GetType(typeName);

			if (type != null)
			{
				return type;
			}

			var frameworkAssembly = typeof(CompositeRoot).Assembly;

			type = frameworkAssembly.GetType(typeName);

			return type != null ? type : null;
		}
	}
}