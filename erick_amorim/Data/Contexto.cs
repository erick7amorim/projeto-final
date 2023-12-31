using Microsoft.EntityFrameworkCore;
using erick_amorim.Models;

namespace erick_amorim.Data
{
  public class Contexto : DbContext
  {
    public Contexto(DbContextOptions<Contexto> options)
        : base(options)
    { }

    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Item> Item { get; set; }
    public DbSet<Marca> Marca { get; set; }
    public DbSet<NotaDeVenda> NotaDeVenda { get; set; }
    public DbSet<Pagamento> Pagamento { get; set; }
    public DbSet<Produto> Produto { get; set; }
    public DbSet<TipoPagamento> TipoPagamento { get; set; }
    public DbSet<Transportadora> Transportadora { get; set; }
    public DbSet<Vendedor> Vendedor { get; set; }
    public DbSet<PagamentoComCartao> PagamentoComCartao { get; set; }
    public DbSet<PagamentoComCheque> PagamentoComCheque { get; set; }

  }
}
