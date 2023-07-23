using BookShop.DataAccess.Common.Interfaces;
using BookShop.DataAccess.ViewModel.Orders;
using BookShop.Domain.Entities;

namespace BookShop.DataAccess.Interfaces.Orders;

public interface IOrderRepasitory:IRepasitory<Order,OrderViewModel>,IGetAll<OrderViewModel>
{
}
