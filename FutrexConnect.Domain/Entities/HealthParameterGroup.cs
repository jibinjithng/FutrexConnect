using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutrexConnect.Domain.Entities
{
    public class HealthParameterGroup : BaseEntity
    {
        public String ParameterGroupCode { get; set; }
        public String ParameterGroupName { get; set; }
        public Boolean IsActive { get; set; }

        public IList<HealthParameter> HealthParameters { get; set; }

    }
}
