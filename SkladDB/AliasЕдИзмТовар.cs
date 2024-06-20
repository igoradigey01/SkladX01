namespace SkladDB;

public partial class AliasЕдИзмТовар
{
    public string Название { get; set; } = null!;

    public virtual ICollection<СвязиAlisEдИзмНоменклатура> СвязиAlisEдИзмНоменклатураs { get; set; } = new List<СвязиAlisEдИзмНоменклатура>();

    public virtual ICollection<СкладПриход> СкладПриходAliasЕдИзмNavigations { get; set; } = new List<СкладПриход>();

    public virtual ICollection<СкладПриход> СкладПриходТараРасходаNavigations { get; set; } = new List<СкладПриход>();

    public virtual ICollection<СкладРасход> СкладРасходAliasЕдИзмNavigations { get; set; } = new List<СкладРасход>();

    public virtual ICollection<СкладРасход> СкладРасходТараРасходаNavigations { get; set; } = new List<СкладРасход>();
}
