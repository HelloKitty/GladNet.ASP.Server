using GladNet.Payload;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GladNet.ASP.Server.Tests
{
	[TestFixture]
	[PayloadRoute(typeof(PacketPayload))]
	public class PayloadRouteAttributeTests
	{
		[Test]
		public static void Test_Payload_Route_Attribute_Doesnt_Throw_On_Valid_Payload()
		{
			Assert.DoesNotThrow(() => typeof(PayloadRouteAttributeTests).GetCustomAttribute<PayloadRouteAttribute>());
		}

		[Test]
		public static void Test_Payload_Route_Attribute_Contains_PayloadName_In_Route()
		{
			Assert.IsTrue(typeof(PayloadRouteAttributeTests).GetCustomAttribute<PayloadRouteAttribute>().Template.Contains("Packet"));
		}
	}
}
