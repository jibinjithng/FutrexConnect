using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutrexConnect.Domain.Entities
{
    public class HealthReferenceRowCriteria : BaseEntity
    {
        public String ComparisonOperator { get; set; }
        public String ComparisonValue { get; set; }
        public Boolean IsActive { get; set; }

        public long? HealthParameterToCompareId { get; set; }
        [ForeignKey("HealthParameterToCompareId")]
        public HealthParameter HealthParameterToCompare { get; set; }
        public long? HealthReferenceRowId { get; set; }
        [ForeignKey("HealthReferenceRowId")]
        public HealthReferenceRow HealthReferenceRow { get; set; }

    }
}
