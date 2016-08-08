using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GladNet.ASP.Server;
using GladNet.Payload;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace GladNet.ASP.Server.Tests
{
	[TestFixture]
	class RequestControllerTests
	{
		[Test]
		public void Test_Ctor_Doesnt_Throw()
		{
			//assert
			Assert.DoesNotThrow(() => new TestController());
		}
	}

	public class TestController : RequestController<PacketPayload>
	{
		public override Task<PacketPayload> HandlePost(PacketPayload payloadInstance)
		{
			throw new NotImplementedException();
		}
	}
}
