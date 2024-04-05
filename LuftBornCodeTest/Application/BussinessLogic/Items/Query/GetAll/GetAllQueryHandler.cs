using Application.BussinessLogic.Items.DTOs;
using Application.DTOs.Response;
using Application.Repositories.IRepository;
using Application.Repositories.Repository;
using Application.UnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.BussinessLogic.Items.Query.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, ResponseDto<List<ItemDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ResponseDto<List<ItemDto>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var items = _mapper.Map<List<ItemDto>>(await _unitOfWork.Item.GetAllAsync(request.PaginationdData));
            return ResponseDto<List<ItemDto>>.SuccessResponse(items, count: await _unitOfWork.Item.GetCountAsync());
        }
    }
}
