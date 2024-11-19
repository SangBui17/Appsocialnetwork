using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.enumtype
{
    public enum ReportType
    {
        NUDE,
        VIOLENCE,
        FALSE_INFORMATION,
        SPAM,
        TERRORISM,
        OTHER_PROBLEM
    }

    public static class ReportTypeExtensions
    {
        public static string GetDescription(this ReportType reportType)
        {
            return reportType switch
            {
                ReportType.NUDE => "Khỏa thân",
                ReportType.VIOLENCE => "Bạo lực",
                ReportType.FALSE_INFORMATION => "Thông tin sai sự thật",
                ReportType.SPAM => "Spam",
                ReportType.TERRORISM => "Khủng bố",
                ReportType.OTHER_PROBLEM => "Vấn đề khác",
                _ => throw new ArgumentOutOfRangeException(nameof(reportType), reportType, null)
            };
        }
    }
}

