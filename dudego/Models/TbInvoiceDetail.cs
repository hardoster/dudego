using System;
using System.Collections.Generic;

namespace dudego.Models;

public partial class TbInvoiceDetail
{
    public decimal IdInvoiceDetails { get; set; }

    public decimal? IdInvoice { get; set; }

    public decimal? IdCar { get; set; }

    public decimal DayDuration { get; set; }

    public decimal PriceDay { get; set; }

    public decimal RentalDeposit { get; set; }

    public virtual TbCar? IdCarNavigation { get; set; }

    public virtual TbInvoice? IdInvoiceNavigation { get; set; }
}
