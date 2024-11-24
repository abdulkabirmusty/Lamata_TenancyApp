using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Services.Handler.EmailMessaging
{
	public static class EmailTemplateCode
	{
		public const string TENANT_APPROVED = "TENANT_APPROVED";
		public const string SUBSCRIPTION_EXPIRED = "SUBSCRIPTION_EXPIRED";
		public const string SUBSCRIPTION_EXPIRATION_REMINDER = "SUBSCRIPTION_EXPIRATION_REMINDER";
		public const string PASSWORD_UPDATE = "PASSWORD_UPDATE";
		public const string FORGOT_PASSWORD = "FORGOT_PASSWORD";
		public const string USER_CHANGE_PASSWORD = "USER_CHANGE_PASSWORD";
		public const string REMITA_SUCCESS = "REMITA_SUCCESS";
		public const string DESK_OFFICER_APPROVER = "DESK_OFFICER_APPROVER";
		public const string TENANT_CREATION = "TENANT_CREATION";
		public const string DESK_OFFICER_REJECTION = "DESK_OFFICER_REJECTION";
		public const string TENANT_REJECTED = "TENANT_REJECTED";

	}

	public class EmailTokenViewModel
	{
		public string TokenName { get; set; }
		public string Token { get; set; }
		public string TokenValue { get; set; }
	}

	public class EmailTokenConstants
	{
		public const string USERNAME = "#Username";
		public const string EMAIL = "#Email";
		public const string SUBMISSION_DATE = "#SubmittedDate";
		public const string PASSWORD = "#Password";
		public const string PORTALNAME = "#PortalName";
		public const string FULLNAME = "#Name";
		public const string APPROVALNAME = "#ApprovalName";
		public const string DURATION = "#Duration";
		public const string LogoURL = "#LogoUrl";
		public const string ACCOUNT_VERIFICATION_LINK = "#Link";
		public const string POSITION = "#Position";
		public const string URL = "[[URL]]";
		public const string REQUESTID = "[[REQUESTID]]";
		public const string DEPARTMENT = "[[DEPARTMENT]]";
		public const string DATECREATED = "[[DATECREATED]]";
		public const string REQUESTERNAME = "[[REQUESTERNAME]]";
		public const string DATERESOLVED = "[[DATERESOLVED]]";
		public const string DATEPUTONHOLD = "[[DATEPUTONHOLD]]";
		public const string RESPONSE = "[[RESPONSE]]";
		public const string FEEDBACK = "[[FEEDBACK]]";
		public const string RRR = "#rrr";
		public const string AMOUNT = "#amount";

	}


}
