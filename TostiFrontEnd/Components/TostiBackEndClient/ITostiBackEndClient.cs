using System.Collections.Generic;
using TostiBusinessEntities;

namespace TostiFrontEnd.Components.TostiBackEndClient
{
    public interface ITostiBackEndClient
    {
        List<Tosti> GetAllTostis();
        Tosti GetTosti(int id);
        bool UpsertTosti(Tosti tosti);
        bool DeleteTosti(Tosti tosti);
        string GetBackendUrl();
    }
}