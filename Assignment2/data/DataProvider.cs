using System.Runtime.Serialization;

namespace Assignment2.data {

	public interface IData<T> where T : IData<T> {

		public IMinimalData<T> GetMinimalData();
	}

	public interface IMinimalData<T> : ISerializable where T : IData<T> {

		public T GetFullyData();
	}
}