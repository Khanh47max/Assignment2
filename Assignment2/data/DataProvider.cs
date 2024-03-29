using Assignment2.utils;

namespace Assignment2.data {

	internal interface DataProvider {

		public string[] GetFields();

		public object? GetFieldValue(string fieldName) {
			if (GetFields().Contains(fieldName)) {
			}
			Log.w($"{fieldName} not found in {GetType().Name}");
			return null;
		}
	}
}