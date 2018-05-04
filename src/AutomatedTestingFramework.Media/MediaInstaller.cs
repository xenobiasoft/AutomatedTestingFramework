using Autofac;
using AutomatedTestingFramework.Core.ExecutionEngine;
using AutomatedTestingFramework.Media.VideoRecorder;

namespace AutomatedTestingFramework.Media
{
	public class MediaInstaller : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ExpressionEncoderVideoRecorder>().As<IVideoRecorder>();
			builder.RegisterType<VideoRecorderObserver>().As<ITestObserver>();
		}
	}
}