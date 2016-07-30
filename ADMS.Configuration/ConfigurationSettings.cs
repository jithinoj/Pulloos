using ADMS.Domain.Interfaces.Configurations;
using System.Configuration;
using System;

namespace ADMS.Configuration
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        
        public ConfigurationSettings()
        {

        }

        private string _uploadFilePath;

        public string UploadFilePath
        {
            get
            {
                if (_uploadFilePath == null)
                    _uploadFilePath = ConfigurationManager.AppSettings["UploadFilePath"].ToString();

                return _uploadFilePath;
            }

        }
    }
}
