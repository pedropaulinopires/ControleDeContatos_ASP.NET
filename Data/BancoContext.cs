using ControleDeContatos.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Data
{
    public class BancoContext: DbContext
    {
        //contexto 
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

        //tabela no banco
        public DbSet<ContatoModel> Contato { get; set; }

    }
}
