namespace Assignment2.data {

	internal readonly struct Account(string username, string password) {

		public static Account GetAccount(string username, string password) {
			return new Account(username, password);
		}

		public string Username { get; } = username.ToLower();
		public string Password { get; } = password.ToLower();

		public override bool Equals(object? obj) {
			if (obj is Account account) {
				return account.Username == Username && account.Password == Password;
			}
			return false;
		}
	}
}