using Application.BussinessLogic.Items.Profiles;
using Application.Configuration;
using Application.DTOs.Response;
using Application.Repositories.IRepository;
using Application.UnitOfWorks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Application.BussinessLogic.Items.Command.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, ResponseDto<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ResponseDto<bool>> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.Item.GetByIdAsync(request.Id);
            if (item is null)
                throw new NotFoundException("Model Not Found");
            item = request.ToModel(item);
            return await _unitOfWork.Item.UpdateAsync(item) ? ResponseDto<bool>.SuccessResponse(true)
                           : throw new InternalServerException("An Error Occured");
        }
    }

}
