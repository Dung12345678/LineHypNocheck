﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace BMS
{

	public class MessageHelper
	{

		[DllImport("User32.dll")]

		private static extern int RegisterWindowMessage(string lpString);
		//	[DllImport("User32.dll", EntryPoint = "FindWindow")]
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern Int32 FindWindow(String lpClassName, String lpWindowName);
		[DllImport("User32.Dll")]
		public static extern int GetClassName(int hwnd, StringBuilder lpClassName, int nMaxCount);
		//For use with WM_COPYDATA and COPYDATASTRUCT
		[DllImport("User32.dll", EntryPoint = "SendMessage")]
		public static extern int SendMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);
		//For use with WM_COPYDATA and COPYDATASTRUCT
		[DllImport("User32.dll", EntryPoint = "PostMessage")]
		public static extern int PostMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);
		[DllImport("User32.dll", EntryPoint = "SendMessage")]
		public static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);
		[DllImport("User32.dll", EntryPoint = "PostMessage")]
		public static extern int PostMessage(int hWnd, int Msg, int wParam, int lParam);
		[DllImport("User32.dll", EntryPoint = "SetForegroundWindow")]



		public static extern bool SetForegroundWindow(int hWnd);
		public const int WM_USER = 0x400;
		public const int WM_COPYDATA = 0x4A;

		//Used for WM_COPYDATA for string messages

		public struct COPYDATASTRUCT
		{
			public IntPtr dwData;
			public int cbData;
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpData;
		}
		public bool bringAppToFront(int hWnd)
		{
			return SetForegroundWindow(hWnd);
		}
		public int sendWindowsStringMessage(int hWnd, int wParam, string msg)
		{
			int result = 0;
			if (hWnd > 0)
			{
				byte[] sarr = Encoding.UTF8.GetBytes(msg);
				int len = sarr.Length;
				COPYDATASTRUCT cds;
				cds.dwData = (IntPtr)100;
				cds.lpData = msg;
				cds.cbData = len + 1;
				result = SendMessage(hWnd, WM_COPYDATA, wParam, ref cds);
			}
			return result;
		}
		public int sendWindowsMessage(int hWnd, int Msg, int wParam, int lParam)
		{
			int result = 0;
			if (hWnd > 0)
			{
				result = SendMessage(hWnd, Msg, wParam, lParam);
			}
			return result;
		}

		public int getWindowId(string className, string windowName)
		{
			return FindWindow(className, windowName);
		}
		/// <summary>
		/// Gửi data từ form này sang form khác 
		/// </summary>
		/// <param name="NameForm">Tên form </param>
		/// <param name="Data">Giá trị cần gửi</param>
		public void SenData(string NameForm, string Data)
		{
			MessageHelper msg = new MessageHelper();
			int result = 0;
			int hWnd = msg.getWindowId(null, $"{NameForm}");

			result = msg.sendWindowsStringMessage(hWnd, 0, Data);
		}

		// using static MessageHelper;
		// Nhận Data từ SenData
		//protected override void WndProc(ref Message m)
		//{
		//	switch (m.Msg)
		//	{
		//		case WM_USER:

		//			break;
		//		case WM_COPYDATA:
		//			COPYDATASTRUCT mystr = new COPYDATASTRUCT();
		//			Type mytype = mystr.GetType();
		//			mystr = (COPYDATASTRUCT)m.GetLParam(mytype);

		//			byte[] bytes = Encoding.UTF8.GetBytes(mystr.lpData);
		//			string myString = Encoding.UTF8.GetString(bytes);

		//			label1.Text = myString;
		//			break;
		//	}
		//	base.WndProc(ref m);
		//}
	}
}