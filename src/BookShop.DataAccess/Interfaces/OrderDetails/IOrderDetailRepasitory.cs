using BookShop.DataAccess.Common.Interfaces;
using BookShop.DataAccess.ViewModel.OrderDetails;
using BookShop.Domain.Entities.Orders;

namespace BookShop.DataAccess.Interfaces.OrderDetails;

public interface IOrderDetailRepasitory:IRepasitory<OrderDetail,OrderDetail>,
    IGetAll<OrderDetailViewModel>
{

}
