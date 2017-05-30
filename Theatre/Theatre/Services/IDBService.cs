using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theatre.Model;

namespace Theatre.Services
{
    public interface IDBService
    {
        void SavePerfomance(Performance performance);

        List<Performance> GetPerfomances();

        List<Performance> GetPerformancesByType(int type);

        List<Performance> SearchPerformances(string searchText);

        Performance GetPerformanceById(int id);
    }
}