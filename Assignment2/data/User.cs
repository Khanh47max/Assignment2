namespace Assignment2.data {

	internal struct User : DataProvider {

		public User() {
		}

		public string[] GetFields() {
			return GetType().GetFields().Select(field => field.Name).ToArray();
		}
	}
}