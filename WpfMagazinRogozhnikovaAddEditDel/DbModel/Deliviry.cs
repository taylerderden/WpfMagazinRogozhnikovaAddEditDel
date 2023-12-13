using System;
using System.Collections.Generic;

namespace WpfMagazinRogozhnikovaAddEditDel;

public partial class Deliviry
{
    public int Iddeliviries { get; set; }

    public int TovarsIdtovars { get; set; }

    public int PostsIdposts { get; set; }

    public int DeliviriesCena { get; set; }

    public string DeliviriesData { get; set; } = null!;

    public int DeliviriesV { get; set; }

    public virtual Post PostsIdpostsNavigation { get; set; } = null!;

    public virtual Tovar TovarsIdtovarsNavigation { get; set; } = null!;
}
