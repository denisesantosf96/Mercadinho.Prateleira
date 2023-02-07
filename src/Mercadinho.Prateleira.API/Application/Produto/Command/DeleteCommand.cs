using MediatR;

namespace Mercadinho.Prateleira.API.Application.Produto.Command
{
    public class DeleteCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
