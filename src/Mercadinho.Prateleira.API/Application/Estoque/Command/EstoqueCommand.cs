using MediatR;
using Mercadinho.Prateleira.Domain;

namespace Mercadinho.Prateleira.API.Application.Estoque.Command
{
    public class EstoqueCommand : IRequest<bool>
    {
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public UnidadeMedidaEnum UnidadeMedida { get; set; }
        public decimal PrecoUnidade { get; set; }
    }
}
