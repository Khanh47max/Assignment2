using Assignment2.gui;
using Assignment2.utils;

namespace Assignment2 {

	internal class Program : BaseForm {

		public static void Main(string[] args) {
			Program program = new();
			program.A();
			program.Show();
		}

		public void A() {
			OnThemeChange += () => {
				Log.i("S");
			};
		}
	}
}