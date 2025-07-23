namespace LojaDiversidades.Domain.Entities
{
    public class Venda
    {
        public int Id { get; set; }

        public string Cliente { get; set; } = string.Empty;

        public DateTime Data { get; set; } = DateTime.Now;

        public List<ItemVenda> Itens { get; set; } = new();

        public decimal Total { get; set; }
    }
}
