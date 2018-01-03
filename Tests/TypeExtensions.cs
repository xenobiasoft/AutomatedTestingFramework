using System;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace AutomatedTestingFramework.Tests
{
	public static class TypeExtensions
	{
		public static bool IsMockType(this Type target)
		{
			return target.IsGenericType && target.GetGenericTypeDefinition() == typeof(Mock<>);
		}

		public static bool IsGenericEnumerableType(this Type target)
		{
			return target.IsGenericType && target.GetGenericTypeDefinition() == typeof(IEnumerable<>);
		}

		public static Dictionary<string, Type> GetConstructorDependencies(this Type rootType)
		{
			var dependencies = rootType.GetConstructors()
				.SelectMany(x => x.GetParameters())
				.Select(x => new {x.Name, Type = x.ParameterType })
				.Distinct();

			return dependencies.ToDictionary(x => x.Name, x => x.Type);
		}
	}
}