using Hightower.HelloWorld.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hightower.HelloWorld.Core
{
	public class AppConsole : IApp
	{
		private readonly IHelloWorldService _helloWorldService;

		public AppConsole(IHelloWorldService helloWorldService)
		{
			_helloWorldService = helloWorldService;
		}

		public void Run()
		{
			_helloWorldService.SayHello();
			System.Console.ReadKey();
		}
	}
}
