using System;
using System.Collections.Generic;

namespace SkladDB;

public partial class Поставщик
{
    public int Id { get; set; }

    public string Город { get; set; } = null!;

    public virtual ICollection<НакладнаяПриход> НакладнаяПриходs { get; set; } = new List<НакладнаяПриход>();
}
