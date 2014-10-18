﻿using System;
using Moq;
using SharpEssentials;
using Xunit;

namespace Tests.Unit.SharpEssentials
{
	public class DisposableExtensionsTests
	{
		[Fact]
		public void Test_DisposeSafely()
		{
			// Arrange.
			var disposable = new Mock<IDisposable>();

			// Act.
			disposable.Object.DisposeSafely();

			// Assert.
			disposable.Verify(d => d.Dispose());
		}

		[Fact]
		public void Test_DisposeSafely_DoesNotThrow_ForNull()
		{
			// Arrange.
			IDisposable disposable = null;

			// Act/Assert.
			Assert.DoesNotThrow(() => disposable.DisposeSafely());
		}
	}
}