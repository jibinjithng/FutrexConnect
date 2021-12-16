using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutrexConnect.Domain.Entities
{
    public class HealthReferenceTable : BaseEntity
    {
        public String TableName { get; set; }
        public String TableDescription { get; set; }
        public Boolean IsActive { get; set; }

        public IList<HealthReferenceRow> HealthReferenceRows { get; set; }
    }
}
