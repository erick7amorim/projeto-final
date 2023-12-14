namespace erick_amorim.Models
{
    public class TipoPagamento
    {
        public int TipoPagamentoId { get; set; }
        public string? NomeDoCobrado { get; set; }
        public string? InformacoesAdicionais { get; set; }

        public int NotaDeVendaId { get; set; }
        public virtual NotaDeVenda? NotaDeVenda { get; set; }
    }
}
