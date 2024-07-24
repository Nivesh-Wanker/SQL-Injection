using System;
using System.Collections.Generic;

namespace SQLI.Models;

public partial class Test
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? Created { get; set; }
}
