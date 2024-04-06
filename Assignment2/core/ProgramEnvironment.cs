using Assignment2.data;
using Assignment2.utils;

namespace Assignment2.core {

	internal class ProgramEnvironment {

		private ProgramEnvironment() {
		}

		// Events
		public static event AccountLogin OnAccountLogin = (username) => Log.i($"{username} logged in");

		public static event AccountLogout OnAccountLogout = () => Log.i("Logged out");

		// Variables
		public static readonly Database<Account, MinimalAccount> ActiveAccounts = new();

		private static Account? _currentAccount;

		public static Account? CurrentAccount {
			get => _currentAccount;
			set {
				if (value is null) OnAccountLogout.Invoke();
				else OnAccountLogin.Invoke(value.Username);
				_currentAccount = value;
			}
		}

		public static readonly Database<Customer, MinimalCustomer> CustomersDatabase = new();

		//Delegates
		public delegate void AccountLogin(string username);

		public delegate void AccountLogout();
	}

	internal static class AccountValidable {

		public static bool IsValid(this Account account) {
			return ProgramEnvironment.ActiveAccounts.GetValues().Contains(account);
		}
	}
}