using KeepItFresh.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using KeepItFresh.Platform.API.Subscriptions.Domain.Model.Aggregates;
using KeepItFresh.Platform.API.Subscriptions.Domain.Repositories;
using KeepItFresh.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KeepItFresh.Platform.API.Subscriptions.Infrastructure.Persistence.EFC.Repositories
{
    public class SubscriptionRepository(AppDbContext context)
        : BaseRepository<Subscription>(context), ISubscriptionRepository
    {
        public async Task<Subscription?> FindByUserIdAsync(Guid userId)
        {
            return await Context.Set<Subscription>().FirstOrDefaultAsync(s => s.UserId == userId);
        }

        public async Task<Subscription> CreateAsync(Subscription subscription)
        {
            await Context.Set<Subscription>().AddAsync(subscription);
            await Context.SaveChangesAsync();
            return subscription;
        }

        public async Task UpdateAsync(Subscription subscription)
        {
            Context.Set<Subscription>().Update(subscription);
            await Context.SaveChangesAsync();
        }
    }
}