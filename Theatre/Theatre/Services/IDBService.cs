using System.Collections.Generic;
using Theatre.Model;

namespace Theatre.Services
{
    public interface IDBService
    {
        void SavePerfomance(Performance performance);

        void SaveArticle(Article article);

        void SaveTheatre(Model.Theatre theatre);

        List<Performance> GetPerfomances();

        List<Performance> GetPerformancesByType(int type);

        List<Performance> SearchPerformances(string searchText);

        Performance GetPerformanceById(int id);
    }
}