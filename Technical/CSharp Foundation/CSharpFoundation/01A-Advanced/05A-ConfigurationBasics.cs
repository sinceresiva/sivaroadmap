using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Chapter9_InstallingAndConfiguringApps
{
    //This program demonstrates the basics of how to get the Configuration information.
    //At the top of the logical hierarchy within the System.Configuration namespace are the Configuration 
    //and ConfigurationManager classes.These two classes have an intuitive synergy that becomes evident 
    //when you use them.
    public class ConfigurationBasics
    {
        public static void Display()
        {
            //Let us open the application-specific configuration file.
            Configuration cs1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ExeConfigurationFileMap MyMap = new ExeConfigurationFileMap();
            MyMap.ExeConfigFilename = @"Chapter9-InstallingAndConfiguringApps.exe.config";
            Configuration cs2 = ConfigurationManager.OpenMappedExeConfiguration(MyMap,ConfigurationUserLevel.None);

            Console.WriteLine(cs1.ToString() + "," + cs2.ToString());

            //Now let us open the machine configuration file.
            Configuration cs3 = ConfigurationManager.OpenMachineConfiguration();
            Configuration cs4 = ConfigurationManager.OpenMappedMachineConfiguration(MyMap);

            Console.WriteLine(cs3.ToString() + "," + cs4.ToString());

            //Note: To Continue ahead, please refer the attached App.Config file for 
            //information regarding how to specify configuration information such as supported runtime etc.
        }
    }
}
