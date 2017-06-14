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
        protected Realm RealmInstance;

        public RealmDBService()
        {
            RealmInstance = Realm.GetInstance();
        }

        public Performance GetPerformanceById(int id)
        {
            var list = GetPerfomances();
            return list.FirstOrDefault(p => p.id == id);
        }

        public void SaveArticle(Article article)
        {
            RealmInstance.Write(() => RealmInstance.Add(article, true));
        }

        public void SaveTheatre(Model.Theatre theatre)
        {
            RealmInstance.Write(() => RealmInstance.Add(theatre, true));
        }

        public void SavePerfomance(Performance performance)
        {
            RealmInstance.Write(() => RealmInstance.Add(performance, true));
        }

        public void SaveTicket(Ticket ticket)
        {
            RealmInstance.Write(() => RealmInstance.Add(ticket, true));
        }

        public List<Performance> GetPerfomances()
        {
            return RealmInstance.All<Performance>().ToList();
        }

        public List<Performance> GetPerformancesByType(int type)
        {
            Debug.WriteLine(RealmInstance.All<Performance>().Count(t => t.p_type_id == type));
            return RealmInstance.All<Performance>().Where(t => t.p_type_id == type).ToList();
        }

        public List<Performance> SearchPerformances(string searchText)
        {
            return RealmInstance.All<Performance>()
                .Where(p => p.name.Contains(searchText) || p.desc.Contains(searchText)).ToList();
        }

        public List<Ticket> GetTickets()
        {
            return RealmInstance.All<Ticket>().ToList();
        }

        public List<Article> GetArticles()
        {
            return RealmInstance.All<Article>().ToList();
        }

        public List<Performance> GetPerformancesByDate(string date)
        {
            return RealmInstance.All<Performance>().Where(p => p.near.Contains(date)).ToList();
        }
    }
}
