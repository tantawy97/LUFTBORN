using Application.BussinessLogic.Items.Command.Update;
using Core.Entities;

namespace Application.BussinessLogic.Items.Profiles
{
    public static class MappingItems
    {
        public static Item ToModel(this UpdateCommand itemCommand, Item item)
        {
            item.Name = itemCommand.Name;
            item.Price = itemCommand.Price;
            item.Quantity = itemCommand.Quantity;
            return item;
        }
    }
}
