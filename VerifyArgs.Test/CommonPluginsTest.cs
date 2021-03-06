﻿using System;
using NUnit.Framework;

namespace VerifyArgs.Test
{
	[TestFixture]
	public class CommonPluginsTest : CommonPluginsTestBase
	{
		protected override Action NotNullAction<T>(T holder)
		{
			return () => Verify.Args(holder).NotNull();
		}

		protected override Action NotEmptyAction<T>(T holder)
		{
			return () => Verify.Args(holder).NotEmpty();
		}

		protected override Action NotDefaultAction<T>(T holder)
		{
			return () => Verify.Args(holder).NotDefault();
		}

		protected override Action NotNullOrEmptyAction<T>(T holder)
		{
			return () => Verify.Args(holder).NotNullOrEmpty();
		}
	}
}
