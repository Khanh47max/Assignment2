namespace Assignment2.data {

	internal class Database<T> {
		private readonly List<T> _items = [];

		public void Add(T item) {
			if (!_items.Contains(item))
				_items.Add(item);
		}

		public void Remove(T item) {
			_items.Remove(item);
		}

		public List<T> GetValues() {
			return _items;
		}
	}
}