using ADMS.Domain.Interfaces.Configurations;
using System.Configuration;
using System;

namespace ADMS.Configuration
{
    public class ConfigurationSettings: IConfigurationSettings
    {
        
         
        public ConfigurationSettings()
        {
           
        }

        //public ConfigurationSettings Settings
        //{
        //    get { return _settings; }
        //    private set { _settings = value; }
        //}


        

        
        public string UploadFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["UploadFilePath"].ToString();
            }
            
        }

        
    }
}
