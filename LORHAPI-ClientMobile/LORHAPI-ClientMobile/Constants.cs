using Xamarin.Essentials;

using System;
using System.Collections.Generic;
using System.Text;

namespace LORHAPI_ClientMobile
{
    public static class Constants
    {
        // URL of REST service
        //public static string RestUrl = "https://YOURPROJECT.azurewebsites.net:8081/api/todoitems/{0}";

        // URL of REST service (Android does not use localhost)
        // Use http cleartext for local deployment. Change to https for production
        public static string RestUrlUser = DeviceInfo.Platform == DevicePlatform.Android ? "http://localhost:5001/Users" : "http://localhost:5001/Users/{0}";
    }
}
