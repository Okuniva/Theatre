using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using Theatre.Model;

namespace Theatre.Services
{
    public class RealmDBService : IDBService
    {
        private Realm RealmInstance;

        public RealmDBService()
        {
            RealmInstance = Realm.GetInstance();
        }

        public Performance GetPerformanceById(int id)
        {
            var list = GetPerfomances();
            return list.FirstOrDefault(p => p.id == id);
        }

        public List<Performance> GetPerfomances()
        {
            return RealmInstance.All<Performance>().ToList();
        }

        public List<Performance> GetPerformancesByType(int type)
        {
            return RealmInstance.All<Performance>().Where(t => t.p_type_id == type).ToList();
        }

        public void SavePerfomance(Performance performance)
        {
            RealmInstance.Write(() => RealmInstance.Add(performance, true));
        }

        public List<Performance> SearchPerformances(string searchText)
        {
            return RealmInstance.All<Performance>()
                .Where(p => p.name.Contains(searchText) || p.desc.Contains(searchText)).ToList();
        }
    }
}
