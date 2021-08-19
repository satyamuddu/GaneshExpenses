using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganesh.Expenses.Web.Shared
{
    public class Income
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }
        
        [ForeignKey("IncomeType")]
        public int? IncomeTypeId { get; set; }
        public IncomeType IncomeType { get; set; }  
        public Bank Bank{ get; set; }   
        [ForeignKey("Bank")]
        public int? BankId {  get; set; }
        
    }
}
