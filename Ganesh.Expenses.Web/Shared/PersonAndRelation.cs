using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganesh.Expenses.Web.Shared
{
    public class PersonAndRelation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; } 
        public string Contact { get; set; }
        public FamilyGroup FamilyGroup{ get; set; } 
        [ForeignKey("FamilyGroup")]
        public int FamilyGroupId{ get; set; }
        [ForeignKey("RelationType")]
        public int RelationTypeId { get; set; }
        public RelationType RelationType { get; set; }
        public override string ToString()
        {
            string toString = Name;
            if (RelationType != null)
            {
                toString += $",{RelationType.Name}";
            }
            if (FamilyGroup != null)
            {
                toString += $",{FamilyGroup.Name}";
            }
            return toString; 
        }
    }
}
