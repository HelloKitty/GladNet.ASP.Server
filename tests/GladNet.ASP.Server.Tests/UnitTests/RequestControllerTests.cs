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

		[Test]
		public void Test_Doesnt_Throw_On_Invalid_Model()
		{
			//arrange
			TestController controller = new TestController();

			//act
			Task<IActionResult> result = controller.Post(null);

			//assert
			Assert.NotNull(result);
			Assert.DoesNotThrow(() => result.Wait());
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
