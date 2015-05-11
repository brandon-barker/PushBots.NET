using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushBots.NET.Exceptions
{
    public class SettingsConfigNotFoundException : Exception
    {
        public SettingsConfigNotFoundException()
        {
        }

        public SettingsConfigNotFoundException(string message) : base(message)
        {
        }

        public SettingsConfigNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
