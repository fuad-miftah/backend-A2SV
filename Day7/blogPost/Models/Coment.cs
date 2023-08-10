using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace blogpost.Models;

public class Comment : BaseEntity
{
    public string Text { get; set;} = "";
    public int PostId { get; set;}
    public virtual Post Post { get; set;}
}