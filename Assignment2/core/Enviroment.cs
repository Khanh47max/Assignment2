using Assignment2.data;
using System.Collections.Immutable;

namespace Assignment2.core {

	internal class Enviroment {

		private Enviroment() {
		}

		public static readonly ImmutableList<Account> ActivatingAccounts = [Account.GetAccount("Admin", "admin"), Account.GetAccount("HuyMaster", "")];
	}

	internal static class AccountValidable {

		public static bool IsValid(this Account account) {
			return Enviroment.ActivatingAccounts.Contains(account);
		}
	}
}