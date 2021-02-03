using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatTest.Common.DbModels
{
    public class SignalDataModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public string CustomerName { get; set; }
        public string AccessCode { get; set; }
        public string Area { get; set; }
        public string Zone { get; set; }
        public DateTime SignalDate { get; set; }
    }
}
