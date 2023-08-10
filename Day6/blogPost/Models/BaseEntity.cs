using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace blogpost.Models;

public class BaseEntity{
    public int Id { get; set;}
    public DateTime CreatedAt { get; set; }
}