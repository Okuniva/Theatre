using System.Collections.Generic;
using Theatre.Model;

namespace Theatre.Services
{
    public interface IDBService
    {
        void SavePerfomance(Performance performance);

        void SaveArticle(Article article);

        void SaveTheatre(Model.Theatre theatre);

        void SaveTicket(Ticket ticket);

        List<Performance> GetPerfomances();

        List<Performance> GetPerformancesByType(int type);

        List<Ticket> GetTickets();

        List<Article> GetArticles();

        List<Performance> SearchPerformances(string searchText);

        List<Performance> GetPerformancesByDate(string date);

        Performance GetPerformanceById(int id);
    }
}