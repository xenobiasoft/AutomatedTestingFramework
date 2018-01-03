using System;

namespace AutomatedTestingFramework.Core
{
	public interface IResolver : IDisposable
	{
		TType Resolve<TType>();
	}
}