using Assignment2.core;
using Assignment2.data;
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
			ProgramEnvironment.CustomersDatabase.Add(new Customer("John", CustomerType.Household, 0, 1));
			ProgramEnvironment.CustomersDatabase.Add(new Customer("Alex"));
		}
	}
}