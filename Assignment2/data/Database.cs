using Assignment2.utils;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Text.Json;

namespace Assignment2.data {

	internal class Database<T, S> where T : IData<T> where S : IMinimalData<T> {
		private readonly JsonSerializerOptions options = new() { WriteIndented = true, IgnoreNullValues = true };
		public readonly ObservableCollection<T> _items = [];

		public event DataChanged OnDataChanged = delegate { };

		private readonly string filename;

		public Database() {
			filename = $"{typeof(T).Name.ToLower()}.db";
			ConfigureStorage();
			_items.CollectionChanged += (o, e) => {
				Log.d($"Database<{typeof(T)}> changed: {e.Action}");
				OnDataChanged.Invoke(e.Action);
				Save();
			};
		}

		private void ConfigureStorage() {
			if (!File.Exists(filename)) {
				Log.d($"Creating new {typeof(T).Name} database file");
				Save();
			}
		}

		public void Add(T item) {
			Load();
			if (!_items.Contains(item)) {
				_items.Add(item);
				Save();
			}
		}

		public void Remove(T item) {
			Load();
			if (_items.Remove(item)) {
				Save();
			}
		}

		public void Save() {
			Log.d($"Saving {typeof(T).Name} data to file");
			FileStream writer = File.OpenWrite(filename);
			try {
				ObservableCollection<S> s = new(_items.Select(x => (S) x.GetMinimalData()));
				JsonSerializer.Serialize(writer, s, options);
				writer.Close();
			} catch (Exception e) {
				writer.Close();
				Log.e($"Error saving data to file. {e.Message}");
				File.Delete(filename);
			}
		}

		public void Load() {
			Log.d($"Loading {typeof(T).Name} data from file");
			FileStream reader = File.OpenRead(filename);
			try {
				ObservableCollection<S>? temp_items = JsonSerializer.Deserialize<ObservableCollection<S>?>(reader);
				reader.Close();
				MergeData(temp_items);
			} catch (Exception e) {
				reader.Close();
				Log.e($"Error loading data from file{e.Message}");
				File.Delete(filename);
				ConfigureStorage();
			}
		}

		private void MergeData(ObservableCollection<S>? newData) {
			if (newData == null) return;
			_items.Clear();
			foreach (S item in newData) {
				if (!_items.Contains(item.GetFullyData())) {
					_items.Add(item.GetFullyData());
				}
			}
		}

		public ObservableCollection<T> GetValues() {
			Load();
			return _items;
		}

		public delegate void DataChanged(NotifyCollectionChangedAction action);
	}
}