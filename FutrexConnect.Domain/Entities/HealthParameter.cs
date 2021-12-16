using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutrexConnect.Domain.Entities
{
    public class HealthParameter : BaseEntity
    {
        public String ParameterCode { get; set; }
        public String ParameterName { get; set; }
        public Boolean IsActive { get; set; }
        public long HealthParameterGroupId { get; set; }
        [ForeignKey("HealthParameterGroupId")]
        public HealthParameterGroup HealthParameterGroup { get; set; }
        public IList<HealthReferenceRow> HealthReferenceRows { get; set; }
        public IList<HealthReferenceRowCriteria> HealthReferenceRowCriterias { get; set; }
    }
}
