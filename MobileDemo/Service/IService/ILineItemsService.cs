using MobileDemo.Orders;

namespace MobileDemo.Service.IService
{
    public interface ILineItemsService
    {
        Task<IEnumerable<LineItemsModel>> GetLineItemsAsync();
        Task<LineItemsModel> GetLineItemByIdAsync(Guid id);
        Task<LineItemsModel> CreateLineItemAsync(LineItemsModel lineItem);
        Task<LineItemsModel> UpdateLineItemAsync(Guid id, LineItemsModel lineItem);
        Task<bool> DeleteLineItemAsync(Guid id);
    }
}
