﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Tenant_App.Utilities.AuthenticationUtility.UserAgent
{
    public class MatchExpression
    {
        public List<Regex> Regexes { get; set; }

        public Action<System.Text.RegularExpressions.Match, object> Action { get; set; }
    }
}
