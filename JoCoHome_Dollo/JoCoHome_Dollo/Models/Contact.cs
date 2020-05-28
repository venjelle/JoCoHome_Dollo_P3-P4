using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JoCoHome_Dollo.Models
{
    public class Contact
    { 
     public int Id { get; set; }

    [Required]
    public string Naam { get; set; }

    [Required]
    [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
    public string Email { get; set; }

    [Required]
    [RegularExpression(@"^[0-9]*$")]
    [Display(Name = "Telefoon Nr")]
    public string TelefoonNr { get; set; }

    [Required]
    public string Onderwerp { get; set; }

    [Required]
    public string Bericht { get; set; }

    }
}
