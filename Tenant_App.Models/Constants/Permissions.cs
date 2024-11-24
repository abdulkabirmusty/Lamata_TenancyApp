using System.Collections.Generic;

namespace Tenant_App.Models.Constants
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
			return new List<string>()
			{
				$"can create {module}",
				$"can view {module}",
				$"can edit {module}",
				$"can delete {module}",
				$"can search {module}"
			};
		}

		public static class Tenant
		{
			public const string View = "can create tenant";
			public const string Create = "can view tenant";
			public const string Edit = "can edit tenant";
			public const string Delete = "can delete tenant";
			public const string Search = "can search tenant";
			public const string Approve = "can approve tenant";
		}

		public static class User
		{
			public const string View = "can view user";
			public const string AssignRole = "can assign role to user";
		}

		public static class Role
		{
			public const string View = "can view role";
			public const string Create = "can create role";
			public const string Edit = "can edit role";
			public const string Delete = "can delete role";
		}

        public static class Contract_Type
        {
            public const string View = "can view contract_type";
            public const string Create = "can create contract_type";
            public const string Edit = "can edit contract_type";
            public const string Delete = "can delete contract_type";
        }

        public static class Property
        {
            public const string View = "can view property";
            public const string Create = "can create property";
            public const string Edit = "can edit property";
            public const string Delete = "can delete property";
        }

        public static class Dashboard
		{
			public const string View = "can view dashboard";
		}

        public static class Payment
        {
            public const string View = "can view payment";
        }

    }
}