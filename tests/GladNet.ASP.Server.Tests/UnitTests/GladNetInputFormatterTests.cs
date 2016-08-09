using GladNet.ASP.Formatters;
using GladNet.Serializer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladNet.ASP.Server.Tests
{
	[TestFixture]
	public class GladNetInputFormatterTests
	{
		[Test]
		public static void Test_Doesnt_Throw_On_Null_Ctor()
		{
			//assert
			Assert.DoesNotThrow(() => new GladNetInputFormatter(Mock.Of<IDeserializerStrategy>()));
		}

		[Test]
		public static void Test_Doesnt_Throw_On_Invalid_Request_Cant_Read()
		{
			//assert
			IList<MediaTypeHeaderValue> mediaTypes = null;
			GladNetInputFormatter formatter = new GladNetInputFormatter(Mock.Of<IDeserializerStrategy>());

			//act
			MediaTypeHeaderValue.TryParseList(null, out mediaTypes);
		}
	}
}
