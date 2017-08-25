using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections;

namespace Chapter9_InstallingAndConfiguringApps
{
    //This program demonstrates how to read AppSettings and ConnectionStrings.
    //AppSettings can be accessed through the ConfigurationManager object as shown below.
    public class AppSettingsConnStrings
    {
        public static void Display()
        {
            NameValueCollection allAppSettings = ConfigurationManager.AppSettings;
            Console.WriteLine(allAppSettings["CompanyName"]);
            Console.WriteLine(allAppSettings[0]);

            //We can also enumerate through the values in the AppSettings section as shown below.
            int Counter = 0;
            IEnumerator settingsEnumerator = allAppSettings.Keys.GetEnumerator();
            while (settingsEnumerator.MoveNext())
            {
                Console.WriteLine("Item: {0} Value: {1}", allAppSettings.Keys[Counter],
                allAppSettings[Counter]);
            }

            //Now let us read the Connection Strings
            ConnectionStringSettingsCollection connStringSettings = ConfigurationManager.ConnectionStrings;
            if (connStringSettings != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (ConnectionStringSettings individualSettings in connStringSettings)
                {
                    sb.Append("Full Connection String: " +
                    individualSettings.ConnectionString + "\r\n");
                    sb.Append("Provider Name: " + individualSettings.ProviderName + "\r\n");
                    sb.Append("Section Name: " + individualSettings.Name + "\r\n");
                }
                Console.WriteLine(sb.ToString());
            }

            //We can also read the above info as given below
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["DBConnString"];
            if(settings!=null) Console.WriteLine(settings.ConnectionString);

            //We can read an entire section from the App.Config as below.
            ConnectionStringsSection connectionStringsSection = (ConnectionStringsSection)ConfigurationManager.GetSection("connectionStrings");
            Console.WriteLine(connectionStringsSection.ConnectionStrings.Count.ToString());

            //Note: Web applications should employ the WebConfigurationManager to 
            //manage configuration information as opposed to the ConfigurationManager. It is safe to say that 
            //the WebConfigurationManager class is identical for all intents and purposes to the ConfigurationManager class.

        }
    }
}
