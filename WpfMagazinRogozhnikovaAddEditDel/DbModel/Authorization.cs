using System;
using System.Collections.Generic;

namespace WpfMagazinRogozhnikovaAddEditDel;

public partial class Authorization
{
    public int Idauthorization { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}
