using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
﻿using System.Text.Json.Serialization;



namespace blogpost.Models;

public class Comment : BaseEntity
{
    public string Text { get; set;} = "";
    public int PostId { get; set;}
    [JsonIgnore]
    public virtual Post? Post { get; set;}
}