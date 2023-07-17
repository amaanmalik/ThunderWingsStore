using ThunderWings.Api.Repositories.IRepositories;
using ThunderWings.Api.Models.Domain;

    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        void Update(OrderDetail obj);
    }
