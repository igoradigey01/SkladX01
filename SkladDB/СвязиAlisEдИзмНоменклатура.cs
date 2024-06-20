namespace SkladDB;

public partial class СвязиAlisEдИзмНоменклатура
{
    public string AliasЕдИзм { get; set; } = null!;

    public int IdНоменклатура { get; set; }

    public double КоэфициэнтПриведенияКоснЕдИзм { get; set; }

    public bool ЦенаОтпускаДругая { get; set; }

    public decimal? ЦенаОтпуска { get; set; }

    public string? ОснЕдИзм { get; set; }

    public virtual AliasЕдИзмТовар AliasЕдИзмNavigation { get; set; } = null!;

    public virtual Номенклатура IdНоменклатураNavigation { get; set; } = null!;

    public virtual ОсновнаяЕдИзмерения? ОснЕдИзмNavigation { get; set; }
}
