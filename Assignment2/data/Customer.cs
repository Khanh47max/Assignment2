namespace Assignment2.data {

	internal class Customer : BaseDataProvider {

		public Customer() {
		}

		public readonly string ID;
		public string Name = "";
		public CustomerType Type;

		public enum CustomerType {
			NotSet,
			Household,
			PublicService,
			Production,
			Business
		}
	}
}