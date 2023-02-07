using MediatR;
using Mercadinho.Prateleira.API.Application.Produto.Command;
using Mercadinho.Prateleira.Infrastructure.Data.Contract;

namespace Mercadinho.Prateleira.API.Application.Produto.Handler
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, bool>
    {
        private readonly IGenericRepository<Domain.Produto> _genericRepository;
        private readonly IGenericRepository<Domain.Categoria> _categoiaRepository;

        public UpdateCommandHandler(IGenericRepository<Domain.Produto> genericRepository,
            IGenericRepository<Domain.Categoria> categoiaRepository)
        {
            _genericRepository = genericRepository;
            _categoiaRepository = categoiaRepository;
        }

        public async Task<bool> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            //todo: validar a rquest

            var produtos = await _genericRepository.GetAllAsync(
                filter: x => x.Id == request.Id,
                includeProperties: "Categorias"
                ).ConfigureAwait(false);

            var produto = produtos.FirstOrDefault() ??
                throw new ArgumentNullException($"Produto {request.Id} não encontrado.");




            produto.Descricao = request.Descricao;
            if (request.IdCategorias.Any())
            {
                var categorias = _categoiaRepository.GetAll()
                    .Where(x => request.IdCategorias.Contains(x.Id)).ToList();
                produto.Categorias = categorias;
            }

            _genericRepository.Update(produto);

            return await _genericRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
