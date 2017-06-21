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
        public static string Run()
        {
            try
            {
                return ThreadUtils.Run(InternalRun);
            }
            catch (Exception ex)
            {
                return $"Erro: {ex.Message}!\nDetalhes: {ex.ToString()}";
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
