using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RAHMS.Forms.RAHMS
{
    class RunningBill
    {

        public bool Active { get; set; }
        public int BillNo { get; set; }
        public string TableNumber { get; set; }
        public string DateTime { get; set; }
        public int Status { get; set; }
        public bool IsCustomerSaved { get; set; }

        public Label LabelObj { get; set; }

        public Panel SalesPanel { get; set; }
        public Panel CustomerPanel { get; set; }
        public Panel InfoPanel { get; set; }
        public Panel BillAndTaxDetailsPanel { get; set; }
    }
}
