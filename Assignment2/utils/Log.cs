using System.Diagnostics;
using System.Reflection;

namespace Assignment2.utils {

	internal class Log {

		public static void SysMsg(object message) {
			string smessage = "";
			if (message != null) {
				smessage += message.ToString();
			}
			Print(null, smessage, LogLevel.SYSTEM);
		}

		public static void d(object message) {
			StackTrace stackTrace = new();
			StackFrame? frame = stackTrace.GetFrame(1);
			if (frame == null) { return; }
			MethodBase? callerR = frame.GetMethod();
			Print(callerR, message, LogLevel.DEBUG);
		}

		public static void i(object message) {
			StackTrace stackTrace = new();
			StackFrame? frame = stackTrace.GetFrame(1);
			if (frame == null) { return; }
			MethodBase? callerR = frame.GetMethod();
			Print(callerR, message, LogLevel.INFO);
		}

		public static void w(object message) {
			StackTrace stackTrace = new();
			StackFrame? frame = stackTrace.GetFrame(1);
			if (frame == null) { return; }
			MethodBase? callerR = frame.GetMethod();
			Print(callerR, message, LogLevel.WARN);
		}

		public static void e(object message) {
			StackTrace stackTrace = new();
			StackFrame? frame = stackTrace.GetFrame(1);
			if (frame == null) { return; }
			MethodBase? callerR = frame.GetMethod();
			Print(callerR, message, LogLevel.ERROR);
		}

		public static void e(Exception ex) {
			StackTrace stackTrace = new();
			StackFrame? frame = stackTrace.GetFrame(1);
			if (frame == null) { return; }
			MethodBase? callerR = frame.GetMethod();
			Print(callerR, ex.Message, LogLevel.ERROR);
			if (ex.InnerException != null) {
				e(ex.InnerException);
			}
		}

		private static void Print(MethodBase? callerR, object message, LogLevel level) {
			string tag = "Unknown";
			if (level == LogLevel.SYSTEM) {
				tag = "SYSTEM";
			} else if (callerR is MethodBase caller && caller.ReflectedType is Type type) {
				tag = $"{(IsAnonymous(caller) ? $"{type.Name}.<lambda>()" : $"{type.Name}.{caller.Name}({string.Join(", ", caller.GetParameters().Select(param => param.ParameterType.Name))})")}";
			}
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

			Console.WriteLine(FormatString(tag, message, level));
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine(new string('-', Console.BufferWidth));
			Console.ResetColor();
		}

		private static string FormatString(string tag, object message, LogLevel level) {
			DateTime time = DateTime.Now;
			string header = $"| [{time.Day:00}-{time.Month:00}-{time.Year:0000} {time.Hour:00}:{time.Minute:00}:{time.Second:00}.{time.Millisecond:000}] [{level}] {tag} |";
			string sep = ($"+{new string('-', header.Length - 2)}+");
			string fmessage = $"{message}";
			return $"{sep}\n{header}\n{sep}\n{fmessage}";
		}

		public static bool IsAnonymous(MethodBase method) {
			char[] invalidChars = ['<', '>'];
			return method.Name.Any(invalidChars.Contains);
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