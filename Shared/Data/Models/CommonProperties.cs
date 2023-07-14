using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp.Shared.Models
{
    public class CommonProperties
    {
        public DateTime? AddedDate { get; set; }
        public int AddedBy { get; set; } = 0;
        public DateTime? UpdatedDate { get; set; }
        public int UpdatedBy { get; set; } = 0;
    }
}
