using MobileDemo.Orders;

namespace MobileDemo.Repository.IRepository
{
    public interface ILineItemsRepository
    {
        Task<IEnumerable<LineItemsModel>> GetLineItemsAsync();
        Task<LineItemsModel> GetLineItemByIdAsync(Guid id);
        Task<LineItemsModel> CreateLineItemAsync(LineItemsModel lineItem);
        Task<LineItemsModel> UpdateLineItemAsync(Guid id, LineItemsModel lineItem);
        Task<bool> DeleteLineItemAsync(Guid id);
    }
}
