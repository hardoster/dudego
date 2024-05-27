using System;
using System.Collections.Generic;

namespace dudego.Models;

public partial class TbBranch
{
    public decimal IdBranch { get; set; }

    public string NameBranch { get; set; } = null!;

    public string? Address { get; set; }

    public string? PhoneNumberBranch { get; set; }

    public virtual ICollection<TbInvoice> TbInvoices { get; set; } = new List<TbInvoice>();
}
