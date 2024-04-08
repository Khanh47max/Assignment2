using System.ComponentModel;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace Assignment2.data {

	public struct Customer : IData<Customer> {

		public Customer(string Name, CustomerType? type = CustomerType.NotSet, double LastMonthUsage = 0, double ThisMonthUsage = 0) {
			_name = Name;
			_type = type ?? CustomerType.NotSet;
			_lastMonthUsage = LastMonthUsage;
			_thisMonthUsage = ThisMonthUsage;
			_addTime = DateTime.Now;
		}

		public Customer(Customer customer, DateTime dateTime) {
			_name = customer.Name;
			_type = customer.Type;
			_lastMonthUsage = customer.LastMonthUsage;
			_thisMonthUsage = customer.ThisMonthUsage;
			_addTime = dateTime;
		}

		private string _name;

		[DisplayName("Name")]
		public string Name {
			readonly get { return _name; }
			set {
				_name = value;
			}
		}

		private CustomerType _type;

		[DisplayName("Type")]
		public CustomerType Type {
			readonly get { return _type; }
			set {
				_type = value;
			}
		}

		private double _lastMonthUsage;

		[DisplayName("Last month usage (m³)")]
		public double LastMonthUsage {
			readonly get { return _lastMonthUsage; }
			set {
				_lastMonthUsage = value;
			}
		}

		private double _thisMonthUsage;

		[DisplayName("This month usage (m³)")]
		public double ThisMonthUsage {
			readonly get { return _thisMonthUsage; }
			set {
				_thisMonthUsage = value;
			}
		}

		[DisplayName("Total usage (m³)")]
		public readonly double TotalUsage { get { return ThisMonthUsage - LastMonthUsage; } }

		public readonly double PriceWithoutVAT => _type.GetNoVATPrice(TotalUsage);

		public readonly double EPF { get { return _type.GetEPF(PriceWithoutVAT); } }

		public readonly double VAT { get { return _type.GetVAT(PriceWithoutVAT); } }

		[DisplayName("Total price (VND)")]
		public readonly double TotalPrice { get { return _type.GetPriceWithVAT(TotalUsage); } }

		private readonly DateTime _addTime = DateTime.Now;

		[DisplayName("Add time")]
		public readonly DateTime AddTime { get { return _addTime; } }

		public readonly string ID => GenerageID();

		private readonly string GenerageID() {
			byte[] md5 = MD5.HashData(Encoding.UTF8.GetBytes($"{Name}{Type}{LastMonthUsage}{ThisMonthUsage}{AddTime}".ToLower()));
			StringBuilder builder = new();
			foreach (byte b in md5) {
				builder.Append(b.ToString("x2"));
			}
			return builder.ToString();
		}

		public override readonly string ToString() {
			return $"Customer[{ID}]";
		}

		public readonly void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("Name", _name);
			info.AddValue("Type", _type);
			info.AddValue("LastMonthUsage", _lastMonthUsage);
			info.AddValue("ThisMonthUsage", _thisMonthUsage);
			info.AddValue("AddTime", _addTime);
		}

		public IMinimalData<Customer> GetMinimalData() => new MinimalCustomer() {
			name = _name,
			type = _type,
			lastMonthUsage = _lastMonthUsage,
			thisMonthUsage = _thisMonthUsage,
			addTime = _addTime
		};
	}

	public class MinimalCustomer : IMinimalData<Customer> {
		public string name { get; set; }
		public CustomerType type { get; set; }
		public double lastMonthUsage { get; set; }
		public double thisMonthUsage { get; set; }
		public DateTime addTime { get; set; }

		public Customer GetFullyData() => new(new(name, type, lastMonthUsage, thisMonthUsage), addTime);

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("Name", name);
			info.AddValue("Type", type);
			info.AddValue("LastMonthUsage", lastMonthUsage);
			info.AddValue("ThisMonthUsage", thisMonthUsage);
			info.AddValue("AddTime", addTime);
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

		public static double GetEPF(this CustomerType _, double NoVATPrice) {
			return NoVATPrice == -1 ? 0 : NoVATPrice * 0.1;
		}

		public static double GetVAT(this CustomerType type, double NoVATPrice) {
			return NoVATPrice == -1 ? 0 : (type.GetEPF(NoVATPrice) + NoVATPrice) * 0.1;
		}

		public static double GetPriceWithVAT(this CustomerType type, double waterUsage) {
			double noVATPrice = GetNoVATPrice(type, waterUsage);
			if (noVATPrice == -1) {
				return -1;
			}
			double vat = type.GetVAT(noVATPrice);
			return noVATPrice + vat;
		}
	}
}