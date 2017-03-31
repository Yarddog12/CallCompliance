using System;

namespace CallCompliance.Fx
{
	public static class Formatters {
		public static class Helpers {

			public static string FormatPhoneNumber(string phoneNumber) {

				string phone = phoneNumber.Replace(" ", "").Trim();
				if (phone.Length != 10) {
					return "PhoneNumber wrong number of digits";
				}

				return ("(" + phoneNumber.Substring(0, 3) + ") " + phoneNumber.Substring(3, 3) + "-" + phoneNumber.Substring(6));
			}
		}
	}
}
