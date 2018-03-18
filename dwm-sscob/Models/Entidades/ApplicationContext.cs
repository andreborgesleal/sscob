using App_Dominio.Entidades;
using System.Data.Entity;

namespace DWM.Models.Entidades
{
    public class ApplicationContext : App_DominioContext
    {
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<EmailTipo> EmailTipos { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<EmailLog> EmailLogs { get; set; }
        public DbSet<Cobranca> Cobranca { get; set; }
        public DbSet<CobrancaEnfermeiro> CobrancaEnfermeiro { get; set; }
        public DbSet<Enfermeiro> Enfermeiro { get; set; }
        public DbSet<EnfermeiroSituacao> EnfermeiroSituacao { get; set; }
        public DbSet<Estabelecimento> Estabelecimento { get; set; }
        public DbSet<Situacao> Situacao { get; set; }
        public DbSet<TaxaSindical> TaxaSindical { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cobranca>()
                .Property(e => e.CNPJ)
                .IsFixedLength();

            modelBuilder.Entity<Cobranca>()
                .Property(e => e.ValorTotal)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Cobranca>()
                .HasMany(e => e.CobrancaEnfermeiro)
                .WithRequired(e => e.Cobranca)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CobrancaEnfermeiro>()
                .Property(e => e.Valor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Enfermeiro>()
                .Property(e => e.CNPJ)
                .IsFixedLength();

            modelBuilder.Entity<Enfermeiro>()
                .Property(e => e.CPF)
                .IsFixedLength();

            modelBuilder.Entity<Enfermeiro>()
                .Property(e => e.IndSituacao)
                .IsFixedLength();

            modelBuilder.Entity<Enfermeiro>()
                .HasMany(e => e.CobrancaEnfermeiro)
                .WithRequired(e => e.Enfermeiro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Enfermeiro>()
                .HasMany(e => e.EnfermeiroSituacao)
                .WithRequired(e => e.Enfermeiro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EnfermeiroSituacao>()
                .Property(e => e.Competencia)
                .HasPrecision(6, 0);

            modelBuilder.Entity<Estabelecimento>()
                .Property(e => e.CNPJ)
                .IsFixedLength();

            modelBuilder.Entity<Estabelecimento>()
                .Property(e => e.TipoEstabelecimento)
                .IsFixedLength();

            modelBuilder.Entity<Estabelecimento>()
                .HasMany(e => e.Cobranca)
                .WithRequired(e => e.Estabelecimento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estabelecimento>()
                .HasMany(e => e.Enfermeiro)
                .WithRequired(e => e.Estabelecimento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Situacao>()
                .Property(e => e.IndSituacao)
                .IsFixedLength();

            modelBuilder.Entity<Situacao>()
                .HasMany(e => e.EnfermeiroSituacao)
                .WithRequired(e => e.Situacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaxaSindical>()
                .Property(e => e.TipoEstabelecimento)
                .IsFixedLength();

            modelBuilder.Entity<TaxaSindical>()
                .Property(e => e.AnoMes)
                .HasPrecision(6, 0);

            modelBuilder.Entity<TaxaSindical>()
                .Property(e => e.Valor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<TaxaSindical>()
                .HasMany(e => e.Cobranca)
                .WithRequired(e => e.TaxaSindical)
                .WillCascadeOnDelete(false);
        }
    }
}