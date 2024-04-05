using Application.BussinessLogic.Items.DTOs;
using Application.DTOs.Response;
using MediatR;

namespace Application.BussinessLogic.Items.Query.GetById
{
    public class GetByIdQuery : IRequest<ResponseDto<ItemDto>>
    {
        public Guid Id { get; set; }
    }
}
