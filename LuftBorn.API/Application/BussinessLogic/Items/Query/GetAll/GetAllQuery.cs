using Application.BussinessLogic.Items.DTOs;
using Application.DTOs;
using Application.DTOs.Response;
using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.BussinessLogic.Items.Query.GetAll
{
    public class GetAllQuery : IRequest<ResponseDto<List<ItemDto>>>
    {
        public PaginationDto PaginationdData { get; set; } = new PaginationDto();
    }
}
