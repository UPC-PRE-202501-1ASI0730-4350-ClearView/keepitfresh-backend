using KeepItFresh.Platform.API.Sensor.Domain.Model.Aggregates;

namespace KeepItFresh.Platform.API.Sensor.Domain.Repositories;

public interface ISensorRepository
{
    Task<IEnumerable<SensorAggregate>> GetAllAsync();
    Task<SensorAggregate?> GetByIdAsync(string id);
    Task AddAsync(SensorAggregate sensor);
    Task UpdateAsync(SensorAggregate sensor);
}