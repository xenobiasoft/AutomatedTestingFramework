﻿using System;

namespace AutomatedTestingFramework.Core
{
	public class ElementTimeoutException : Exception
	{
		public ElementTimeoutException()
		{
		}

		public ElementTimeoutException(string message) : base(message)
		{
		}

		public ElementTimeoutException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}