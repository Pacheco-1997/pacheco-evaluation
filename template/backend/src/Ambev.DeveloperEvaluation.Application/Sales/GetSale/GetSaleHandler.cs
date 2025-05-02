using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Validators.Sales;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleHandler : IRequestHandler<GetSaleQuery, GetSaleResult?>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public GetSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<GetSaleResult?> Handle(GetSaleQuery request, CancellationToken cancellationToken)
        {
            // 1) Validação
            var validator = new GetSaleQueryValidator();
            var validation = await validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            // 2) Busca a venda
            var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);
            return sale == null ? null : _mapper.Map<GetSaleResult>(sale);
        }
    }
}
