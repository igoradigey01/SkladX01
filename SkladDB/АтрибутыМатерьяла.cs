using System;
using System.Collections.Generic;

namespace SkladDB;

public partial class АтрибутыМатерьяла
{
    public string Название { get; set; } = null!;

    public virtual ICollection<ХарактеристикаНоменклатуры> ХарактеристикаНоменклатурыs { get; set; } = new List<ХарактеристикаНоменклатуры>();
}
