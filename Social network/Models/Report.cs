using Social_network.enumtype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    internal class Report : BaseEntity
    {
        public User userSource {  get; set; }

        public ReportType reportType { get; set; }

        public string content;

        public ReportStatusType status { get; set; }

        public Comment comment { get; set; }

        public Post post { get; set; }

        public Share share { get; set; }
    }
}
