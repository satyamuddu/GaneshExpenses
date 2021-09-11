using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganesh.Expenses.Web.Shared
{
    public class CreditDebit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }

        [ForeignKey("IncomeType")]
        public int? IncomeTypeId { get; set; }
        public IncomeType IncomeType { get; set; }
        public Bank Bank { get; set; }
        [ForeignKey("Bank")]
        [Required]
        public int? BankId { get; set; }
        [ForeignKey("PersonAndRelation")]
        public int? PersonAndRelationId { get; set; } 
        public PersonAndRelation PersonAndRelation { get; set; }
    }
    public class Credit : CreditDebit
    {

    }
}
