using System;
using System.Collections.Generic;

namespace dudego.Models;

public partial class TbInvoice
{
    public decimal IdInvoice { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public decimal? IdCustomer { get; set; }

    public decimal? IdBranch { get; set; }

    public decimal? IdSalesperson { get; set; }

    public virtual TbBranch? IdBranchNavigation { get; set; }

    public virtual TbCustomer? IdCustomerNavigation { get; set; }

    public virtual TbSalesperson? IdSalespersonNavigation { get; set; }

    public virtual ICollection<TbInvoiceDetail> TbInvoiceDetails { get; set; } = new List<TbInvoiceDetail>();
}
