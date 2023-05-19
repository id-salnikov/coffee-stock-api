using Coffee.StockApi.Domain.AggregationModels.StockItemAggregate;
using Coffee.StockApi.Domain.Contracts;
using Coffee.StockApi.Infrastructure.Handlers.StockItemAggregate;
using Microsoft.Extensions.DependencyInjection;

namespace Coffee.StockApi.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(CreateStockItemCommandHandler).Assembly);
        });
            
        return services;
    }
    
    public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services) {
        services.AddScoped<IStockItemRepository, Repo>();
        return services;
    }
    
    public class Repo : IStockItemRepository 
    {
        public Repo() {
            UnitOfWork = new UOW();
        }
        public IUnitOfWork UnitOfWork { get; }
        public Task<StockItem> CreateAsync(StockItem itemToCreate, CancellationToken cancellationToken = default) {
            return Task.FromResult<StockItem>(new StockItem(
                new Name("test"),
                new Sku(1),
                new Volume(1000),
                new Quantity(10),
                new Quantity(2),
                new Item(ItemType.Coffee)
                ));
        }

        public Task<StockItem> UpdateAsync(StockItem itemToUpdate, CancellationToken cancellationToken = default) {
            throw new NotImplementedException();
        }

        public Task<StockItem> FindByIdAsync(long id, CancellationToken cancellationToken = default) {
            throw new NotImplementedException();
        }

        public Task<StockItem> FindBySkuAsync(Sku sku, CancellationToken cancellationToken = default) {
            return Task.FromResult<StockItem?>(null);
        }
    }
    
    class UOW : IUnitOfWork
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
            return Task.FromResult(1);
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default) {
            return Task.FromResult<bool>(true);
        }
    }
}