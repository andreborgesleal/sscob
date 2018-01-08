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
    }
}