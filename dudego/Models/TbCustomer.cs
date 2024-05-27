using System;
using System.Collections.Generic;

namespace dudego.Models;

public partial class TbCustomer
{
    public decimal IdCustomer { get; set; }

    public string DuiCustomer { get; set; } = null!;

    public string DrivingLic { get; set; } = null!;

    public string NameCustomer { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<TbInvoice> TbInvoices { get; set; } = new List<TbInvoice>();
}
