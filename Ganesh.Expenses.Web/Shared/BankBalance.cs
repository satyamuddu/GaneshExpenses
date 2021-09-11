using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganesh.Expenses.Web.Shared
{
    public class BankBalance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Balance { get; set; }
        public Bank Bank { get; set; }
        [ForeignKey("Bank")]
        [Required]
        public int? BankId { get; set; }

    }
}
