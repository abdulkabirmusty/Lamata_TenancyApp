using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Utilities.PasswordUtility
{
	public class CodeGenerator
	{
		private string GenerateRandomPassword(int length = 12)
		{
			const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+-=[]{}|;:,.<>?";

			var random = new Random();
			var passwordChars = new char[length];

			for (int i = 0; i < length; i++)
			{
				passwordChars[i] = validChars[random.Next(validChars.Length)];
			}

			return new string(passwordChars);
		}
	}
}
