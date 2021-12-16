using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutrexConnect.Domain.Entities
{
    public class UnitOfMeasure : BaseEntity
    {
        public String UOMCode { get; set; }
        public String UOMName { get; set; }
        public String UOMGroup { get; set; }
        public Boolean IsActive { get; set; }

        [InverseProperty(nameof(UOMConversion.SourceUnitOfMeasure))]
        public IList<UOMConversion> UOMSrcConversions { get; set; }

        [InverseProperty(nameof(UOMConversion.TargetUnitOfMeasure))]
        public IList<UOMConversion> UOMTargetConversions { get; set; }
    }
}
