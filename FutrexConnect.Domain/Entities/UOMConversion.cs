using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutrexConnect.Domain.Entities
{
    public class UOMConversion : BaseEntity
    {
        public long SourceUOMId { get; set; }
        [ForeignKey("SourceUOMId")]
        public UnitOfMeasure SourceUnitOfMeasure { get; set; }

        public long? TargetUOMId { get; set; }
        [ForeignKey("TargetUOMId")]
        public UnitOfMeasure TargetUnitOfMeasure { get; set; }

        public double Conversion { get; set; }
        public Boolean IsActive { get; set; }
    }
}
