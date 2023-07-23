using BookShop.DataAccess.Common.Interfaces;
using BookShop.DataAccess.ViewModel.Deliveries;
using BookShop.Domain.Entities.Deliveries;

namespace BookShop.DataAccess.Interfaces.Deliveries;

public interface IDeliverRepasitory:IRepasitory<Delivery,Delivery>,IGetAll<DeliverViewModel>
{
    public Task<DeliverViewModel> GetDeliverAsync(long id);

}
