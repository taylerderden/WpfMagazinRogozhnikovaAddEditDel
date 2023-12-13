using System;
using System.Collections.Generic;

namespace WpfMagazinRogozhnikovaAddEditDel;

public partial class Manager
{
    public int Idmanagers { get; set; }

    public string ManagersFio { get; set; } = null!;

    public string Managersprocent { get; set; } = null!;

    public int ManagersOklad { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
