using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutrexConnect.Domain.Entities
{
    public class SystemLanguage : BaseEntity
    {
        public String LanguageCode { get; set; }
        public String LanguageName { get; set; }
        public Boolean IsActive { get; set; }
    }
}
