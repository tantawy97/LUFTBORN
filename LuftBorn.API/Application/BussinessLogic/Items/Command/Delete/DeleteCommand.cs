using Application.DTOs.Response;
using MediatR;

namespace Application.BussinessLogic.Items.Command.Delete
{
    public class DeleteCommand : IRequest<ResponseDto<bool>>
    {
        public Guid Id { get; set; }
    }
}
