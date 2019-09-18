using Hightower.HelloWorld.Services.Interfaces;
using System;

namespace Hightower.HelloWorld.Core
{
	public class HelloWorldService : IHelloWorldService
	{
		public void SayHello()
		{
			Console.WriteLine("Hello World!");
		}
	}
}
