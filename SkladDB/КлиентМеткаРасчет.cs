using System;
using System.Collections.Generic;

namespace SkladDB;

public partial class КлиентМеткаРасчет
{
    public int Id { get; set; }

    public int КлиентId { get; set; }

    public DateTime Дата { get; set; }

    public string МеткаНомер { get; set; } = null!;

    public decimal Долг { get; set; }

    public string Коментарий { get; set; } = null!;

    public virtual Клиент Клиент { get; set; } = null!;

    public virtual ICollection<КлиентДеньги> КлиентДеньгиs { get; set; } = new List<КлиентДеньги>();

    public virtual ICollection<НакладнаяРасход> НакладнаяРасходs { get; set; } = new List<НакладнаяРасход>();
}
