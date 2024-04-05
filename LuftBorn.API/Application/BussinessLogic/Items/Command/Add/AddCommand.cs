using Application.BussinessLogic.Items.DTOs;
using Application.DTOs.Response;
using MediatR;

namespace Application.BussinessLogic.Items.Command.Add
{
    public class AddCommand : IRequest<ResponseDto<ItemDto>>
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public double Quantity { get; set; }
    }
}
