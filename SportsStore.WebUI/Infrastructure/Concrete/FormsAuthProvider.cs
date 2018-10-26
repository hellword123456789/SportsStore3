﻿using SportsStore.WebUI.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SportsStore.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider:IAuthProvider
    {
        public bool Authenticate(string name,string password)
        {
            bool result = FormsAuthentication.Authenticate(name, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(name, false);
            }
            return result;
        }
    }
}