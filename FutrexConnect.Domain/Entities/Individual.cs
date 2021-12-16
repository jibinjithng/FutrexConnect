using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutrexConnect.Domain.Entities
{
    public class Individual : BaseEntity
    {
        public String FutrexConnectID { get; set; }
        public String IndividualName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Gender { get; set; }
        public String MobilePhone { get; set; }
        public String Email { get; set; }
        public String ProfileImageURL { get; set; }

        public long? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public long? StateId { get; set; }
        [ForeignKey("StateId")]
        public State State { get; set; }
        public long CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

    }
}
