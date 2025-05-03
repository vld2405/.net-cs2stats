using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2Stats.Database.Entities;

public class Team : BaseEntity
{
    [MaxLength(50)]
    public string? Name { get; set; }
    public DateOnly FoundedDate { get; set; }
    [MaxLength(50)]
    public string? Couhtry { get; set; }
}
