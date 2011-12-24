﻿using System;
using NUnit.Framework;
using SharpTestsEx;

namespace VerifyArgs.Test
{
	[TestFixture]
	public class CommonPluginsTest
	{
		[Test]
		public void NotNull()
		{
			NotNullAction(new { test = (string)null })
				.Should().Throw<ArgumentNullException>()
				.And.Exception.ParamName.Should().Be("test");
			NotNullAction(new { test = (string)null, test2 = (object)null })
				.Should().Throw<ArgumentNullException>()
				.And.Exception.ParamName.Should().Be("test");
			NotNullAction(new { test = "123", test2 = (object)null })
				.Should().Throw<ArgumentNullException>()
				.And.Exception.ParamName.Should().Be("test2");

			NotNullAction((object)null)();
			NotNullAction(new { test = "123" })();
			NotNullAction(new { test = "123", test2 = 1 })();
		}

		[Test]
		public void NotEmpty()
		{
			NotEmptyAction(new { test = "" })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			NotEmptyAction(new { test = "", test2 = new int[0] })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			NotEmptyAction(new { test = "123", test2 = new int[0] })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test2");

			NotEmptyAction((object)null)();
			NotEmptyAction(new { test = "123" })();
			NotEmptyAction(new { test = "123", test2 = 1 })();
		}

		[Test]
		public void NotNullOrEmpty()
		{
			NotNullOrEmptyAction(new { test = (string)null })
				.Should().Throw<ArgumentNullException>()
				.And.Exception.ParamName.Should().Be("test");
			NotNullOrEmptyAction(new { test = (string)null, test2 = (object)null })
				.Should().Throw<ArgumentNullException>()
				.And.Exception.ParamName.Should().Be("test");
			NotNullOrEmptyAction(new { test = "123", test2 = (object)null })
				.Should().Throw<ArgumentNullException>()
				.And.Exception.ParamName.Should().Be("test2");
			NotNullOrEmptyAction(new { test = "" })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			NotNullOrEmptyAction(new { test = "", test2 = new int[0] })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			NotNullOrEmptyAction(new { test = "123", test2 = new int[0] })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test2");

			NotNullOrEmptyAction((object)null)();
			NotNullOrEmptyAction(new { test = "123" })();
			NotNullOrEmptyAction(new { test = "123", test2 = 1 })();
		}

		private Action NotNullAction<T>(T holder) where T : class
		{
			return Executing.This(() => Verify.Args(holder).NotNull());
		}

		private Action NotEmptyAction<T>(T holder) where T : class
		{
			return Executing.This(() => Verify.Args(holder).NotEmpty());
		}

		private Action NotNullOrEmptyAction<T>(T holder) where T : class
		{
			return Executing.This(() => Verify.Args(holder).NotNullOrEmpty());
		}
	}
}