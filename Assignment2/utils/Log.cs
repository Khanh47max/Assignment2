using System.Diagnostics;
using System.Reflection;

namespace Assignment2.utils {

	internal class Log {

		public static void SysMsg(object message) {
			string smessage = "";
			if (message != null) {
				smessage += message.ToString();
			}
			Print("SYSTEM", smessage, LogLevel.SYSTEM);
		}

		public static void d(object message) {
			StackTrace stackTrace = new();
			StackFrame? frame = stackTrace.GetFrame(1);
			if (frame == null) { return; }
			MethodBase? callerR = frame.GetMethod();
			if (callerR is MethodBase caller) {
				if (caller.ReflectedType is Type type) {
					Print($"{type.Name}.{caller.Name}()", message, LogLevel.DEBUG);
					return;
				}
			}
			Print("Unknown", message, LogLevel.DEBUG);
		}

		public static void i(object message) {
			StackTrace stackTrace = new();
			StackFrame? frame = stackTrace.GetFrame(1);
			if (frame == null) { return; }
			MethodBase? callerR = frame.GetMethod();
			if (callerR is MethodBase caller) {
				if (caller.ReflectedType is Type type) {
					Print($"{type.Name}.{caller.Name}()", message, LogLevel.INFO);
					return;
				}
			}
			Print("Unknown", message, LogLevel.INFO);
		}

		public static void w(object message) {
			StackTrace stackTrace = new();
			StackFrame? frame = stackTrace.GetFrame(1);
			if (frame == null) { return; }
			MethodBase? callerR = frame.GetMethod();
			if (callerR is MethodBase caller) {
				if (caller.ReflectedType is Type type) {
					Print($"{type.Name}.{caller.Name}()", message, LogLevel.WARN);
					return;
				}
			}
			Print("Unknown", message, LogLevel.WARN);
		}

		public static void e(object message) {
			StackTrace stackTrace = new();
			StackFrame? frame = stackTrace.GetFrame(1);
			if (frame == null) { return; }
			MethodBase? callerR = frame.GetMethod();
			if (callerR is MethodBase caller) {
				if (caller.ReflectedType is Type type) {
					Print($"{type.Name}.{caller.Name}()", message, LogLevel.ERROR);
					return;
				}
			}
			Print("Unknown", message, LogLevel.ERROR);
		}

		public static void e(Exception ex) {
			StackTrace stackTrace = new();
			StackFrame? frame = stackTrace.GetFrame(1);
			if (frame == null) { return; }
			MethodBase? callerR = frame.GetMethod();
			if (callerR is MethodBase caller) {
				if (caller.ReflectedType is Type type) {
					Print($"{type.Name}.{caller.Name}()", ex.Message, LogLevel.ERROR);
					return;
				}
			}
			Print("Unknown", ex.Message, LogLevel.ERROR);
			if (ex.InnerException != null) {
				e(ex.InnerException);
			}
		}

		private static void Print(string tag, object message, LogLevel level) {
			switch (level) {
				case LogLevel.DEBUG:
					Console.ForegroundColor = ConsoleColor.Blue;
					break;

				case LogLevel.INFO:
					Console.ForegroundColor = ConsoleColor.Green;
					break;

				case LogLevel.WARN:
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;

				case LogLevel.ERROR:
					Console.ForegroundColor = ConsoleColor.Red;
					break;

				case LogLevel.SYSTEM:
					Console.ForegroundColor = ConsoleColor.Gray;
					break;
			}

			Console.WriteLine(formatString(tag, message, level));
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine(new string('-', Console.BufferWidth));
			Console.ResetColor();
		}

		private static string formatString(string tag, object message, LogLevel level) {
			DateTime time = DateTime.Now;
			string header = $"| [{time.Day:00}-{time.Month:00}-{time.Year:0000} {time.Hour:00}:{time.Minute:00}:{time.Second:00}.{time.Millisecond:000}] [{level}] {tag} |";
			string sep = ($"+{new string('-', header.Length - 2)}+");
			string fmessage = $"{message}";
			return $"{sep}\n{header}\n{sep}\n{fmessage}";
		}

		private enum LogLevel {
			DEBUG,
			INFO,
			WARN,
			ERROR,
			SYSTEM
		}
	}
}