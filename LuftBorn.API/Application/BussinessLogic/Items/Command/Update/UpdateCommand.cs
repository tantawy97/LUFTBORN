using Application.DTOs.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Application.BussinessLogic.Items.Command.Update
{
    public class UpdateCommand : IRequest<ResponseDto<bool>>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public double Quantity { get; set; }
    }
}
