using MobileDemo.Orders;
using MobileDemo.Repository.IRepository;
using MobileDemo.Service.IService;

namespace MobileDemo.Service
{
    public class LineItemsService : ILineItemsService
    {
        private readonly ILineItemsRepository _lineItemsRepository;

        public LineItemsService(ILineItemsRepository lineItemsRepository)
        {
            _lineItemsRepository = lineItemsRepository;
        }

        public async Task<IEnumerable<LineItemsModel>> GetLineItemsAsync()
        {
            return await _lineItemsRepository.GetLineItemsAsync();
        }

        public async Task<LineItemsModel> GetLineItemByIdAsync(Guid id)
        {
            return await _lineItemsRepository.GetLineItemByIdAsync(id);
        }

        public async Task<LineItemsModel> CreateLineItemAsync(LineItemsModel lineItem)
        {
            return await _lineItemsRepository.CreateLineItemAsync(lineItem);
        }

        public async Task<LineItemsModel> UpdateLineItemAsync(Guid id, LineItemsModel lineItem)
        {
            return await _lineItemsRepository.UpdateLineItemAsync(id, lineItem);
        }

        public async Task<bool> DeleteLineItemAsync(Guid id)
        {
            return await _lineItemsRepository.DeleteLineItemAsync(id);
        }
    }
}
