using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SkladDB;

public partial class ShSkaldContext : DbContext
{
    public ShSkaldContext()
    {
    }

    public ShSkaldContext(DbContextOptions<ShSkaldContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AliasЕдИзмТовар> AliasЕдИзмТоварs { get; set; }

    public virtual DbSet<АтрибутыМатерьяла> АтрибутыМатерьялаs { get; set; }

    public virtual DbSet<Аудид> Аудидs { get; set; }

    public virtual DbSet<АудитМетка> АудитМеткаs { get; set; }

    public virtual DbSet<Клиент> Клиентs { get; set; }

    public virtual DbSet<КлиентДеньги> КлиентДеньгиs { get; set; }

    public virtual DbSet<КлиентМеткаРасчет> КлиентМеткаРасчетs { get; set; }

    public virtual DbSet<Матерьял> Матерьялs { get; set; }

    public virtual DbSet<НакладнаяПриход> НакладнаяПриходs { get; set; }

    public virtual DbSet<НакладнаяРасход> НакладнаяРасходs { get; set; }

    public virtual DbSet<Номенклатура> Номенклатураs { get; set; }

    public virtual DbSet<ОсновнаяЕдИзмерения> ОсновнаяЕдИзмеренияs { get; set; }

    public virtual DbSet<ПеремещениеПоСкладам> ПеремещениеПоСкладамs { get; set; }

    public virtual DbSet<Поставщик> Поставщикs { get; set; }

    public virtual DbSet<Приход> Приходs { get; set; }

    public virtual DbSet<ПриходНаГруппу> ПриходНаГруппуs { get; set; }

    public virtual DbSet<Расход> Расходs { get; set; }

    public virtual DbSet<РасходНаГруппу> РасходНаГруппуs { get; set; }

    public virtual DbSet<РезультатАудита> РезультатАудитаs { get; set; }

    public virtual DbSet<РезультатыАудита> РезультатыАудитаs { get; set; }

    public virtual DbSet<СвязиAlisEдИзмНоменклатура> СвязиAlisEдИзмНоменклатураs { get; set; }

    public virtual DbSet<Скдад> Скдадs { get; set; }

    public virtual DbSet<СкладПриход> СкладПриходs { get; set; }

    public virtual DbSet<СкладРасход> СкладРасходs { get; set; }

    public virtual DbSet<ХарактеристикаНоменклатуры> ХарактеристикаНоменклатурыs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Database=Sh_Skald;server=172.23.0.2;User Id=sa;Password=2a1sp-msX01;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_CI_AS");

        modelBuilder.Entity<AliasЕдИзмТовар>(entity =>
        {
            entity.HasKey(e => e.Название);

            entity.ToTable("AliasЕдИзмТовар");

            entity.Property(e => e.Название)
                .HasMaxLength(15)
                .HasColumnName("название");
        });

        modelBuilder.Entity<АтрибутыМатерьяла>(entity =>
        {
            entity.HasKey(e => e.Название);

            entity.ToTable("АтрибутыМатерьяла");

            entity.Property(e => e.Название)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("название");
        });

        modelBuilder.Entity<Аудид>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("АУДИД");

            entity.Property(e => e.ЕдИзм)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("едИзм");
            entity.Property(e => e.Имя)
                .HasMaxLength(50)
                .HasColumnName("имя");
            entity.Property(e => e.Количест).HasColumnName("количест");
        });

        modelBuilder.Entity<АудитМетка>(entity =>
        {
            entity.HasKey(e => e.НомерГруппы).HasName("PK_СкладАудит_1");

            entity.ToTable("АудитМетка");

            entity.HasIndex(e => e.НомерГруппы, "IX_СкладАудит").IsUnique();

            entity.Property(e => e.НомерГруппы)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("номерГруппы");
            entity.Property(e => e.ДатаНазначенияНомера)
                .HasColumnType("smalldatetime")
                .HasColumnName("датаНазначенияНомера");
        });

        modelBuilder.Entity<Клиент>(entity =>
        {
            entity.ToTable("Клиент");

            entity.HasIndex(e => e.Псевдоним, "IX_Клиент_псевдонимUniqe").IsUnique();

            entity.HasIndex(e => e.Телефон, "IX_Клиент_телефонUniqe").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Город)
                .HasMaxLength(20)
                .HasColumnName("город");
            entity.Property(e => e.ПределКредита)
                .HasDefaultValue(10000m)
                .HasColumnType("smallmoney");
            entity.Property(e => e.Псевдоним)
                .HasMaxLength(25)
                .HasColumnName("псевдоним");
            entity.Property(e => e.Телефон)
                .HasMaxLength(18)
                .HasColumnName("телефон");
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .HasDefaultValue("none")
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<КлиентДеньги>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_КлиентДеньги_1");

            entity.ToTable("КлиентДеньги");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CуммаПринятыхДенег)
                .HasColumnType("money")
                .HasColumnName("cуммаПринятыхДенег");
            entity.Property(e => e.Дата)
                .HasColumnType("smalldatetime")
                .HasColumnName("дата");
            entity.Property(e => e.КлиентId).HasColumnName("клиентId");
            entity.Property(e => e.МеткаId).HasColumnName("меткаId");

            entity.HasOne(d => d.Клиент).WithMany(p => p.КлиентДеньгиs)
                .HasForeignKey(d => d.КлиентId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_КлиентДеньги_Клиент");

            entity.HasOne(d => d.Метка).WithMany(p => p.КлиентДеньгиs)
                .HasForeignKey(d => d.МеткаId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_КлиентДеньги_КлиентМеткаРасчет");
        });

        modelBuilder.Entity<КлиентМеткаРасчет>(entity =>
        {
            entity.ToTable("КлиентМеткаРасчет");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Дата)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("дата");
            entity.Property(e => e.Долг).HasColumnType("smallmoney");
            entity.Property(e => e.КлиентId).HasColumnName("клиентId");
            entity.Property(e => e.Коментарий)
                .HasMaxLength(50)
                .HasColumnName("коментарий");
            entity.Property(e => e.МеткаНомер)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("меткаНомер");

            entity.HasOne(d => d.Клиент).WithMany(p => p.КлиентМеткаРасчетs)
                .HasForeignKey(d => d.КлиентId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_КлиентМеткаРасчет_Клиент");
        });

        modelBuilder.Entity<Матерьял>(entity =>
        {
            entity.HasKey(e => e.Название);

            entity.ToTable("Матерьял");

            entity.Property(e => e.Название)
                .HasMaxLength(25)
                .HasColumnName("название");
        });

        modelBuilder.Entity<НакладнаяПриход>(entity =>
        {
            entity.ToTable("НакладнаяПриход");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Дата)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("дата");
            entity.Property(e => e.НомерНакладной)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("номерНакладной");
            entity.Property(e => e.Поставщик).HasColumnName("поставщик");
            entity.Property(e => e.СуммаПонаклодной)
                .HasColumnType("money")
                .HasColumnName("суммаПонаклодной");

            entity.HasOne(d => d.ПоставщикNavigation).WithMany(p => p.НакладнаяПриходs)
                .HasForeignKey(d => d.Поставщик)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_НакладнаяПриход_Поставщик");
        });

        modelBuilder.Entity<НакладнаяРасход>(entity =>
        {
            entity.ToTable("НакладнаяРасход");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Дата)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("дата");
            entity.Property(e => e.КлиентId).HasColumnName("клиентId");
            entity.Property(e => e.МеткаId).HasColumnName("меткаId");
            entity.Property(e => e.Номер)
                .HasMaxLength(5)
                .HasColumnName("номер");
            entity.Property(e => e.СуммаПонаклодной)
                .HasColumnType("smallmoney")
                .HasColumnName("суммаПонаклодной");

            entity.HasOne(d => d.Клиент).WithMany(p => p.НакладнаяРасходs)
                .HasForeignKey(d => d.КлиентId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_НакладнаяРасход_Клиент");

            entity.HasOne(d => d.Метка).WithMany(p => p.НакладнаяРасходs)
                .HasForeignKey(d => d.МеткаId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_НакладнаяРасход_КлиентМеткаРасчет");
        });

        modelBuilder.Entity<Номенклатура>(entity =>
        {
            entity.ToTable("Номенклатура");

            entity.HasIndex(e => e.Название, "IX_Номенклатура").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Матерьял)
                .HasMaxLength(25)
                .HasColumnName("матерьял");
            entity.Property(e => e.Название)
                .HasMaxLength(50)
                .HasColumnName("название");
            entity.Property(e => e.ОсновнаяЕдИзмерения)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("основнаяЕдИзмерения");
            entity.Property(e => e.ЦенаОтпускаOснЕдИзм)
                .HasColumnType("smallmoney")
                .HasColumnName("ценаОтпускаOснЕдИзм");

            entity.HasOne(d => d.МатерьялNavigation).WithMany(p => p.Номенклатураs)
                .HasForeignKey(d => d.Матерьял)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Номенклатура_Матерьял");

            entity.HasOne(d => d.ОсновнаяЕдИзмеренияNavigation).WithMany(p => p.Номенклатураs)
                .HasForeignKey(d => d.ОсновнаяЕдИзмерения)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Номенклатура_ОсновнаяЕдИзмерения");
        });

        modelBuilder.Entity<ОсновнаяЕдИзмерения>(entity =>
        {
            entity.HasKey(e => e.Название);

            entity.ToTable("ОсновнаяЕдИзмерения", tb => tb.HasComment("вес , шт"));

            entity.Property(e => e.Название)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("название");
        });

        modelBuilder.Entity<ПеремещениеПоСкладам>(entity =>
        {
            entity.ToTable("ПеремещениеПоСкладам");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.АудитНомерГруппы)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("аудитНомерГруппы");
            entity.Property(e => e.Дата)
                .HasColumnType("smalldatetime")
                .HasColumnName("дата");
            entity.Property(e => e.КолОснЕдИзм).HasColumnName("колОснЕдИзм");
            entity.Property(e => e.КтоОсуществлял)
                .HasMaxLength(25)
                .IsFixedLength()
                .HasColumnName("ктоОсуществлял");
            entity.Property(e => e.Номенклатура).HasColumnName("номенклатура");
            entity.Property(e => e.ОснЕдИзм)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("оснЕдИзм");
            entity.Property(e => e.СкладКонечный).HasColumnName("складКонечный");
            entity.Property(e => e.СкладНачальный).HasColumnName("складНачальный");

            entity.HasOne(d => d.АудитНомерГруппыNavigation).WithMany(p => p.ПеремещениеПоСкладамs)
                .HasForeignKey(d => d.АудитНомерГруппы)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ПеремещениеПоСкладам_СкладАудит");

            entity.HasOne(d => d.ОснЕдИзмNavigation).WithMany(p => p.ПеремещениеПоСкладамs)
                .HasForeignKey(d => d.ОснЕдИзм)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ПеремещениеПоСкладам_ОсновнаяЕдИзмерения");

            entity.HasOne(d => d.СкладКонечныйNavigation).WithMany(p => p.ПеремещениеПоСкладамСкладКонечныйNavigations)
                .HasForeignKey(d => d.СкладКонечный)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ПеремещениеПоСкладам_Скдад1");

            entity.HasOne(d => d.СкладНачальныйNavigation).WithMany(p => p.ПеремещениеПоСкладамСкладНачальныйNavigations)
                .HasForeignKey(d => d.СкладНачальный)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ПеремещениеПоСкладам_Скдад");
        });

        modelBuilder.Entity<Поставщик>(entity =>
        {
            entity.ToTable("Поставщик");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Город)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("город");
        });

        modelBuilder.Entity<Приход>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ПРИХОД");

            entity.Property(e => e.АудитНомерГруппы)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("аудитНомерГруппы");
            entity.Property(e => e.Кол).HasColumnName("кол");
            entity.Property(e => e.Номенклатура).HasColumnName("номенклатура");
        });

        modelBuilder.Entity<ПриходНаГруппу>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ПриходНаГруппу");

            entity.Property(e => e.АудитНомерГруппы)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("аудитНомерГруппы");
            entity.Property(e => e.Кол).HasColumnName("кол");
            entity.Property(e => e.Номенклатура).HasColumnName("номенклатура");
        });

        modelBuilder.Entity<Расход>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("РАСХОД");

            entity.Property(e => e.АудитНомерГруппы)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("аудитНомерГруппы");
            entity.Property(e => e.Кол).HasColumnName("кол");
            entity.Property(e => e.Номенклатура).HasColumnName("номенклатура");
        });

        modelBuilder.Entity<РасходНаГруппу>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("РасходНаГруппу");

            entity.Property(e => e.АудитНомерГруппы)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("аудитНомерГруппы");
            entity.Property(e => e.Кол).HasColumnName("кол");
            entity.Property(e => e.Номенклатура).HasColumnName("номенклатура");
        });

        modelBuilder.Entity<РезультатАудита>(entity =>
        {
            entity.ToTable("РезультатАудита");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Кол).HasColumnName("кол");
            entity.Property(e => e.Недостача).HasColumnName("недостача");
            entity.Property(e => e.Номенклатура).HasColumnName("номенклатура");
            entity.Property(e => e.НомерГруппы)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("номерГруппы");
            entity.Property(e => e.ОснЕдИзм)
                .HasMaxLength(5)
                .IsFixedLength();

            entity.HasOne(d => d.НомерГруппыNavigation).WithMany(p => p.РезультатАудитаs)
                .HasForeignKey(d => d.НомерГруппы)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_РезультатАудита_СкладАудит");

            entity.HasOne(d => d.ОснЕдИзмNavigation).WithMany(p => p.РезультатАудитаs)
                .HasForeignKey(d => d.ОснЕдИзм)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_РезультатАудита_ОсновнаяЕдИзмерения");
        });

        modelBuilder.Entity<РезультатыАудита>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("РезультатыАудита");

            entity.Property(e => e.Кол).HasColumnName("кол");
            entity.Property(e => e.Название)
                .HasMaxLength(50)
                .HasColumnName("название");
            entity.Property(e => e.Номенклатура).HasColumnName("номенклатура");
            entity.Property(e => e.НомерГруппы)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("номерГруппы");
            entity.Property(e => e.ОснЕдИзм)
                .HasMaxLength(5)
                .IsFixedLength();
        });

        modelBuilder.Entity<СвязиAlisEдИзмНоменклатура>(entity =>
        {
            entity.HasKey(e => new { e.AliasЕдИзм, e.IdНоменклатура });

            entity.ToTable("СвязиAlisEдИзмНоменклатура");

            entity.Property(e => e.AliasЕдИзм)
                .HasMaxLength(15)
                .HasColumnName("aliasЕдИзм");
            entity.Property(e => e.IdНоменклатура).HasColumnName("idНоменклатура");
            entity.Property(e => e.КоэфициэнтПриведенияКоснЕдИзм).HasColumnName("коэфициэнтПриведенияКоснЕдИзм");
            entity.Property(e => e.ОснЕдИзм)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("оснЕдИзм");
            entity.Property(e => e.ЦенаОтпуска)
                .HasColumnType("smallmoney")
                .HasColumnName("ценаОтпуска");
            entity.Property(e => e.ЦенаОтпускаДругая).HasColumnName("ценаОтпускаДругая");

            entity.HasOne(d => d.AliasЕдИзмNavigation).WithMany(p => p.СвязиAlisEдИзмНоменклатураs)
                .HasForeignKey(d => d.AliasЕдИзм)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_СвязиAlisEдИзмНоменклатура_AliasЕдИзмТовар");

            entity.HasOne(d => d.IdНоменклатураNavigation).WithMany(p => p.СвязиAlisEдИзмНоменклатураs)
                .HasForeignKey(d => d.IdНоменклатура)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_СвязиAlisEдИзмНоменклатура_Номенклатура");

            entity.HasOne(d => d.ОснЕдИзмNavigation).WithMany(p => p.СвязиAlisEдИзмНоменклатураs)
                .HasForeignKey(d => d.ОснЕдИзм)
                .HasConstraintName("FK_СвязиAlisEдИзмНоменклатура_ОсновнаяЕдИзмерения");
        });

        modelBuilder.Entity<Скдад>(entity =>
        {
            entity.ToTable("Скдад");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Alias)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("alias");
            entity.Property(e => e.Название)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("название");
        });

        modelBuilder.Entity<СкладПриход>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_СкладПриходШтучно");

            entity.ToTable("СкладПриход");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AliasЕдИзм)
                .HasMaxLength(15)
                .HasDefaultValueSql("((0))")
                .HasComment("при учете в алтернативных ед измерения принимает истина");
            entity.Property(e => e.АудитНомерГруппы)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("аудитНомерГруппы");
            entity.Property(e => e.КолAliasЕдИзм)
                .HasComment("количесто товара в алтернативных ед изм")
                .HasColumnName("колAliasЕдИзм");
            entity.Property(e => e.КолОснЕдИзм)
                .HasComment("количесво товара в основной ед измерения")
                .HasColumnName("колОснЕдИзм");
            entity.Property(e => e.НакладнаяId)
                .HasComment("id накладной")
                .HasColumnName("накладнаяId");
            entity.Property(e => e.Номенклатура)
                .HasComment("id номенклатуры")
                .HasColumnName("номенклатура");
            entity.Property(e => e.ОснЕдИзм)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.СкладId)
                .HasComment("id склада на который поступил товар")
                .HasColumnName("складId");
            entity.Property(e => e.ТараРасхода)
                .HasMaxLength(15)
                .HasColumnName("тараРасхода");
            entity.Property(e => e.ЦенаAliasЕдИзм)
                .HasComment("цена в альтернативных ед измерения")
                .HasColumnType("smallmoney")
                .HasColumnName("ценаAliasЕдИзм");
            entity.Property(e => e.ЦенаОснЕдИзм)
                .HasComment("цена товара в основных ед измерения")
                .HasColumnType("smallmoney")
                .HasColumnName("ценаОснЕдИзм");

            entity.HasOne(d => d.AliasЕдИзмNavigation).WithMany(p => p.СкладПриходAliasЕдИзмNavigations)
                .HasForeignKey(d => d.AliasЕдИзм)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_СкладПриход_AliasЕдИзмТовар");

            entity.HasOne(d => d.АудитНомерГруппыNavigation).WithMany(p => p.СкладПриходs)
                .HasForeignKey(d => d.АудитНомерГруппы)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_СкладПриход_СкладАудит");

            entity.HasOne(d => d.Накладная).WithMany(p => p.СкладПриходs)
                .HasForeignKey(d => d.НакладнаяId)
                .HasConstraintName("FK_СкладПриходШтучно_НакладнаяПриход");

            entity.HasOne(d => d.НоменклатураNavigation).WithMany(p => p.СкладПриходs)
                .HasForeignKey(d => d.Номенклатура)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_СкладПриходШтучно_Номенклатура");

            entity.HasOne(d => d.ОснЕдИзмNavigation).WithMany(p => p.СкладПриходs)
                .HasForeignKey(d => d.ОснЕдИзм)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_СкладПриход_ОсновнаяЕдИзмерения");

            entity.HasOne(d => d.Склад).WithMany(p => p.СкладПриходs)
                .HasForeignKey(d => d.СкладId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_СкладПриход_Скдад");

            entity.HasOne(d => d.ТараРасходаNavigation).WithMany(p => p.СкладПриходТараРасходаNavigations)
                .HasForeignKey(d => d.ТараРасхода)
                .HasConstraintName("FK_СкладПриход_AliasЕдИзмТовар1");
        });

        modelBuilder.Entity<СкладРасход>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_СкладРасходШтучно");

            entity.ToTable("СкладРасход");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AliasЕдИзм)
                .HasMaxLength(15)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.АудитНомерГруппы)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("аудитНомерГруппы");
            entity.Property(e => e.КолAliasЕдИзм)
                .HasDefaultValue(0.0)
                .HasColumnName("колAliasЕдИзм");
            entity.Property(e => e.КолОснЕдИзм).HasColumnName("колОснЕдИзм");
            entity.Property(e => e.НакладнаяId).HasColumnName("накладнаяId");
            entity.Property(e => e.Номенклатура).HasColumnName("номенклатура");
            entity.Property(e => e.ОснЕдИзм)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.СкладId).HasColumnName("складId");
            entity.Property(e => e.ТараРасхода)
                .HasMaxLength(15)
                .HasColumnName("тараРасхода");
            entity.Property(e => e.ЦенаAliasЕдИзм)
                .HasColumnType("smallmoney")
                .HasColumnName("ценаAliasЕдИзм");
            entity.Property(e => e.ЦенаОснЕдИзм)
                .HasColumnType("smallmoney")
                .HasColumnName("ценаОснЕдИзм");

            entity.HasOne(d => d.AliasЕдИзмNavigation).WithMany(p => p.СкладРасходAliasЕдИзмNavigations)
                .HasForeignKey(d => d.AliasЕдИзм)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_СкладРасход_AliasЕдИзмТовар");

            entity.HasOne(d => d.АудитНомерГруппыNavigation).WithMany(p => p.СкладРасходs)
                .HasForeignKey(d => d.АудитНомерГруппы)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_СкладРасход_СкладАудит");

            entity.HasOne(d => d.Накладная).WithMany(p => p.СкладРасходs)
                .HasForeignKey(d => d.НакладнаяId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_СкладРасход_НакладнаяРасход");

            entity.HasOne(d => d.НоменклатураNavigation).WithMany(p => p.СкладРасходs)
                .HasForeignKey(d => d.Номенклатура)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_СкладРасходШтучно_Номенклатура");

            entity.HasOne(d => d.ОснЕдИзмNavigation).WithMany(p => p.СкладРасходs)
                .HasForeignKey(d => d.ОснЕдИзм)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_СкладРасход_ОсновнаяЕдИзмерения");

            entity.HasOne(d => d.Склад).WithMany(p => p.СкладРасходs)
                .HasForeignKey(d => d.СкладId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_СкладРасход_Скдад");

            entity.HasOne(d => d.ТараРасходаNavigation).WithMany(p => p.СкладРасходТараРасходаNavigations)
                .HasForeignKey(d => d.ТараРасхода)
                .HasConstraintName("FK_СкладРасход_AliasЕдИзмТовар1");
        });

        modelBuilder.Entity<ХарактеристикаНоменклатуры>(entity =>
        {
            entity.ToTable("ХарактеристикаНоменклатуры");

            entity.HasIndex(e => e.НоменклатураId, "IX_ХарактеристикаНоменклатуры").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Атрибут)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("атрибут");
            entity.Property(e => e.Значение)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("значение");
            entity.Property(e => e.НоменклатураId).HasColumnName("номенклатураId");

            entity.HasOne(d => d.ЗначениеNavigation).WithMany(p => p.ХарактеристикаНоменклатурыs)
                .HasForeignKey(d => d.Значение)
                .HasConstraintName("FK_ХарактеристикаНоменклатуры_АтрибутыМатерьяла");

            entity.HasOne(d => d.Номенклатура).WithOne(p => p.ХарактеристикаНоменклатуры)
                .HasForeignKey<ХарактеристикаНоменклатуры>(d => d.НоменклатураId)
                .HasConstraintName("FK_ХарактеристикаНоменклатуры_Номенклатура");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
