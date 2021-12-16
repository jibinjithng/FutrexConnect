using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutrexConnect.Domain.Entities
{
    public class HealthReferenceRow : BaseEntity
    {
        public String HealthParameterResult { get; set; }
        public Boolean IsActive { get; set; }

        public long HealthReferenceTableId { get; set; }
        [ForeignKey("HealthReferenceTableId")]
        public HealthReferenceTable HealthReferenceTable { get; set; }
        public long HealthParameterId { get; set; }
        [ForeignKey("HealthParameterId")]
        public HealthParameter HealthParameter { get; set; }

        public IList<HealthReferenceRowCriteria> HealthReferenceRowCriterias { get; set; }
    }
}
