using System;
using System.Collections.Generic;

namespace AppFactura.Models;

public partial class Factura
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public double? Total { get; set; }
}
