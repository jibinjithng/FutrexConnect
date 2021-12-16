using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutrexConnect.Domain.Entities
{
    public class CustomerSupportingDocuments : BaseEntity
    {
        public String DocumentType { get; set; }
        public String DocumentTitle { get; set; }
        public String DocumentUniqueReference { get; set; }
        public String DocumentURL { get; set; }

        public long CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

    }
}
