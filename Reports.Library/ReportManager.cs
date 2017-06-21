using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using Stimulsoft.Report;

namespace Reports.Library
{
    public class ReportManager
    {
        public static void Run()
        {
            try
            {
                ThreadUtils.Run(InternalRun);
            }
            catch (Exception ex)
            {
            }
        }

        private static void InternalRun()
        {
            var stiReport = new StiReport();
            stiReport.Load("Report.mrt");
            stiReport.Design();
        }
    }
}
