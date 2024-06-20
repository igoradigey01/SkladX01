namespace SkladDB;

public partial class Расход
{
    public int Номенклатура { get; set; }

    public double? Кол { get; set; }

    public string АудитНомерГруппы { get; set; } = null!;
}
