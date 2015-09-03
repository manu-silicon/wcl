﻿using System;
using System.Runtime.InteropServices;

namespace WCL.Structs
{

	[StructLayout (LayoutKind.Sequential)]
	public struct Rect
	{
		public int left, top, right, bottom;

		public Rect (int a_left, int a_top, int a_right, int a_bottom)
		{
			left = a_left;
			top = a_top;
			right = a_right;
			bottom = a_bottom;
		}

		public int x
		{
			get { return left; }
			set { right -= (left - value); left = value; }
		}

		public int y
		{
			get { return top; }
			set { bottom -= (top - value); top = value; }
		}

		public int height
		{
			get { return bottom - top; }
			set { bottom = value + top; }
		}

		public int width
		{
			get { return right - left; }
			set { right = value + left; }
		}

		public Point location
		{
			get { return new Point (left, top); }
			set { x = value.x; y = value.y; }
		}

//		public Size Size
//		{
//			get { return new Size (width, height); }
//			set { Width = value.width; height = value.height; }
//		}

		public static bool operator ==(Rect r1, Rect r2)
		{
			return r1.Equals (r2);
		}

		public static bool operator !=(Rect r1, Rect r2)
		{
			return !r1.Equals (r2);
		}

		public bool Equals (Rect r)
		{
			return r.left == left && r.top == top && r.right == right && r.bottom == bottom;
		}

		public override bool Equals(object obj)
		{
			if (obj is Rect) {
				return Equals((Rect) obj);
			} else {
				return false;
			}
		}

		// Taken from http://referencesource.microsoft.com/#System.Drawing/commonui/System/Drawing/Rectangle.cs,17559e21008f381d
		public override int GetHashCode ()
		{
			return (int)((UInt32) x ^
						(((UInt32) y << 13) | ((UInt32) y >> 19)) ^
						(((UInt32) width << 26) | ((UInt32) width >> 6)) ^
						(((UInt32) height << 7) | ((UInt32) height >> 25)));
		}

		public override string ToString ()
		{
			return string.Format (System.Globalization.CultureInfo.CurrentCulture, "{{left={0},top={1},right={2},bottom={3}}}", left, top, right, bottom);
		}
	}
}