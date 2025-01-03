﻿using TravelManagement.Models.Driver;
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
