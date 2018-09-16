using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subliminal_Messages
{
	internal class Configuration
	{
		public int OnInterval
		{
			get;
			set;
		}

		public int OffInterval
		{
			get;
			set;
		}

		public string Text
		{
			get;
			set;
		}

		public Brush TextColor
		{
			get;
			set;
		}

		public FontFamily TextFont
		{
			get;
			set;
		}

		public double TextSize
		{
			get;
			set;
		}

		public double TextOpacity
		{
			get;
			set;
		}

		public bool OnlyPrimaryMonitor
		{
			get;
			set;
		}
	}
}
