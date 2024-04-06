using System.Runtime.Serialization;

namespace Assignment2.data {

	public class Account(string username, string password) : IData<Account> {

		public static Account GetAccount(string username, string password) {
			return new Account(username, password);
		}

		public string Username { get; set; } = username.ToLower();
		public string Password { get; set; } = password.ToLower();

		public override bool Equals(object? obj) {
			if (obj is Account account) {
				return account.Username == Username && account.Password == Password;
			}
			return false;
		}

		public IMinimalData<Account> GetMinimalData() => new MinimalAccount { Username = Username, Password = Password };

		public Account GetFullyData() => this;
	}

	public class MinimalAccount : IMinimalData<Account> {
		public string Username { get; set; }
		public string Password { get; set; }

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("Username", Username);
			info.AddValue("Password", Password);
		}

		public Account GetFullyData() => new(Username, Password);
	}
}