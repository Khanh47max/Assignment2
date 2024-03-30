using System.Collections.Immutable;

namespace Assignment2.data {

	internal interface IDataProvider {

		ImmutableList<Data> GetDatas();
	}

	public readonly struct Data(string name, Type type, object? value) {
		public readonly string Name = name;
		public readonly Type Type = type;
		public readonly object? Value = value;

		public override string ToString() => $"{GetType().Name}[Name={Name}, Value={Type.Name}:{Value}]";
	}

	public abstract class BaseDataProvider : IDataProvider {

		public ImmutableList<Data> GetDatas() => GetType().GetFields().Select(field => new Data(field.Name, field.FieldType, field.GetValue(this))).ToImmutableList();
	}
}