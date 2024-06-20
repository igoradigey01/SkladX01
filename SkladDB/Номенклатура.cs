namespace SkladDB;

public partial class Номенклатура
{
    public int Id { get; set; }

    public string Название { get; set; } = null!;

    public string ОсновнаяЕдИзмерения { get; set; } = null!;

    public string Матерьял { get; set; } = null!;

    public decimal ЦенаОтпускаOснЕдИзм { get; set; }

    public virtual Матерьял МатерьялNavigation { get; set; } = null!;

    public virtual ОсновнаяЕдИзмерения ОсновнаяЕдИзмеренияNavigation { get; set; } = null!;

    public virtual ICollection<СвязиAlisEдИзмНоменклатура> СвязиAlisEдИзмНоменклатураs { get; set; } = new List<СвязиAlisEдИзмНоменклатура>();

    public virtual ICollection<СкладПриход> СкладПриходs { get; set; } = new List<СкладПриход>();

    public virtual ICollection<СкладРасход> СкладРасходs { get; set; } = new List<СкладРасход>();

    public virtual ХарактеристикаНоменклатуры? ХарактеристикаНоменклатуры { get; set; }
}
