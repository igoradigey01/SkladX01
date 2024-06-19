using System;
using System.Collections.Generic;

namespace SkladDB;

public partial class Клиент
{
    public int Id { get; set; }

    public string Псевдоним { get; set; } = null!;

    public string Фио { get; set; } = null!;

    public string Телефон { get; set; } = null!;

    public string Город { get; set; } = null!;

    public decimal ПределКредита { get; set; }

    public virtual ICollection<КлиентДеньги> КлиентДеньгиs { get; set; } = new List<КлиентДеньги>();

    public virtual ICollection<КлиентМеткаРасчет> КлиентМеткаРасчетs { get; set; } = new List<КлиентМеткаРасчет>();

    public virtual ICollection<НакладнаяРасход> НакладнаяРасходs { get; set; } = new List<НакладнаяРасход>();
}
