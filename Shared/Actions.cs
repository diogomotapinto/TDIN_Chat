﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    [Serializable()]
    public class Actions
    {
        public const string REGISTER = "REGISTER";
        public const string LOGIN = "LOGIN";
        public const string LOGOUT = "LOGOUT";
        public const string DIRECT_MESSAGE = "DIRECT_MESSAGE";
        public const string ALL_GOOD = "200";
        public const string START_CHAT = "START_CHAT";
        public const string ACCEPTED = "ACCEPTED";
        public Actions()
        {

        }

    }
}
