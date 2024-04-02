using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace Assignment2.data {

	internal struct Customer {

		public Customer(string Name, CustomerType type = CustomerType.NotSet, double LastMonthUsage = 0, double ThisMonthUsage = 0) {
			_name = Name;
			_id = GenerageID();
			_type = type;
			_lastMonthUsage = LastMonthUsage;
			_thisMonthUsage = ThisMonthUsage;
		}

		private readonly string _name;

		[DisplayName("Name")]
		public readonly string Name { get { return _name; } }

		private readonly CustomerType _type;

		[DisplayName("Type")]
		public readonly CustomerType Type { get { return _type; } }

		private readonly double _lastMonthUsage;

		[DisplayName("Last month usage (m³)")]
		public readonly double LastMonthUsage { get { return _lastMonthUsage; } }

		private readonly double _thisMonthUsage;

		[DisplayName("This month usage (m³)")]
		public readonly double ThisMonthUsage { get { return _thisMonthUsage; } }

		[DisplayName("Total usage (m³)")]
		public readonly double TotalUsage { get { return ThisMonthUsage - LastMonthUsage; } }

		[DisplayName("Total price (VND)")]
		public readonly double TotalPrice { get { return _type.GetNoVATPrice(TotalUsage); } }

		private readonly string _id;
		public readonly string ID { get { return _id; } }

		private string GenerageID() {
			byte[] md5 = MD5.HashData(Encoding.UTF8.GetBytes(Name.ToLower()));
			StringBuilder builder = new();
			foreach (byte b in md5) {
				builder.Append(b.ToString("x2"));
			}
			return builder.ToString();
		}

		public override readonly string ToString() {
			return $"Customer[{ID}]";
		}
	}

	public enum CustomerType {
		NotSet,
		Household,
		PublicService,
		Production,
		Business
	}

	public static class CustomerExtensions {

		public static string GetDescription(this CustomerType type) {
			return type switch {
				CustomerType.NotSet => "Not set",
				CustomerType.Household => "Household",
				CustomerType.PublicService => "Public service",
				CustomerType.Production => "Production units",
				CustomerType.Business => "Business",
				_ => "",
			};
		}

		public static double GetNoVATPrice(this CustomerType type, double waterUsage) {
			double unitPrice;
			switch (type) {
				case CustomerType.NotSet:
					return -1;

				case CustomerType.Household:
					double[] priceStep = [5973, 7052, 8699, 15929];
					int index = Math.Min(3, (int) Math.Floor(waterUsage / 10));
					unitPrice = priceStep[index];
					break;

				case CustomerType.PublicService:
					unitPrice = 9955;
					break;

				case CustomerType.Production:
					unitPrice = 11615;
					break;

				case CustomerType.Business:
					unitPrice = 22068;
					break;

				default:
					return -1;
			}

			double price = waterUsage * unitPrice;

			return price;
		}
	}
}