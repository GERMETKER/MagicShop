using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShop
{
    public interface IExportable
    {
        public string ExportToJson();
        public string ExportToXml();
    }

}
