using MediatR;

namespace Mercadinho.Prateleira.API.Application.Produto.Query
{
    public class ListaProdutosQuery : IRequest<IEnumerable<Domain.Produto>>
    {

    }
}
