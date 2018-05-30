using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamerPilotLanding.Models
{
    public class PanelUser
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; }

        [DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }
    }
}
