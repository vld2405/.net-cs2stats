using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2Stats.Database.Entities;

public class Player : BaseEntity
{
    [MaxLength(50)]
    public string? Username { get; set; }
    [MaxLength(50)]
    public string? RealName { get; set; }
    [MaxLength(50)]
    public string? Country { get; set; }
    public required Team Team { get; set; }
    public DateOnly JoinDate { get; set; }
}
