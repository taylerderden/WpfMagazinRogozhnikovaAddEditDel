using System;
using System.Collections.Generic;

namespace WpfMagazinRogozhnikovaAddEditDel;

public partial class Sale
{
    public int Idsales { get; set; }

    public int TovarsIdtovars { get; set; }

    public double SalesCena { get; set; }

    public string SalesData { get; set; } = null!;

    public int SalesV { get; set; }

    public int ManagersIdmanagers { get; set; }

    public virtual Manager ManagersIdmanagersNavigation { get; set; } = null!;

    public virtual Tovar TovarsIdtovarsNavigation { get; set; } = null!;
}
