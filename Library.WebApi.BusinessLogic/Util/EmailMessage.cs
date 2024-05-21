using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Util
{
    public class EmailMessageSetting
    {
        public string Asunto { get; set; } = "";
        public string Remitente { get; set; } = "";
    }
}
