using Application.Configuration;
using Application.DTOs.Response;
using Application.Repositories.IRepository;
using Application.UnitOfWorks;
using AutoMapper;
using MediatR;

namespace Application.BussinessLogic.Items.Command.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, ResponseDto<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ResponseDto<bool>> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.Item.GetByIdAsync(request.Id);
            if (item is null)
                throw new NotFoundException("Model Not Found");

            return await _unitOfWork.Item.DelteAsync(item) ? ResponseDto<bool>.SuccessResponse(true)
                : throw new InternalServerException("An Error Occured");

        }
    }

}
