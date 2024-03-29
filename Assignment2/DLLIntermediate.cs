using Assignment2.utils;
using System.Runtime.InteropServices;

namespace Assignment2 {

	internal partial class DLLIntermediate {
		public static readonly int SW_HIDE = 0;
		public static readonly int SW_NORMAL = 1;
		public static readonly int SW_MAXIMIZE = 3;
		public static readonly int SW_SHOW = 5;
		public static readonly int SW_MINIMIZE = 6;
		public static readonly int SW_RESTORE = 9;

		[Log]
		[LibraryImport("kernel32.dll")]
		public static partial IntPtr GetConsoleWindow();

		[Log]
		[LibraryImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool ShowWindow(IntPtr hwnd, int nCmdShow);

		public static bool ShowWindow(Form form, int nCmdShow) {
			return ShowWindow(form.Handle, nCmdShow);
		}
	}
}