using Application.BussinessLogic.Items.DTOs;
using Application.DTOs.Response;
using Application.Repositories.IRepository;
using Application.UnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.BussinessLogic.Items.Query.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, ResponseDto<ItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ResponseDto<ItemDto>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<ItemDto>(await _unitOfWork.Item.GetByIdAsync(request.Id));
            return ResponseDto<ItemDto>.SuccessResponse(item);
        }
    }
}
