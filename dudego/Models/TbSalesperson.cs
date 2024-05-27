using System;
using System.Collections.Generic;

namespace dudego.Models;

public partial class TbSalesperson
{
    public decimal IdSalesperson { get; set; }

    public string NameSalesperson { get; set; } = null!;

    public string CodeSalesperson { get; set; } = null!;

    public virtual ICollection<TbInvoice> TbInvoices { get; set; } = new List<TbInvoice>();
}
