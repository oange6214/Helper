using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumSample
{
    public enum AuditEnum
    {
        [Description("未送審")]
        Holding = 0,
        [Description("審核中")]
        Auditing = 1,
        [Description("審核通過")]
        Pass = 2,
        [Description("駁回")]
        Reject = 3
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //AuditEnum ae = AuditEnum.Pass;
            AuditEnum ae = (AuditEnum)1;

            Console.WriteLine(EnumService.GetDescription(ae)); ;

            Console.ReadKey();
        }
    }
}
