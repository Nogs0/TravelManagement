using ClosedXML.Excel;
using TravelManagement.Models.Driver;
using TravelManagement.Models.Entries.Service.Actions;
using TravelManagement.Models.Shared.Service;

namespace TravelManagement.Models.Entries.Service
{
    public class EntryService : IServiceBase
    {
        private readonly CreatorEntry _creator;
        private readonly GetterEntry _getter;
        private readonly UpdaterEntry _updater;

        public EntryService(CreatorEntry creator, GetterEntry getter, UpdaterEntry updater)
        {
            _creator = creator;
            _getter = getter;
            _updater = updater;
        }

        public async Task<EntryModel> CreateAsync(EntryModel input)
        {
            return await _creator.CreateAsync(input);
        }

        public IEnumerable<EntryModel> GetAll()
        {
            return _getter.GetAll();
        }

        public async Task<byte[]> GetExcelByDriverId(long driverId)
        {
            var entries = await _getter.GetAllByDriverId(driverId);

            using (XLWorkbook workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Entradas");

            }


        }

        private IXLWorksheet ProcessList(List<EntryModel> entries, IXLWorksheet ws)
        {
            var headers = new List<string>() {
                "Data",
                "Motorista",
                "Valor",
                "Rota"
            };

            for (int i = 0; i < entries.Count; i++)
            {
                var entry = entries[i];
                ws.Cell(i, 1).Value = entry.Date.ToString("dd/MM/yyyy HH:mm");
                ws.Cell(i, 2).Value = entry.Driver.Name;
                ws.Cell(i, 3).Value = entry.Value;
            }

            return ws;
        }

        public async Task<EntryModel> GetAsync(long id)
        {
            return await _getter.GetAsync(id);
        }

        public async Task<EntryModel> UpdateAsync(EntryModel input)
        {
            return await _updater.UpdateAsync(input);
        }
    }
}
