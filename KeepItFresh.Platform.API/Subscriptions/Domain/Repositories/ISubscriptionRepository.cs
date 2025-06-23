using KeepItFresh.Platform.API.Shared.Domain.Repositories;
using KeepItFresh.Platform.API.Subscriptions.Domain.Model.Aggregates;
using System;
using System.Threading.Tasks;

namespace KeepItFresh.Platform.API.Subscriptions.Domain.Repositories
{
    public interface ISubscriptionRepository : IBaseRepository<Subscription>
    {
        /// <summary>
        /// Obtiene una suscripción por el ID del usuario asociado.
        /// </summary>
        /// <param name="userId">Identificador único del usuario</param>
        /// <returns>Suscripción correspondiente al usuario, si existe</returns>
        Task<Subscription?> FindByUserIdAsync(Guid userId);

        /// <summary>
        /// Actualiza una suscripción existente en la base de datos.
        /// </summary>
        /// <param name="subscription">Objeto de suscripción con los datos actualizados</param>
        Task UpdateAsync(Subscription subscription);

        /// <summary>
        /// Registra una nueva suscripción en la base de datos.
        /// </summary>
        /// <param name="subscription">Objeto de suscripción a registrar</param>
        Task<Subscription> CreateAsync(Subscription subscription);
    }
}