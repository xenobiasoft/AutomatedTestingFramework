﻿using System;

namespace AutomatedTestingFramework.Selenium.Elements
{
	public class LogElement : ElementDecorator
	{
		public LogElement(Element element) : base(element)
		{
		}

		public override bool? Displayed
		{
			get
			{
				Console.WriteLine($"Element Disabled = {Element?.Displayed}");
				return Element?.Displayed;
			}
		}

		public override bool? Enabled
		{
			get
			{
				Console.WriteLine($"Element Enabled = {Element?.Enabled}");
				return Element?.Enabled;
			}
		}

		public override string Text
		{
			get
			{
				Console.WriteLine($"Element Text = {Element?.Text}");
				return Element?.Text;
			}
		}

		public override void Click()
		{
			Console.WriteLine("Element Clicked");
			Element?.Click();
		}

		public override string GetAttribute(string attributeName)
		{
			Console.WriteLine($"Get Element's Attribute = {attributeName}");
			return Element?.GetAttribute(attributeName);
		}

		public override void TypeText(string text)
		{
			Console.WriteLine($"Element Type Text = {text}");
			Element?.TypeText(text);
		}
	}
}
