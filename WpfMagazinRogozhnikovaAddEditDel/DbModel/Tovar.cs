using System;
using System.Collections.Generic;

namespace WpfMagazinRogozhnikovaAddEditDel;

public partial class Tovar
{
    public int Idtovars { get; set; }

    public string TovarsName { get; set; } = null!;

    public byte[]? TovarsColvo { get; set; }

    public virtual ICollection<Deliviry> Deliviries { get; set; } = new List<Deliviry>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
