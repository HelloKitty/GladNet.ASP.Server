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
using Microsoft.AspNetCore.Authorization;

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

		[Test]
		public void Test_Can_Find_Authoize_Attribute_On_OverridedPost()
		{
			//arrange
			RequestController<PacketPayload> controller = new TestControllerAuthenticated();

			//act
			Assert.IsNotNull(controller.GetType().GetMethod(nameof(controller.Post)).GetCustomAttribute(typeof(AuthorizeAttribute), false));
		}
	}

	public class TestController : RequestController<PacketPayload>
	{
		protected override Task<PacketPayload> HandlePost(PacketPayload payloadInstance)
		{
			throw new NotImplementedException();
		}
	}
	public class TestControllerAuthenticated : AuthenticatedRequestController<PacketPayload>
	{
		protected override Task<PacketPayload> HandlePost(PacketPayload payloadInstance)
		{
			throw new NotImplementedException();
		}
	}

}
