namespace erick_amorim.Models
{
    public class Vendedor
    {
        public int VendedorId { get; set; }
        public string? Nome { get; set; }

        public virtual ICollection<NotaDeVenda>? NotasDeVenda { get; set; }
    }
}
