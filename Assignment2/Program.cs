using Assignment2.gui;

namespace Assignment2 {

	internal class Program {

		[STAThread]
		public static void Main(string[] args) {
			Configure();
			ShowBaseForm();
		}

		private static void ShowBaseForm() {
			new LoginForm().Show();
		}

		private static void Configure() {
			// Add configuration code here
		}
	}
}