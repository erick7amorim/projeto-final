namespace erick_amorim.Models
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }

        public virtual ICollection<Produto>? Produtos { get; set; }
    }
}
