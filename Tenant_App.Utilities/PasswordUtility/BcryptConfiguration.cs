using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Utilities.PasswordUtility
{
	public class BcryptConfiguration
	{
		public static class PasswordHashService
		{
			public static string HashPassword(string password)
			{
				//var salt = BCrypt.Net.BCrypt.GenerateSalt();
				var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

				return hashedPassword;
			}

			public static bool VerifyPassword(string password, string hashedPassword)
			{
				var isPasswordValid = BCrypt.Net.BCrypt.Verify(password, hashedPassword);

				return isPasswordValid;
			}
		}
	}
}
