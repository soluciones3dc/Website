using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIIDC.Services
{
    public class EmailConfig
    {
        public String FromName { get; set; }
        public String FromAddress { get; set; }

        public String LocalDomain { get; set; }

        public String MailServerAddress { get; set; }
        public String MailServerPort { get; set; }

    }

}
