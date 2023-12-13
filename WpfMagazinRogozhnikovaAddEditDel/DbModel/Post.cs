using System;
using System.Collections.Generic;

namespace WpfMagazinRogozhnikovaAddEditDel;

public partial class Post
{
    public int Idposts { get; set; }

    public string PostsName { get; set; } = null!;

    public virtual ICollection<Deliviry> Deliviries { get; set; } = new List<Deliviry>();
}
