using System;
using System.Collections.Generic;

namespace dudego.Models;

public partial class TbCar
{
    public decimal IdCar { get; set; }

    public string NumberPlate { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string? Color { get; set; }

    public decimal Year { get; set; }

    public virtual ICollection<TbInvoiceDetail> TbInvoiceDetails { get; set; } = new List<TbInvoiceDetail>();
}
