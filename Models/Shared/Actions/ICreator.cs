namespace TravelManagement.Models.Shared.Actions
{
    public interface ICreator<Model, PKType>
        where Model : class
        where PKType : struct
    {
        Task<Model> CreateAsync(Model model);
    }
}
