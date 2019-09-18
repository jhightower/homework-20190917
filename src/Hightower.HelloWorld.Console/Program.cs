using Hightower.HelloWorld.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Hightower.HelloWorld.Console
{
	class Program
	{
		public static IConfigurationRoot Configuration { get; set; }
		static void Main(string[] args)
		{
			// Set up configuration sources.
			var builder = new ConfigurationBuilder()
					.SetBasePath(Path.Combine(AppContext.BaseDirectory))
					.AddJsonFile("app-settings.json", optional: false);
			Configuration = builder.Build();

			// create service collection
			var serviceCollection = new ServiceCollection();
			var appType = Configuration["IApp"];
			var helloWorldServiceType = Configuration["IHelloWorldService"];
			serviceCollection.AddTransient(typeof(IHelloWorldService), Type.GetType(helloWorldServiceType, true));
			serviceCollection.AddTransient(typeof(IApp), Type.GetType(appType, true));

			// create service provider
			var serviceProvider = serviceCollection.BuildServiceProvider();

			// entry to run app
			serviceProvider.GetService<IApp>().Run();
		}
	}
}
