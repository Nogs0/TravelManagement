namespace TravelManagement.Models.Shared.Actions
{
    public interface IUpdater<Model, PKType>
        where Model : class
        where PKType : struct
    {
        Task<Model> UpdateAsync(Model model);
    }
}
