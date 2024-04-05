using Application.BussinessLogic.Items.DTOs;
using Application.Configuration;
using Application.DTOs.Response;
using Application.Repositories.IRepository;
using Application.UnitOfWorks;
using AutoMapper;
using Core.Entities;
using MediatR;

namespace Application.BussinessLogic.Items.Command.Add
{
    public class AddCommandHandler : IRequestHandler<AddCommand, ResponseDto<ItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ResponseDto<ItemDto>> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Item>(request);
            var itemDto = _mapper.Map<ItemDto>(await _unitOfWork.Item.AddAsync(item));
            return ResponseDto<ItemDto>.SuccessResponse(itemDto);
        }
    }
}
