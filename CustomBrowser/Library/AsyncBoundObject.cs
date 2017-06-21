using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reports.Library;

namespace CustomBrowser.Library
{
    public class AsyncBoundObject
    {
        public string RunReport()
        {
            return ReportManager.Run();
        }
    }
}
