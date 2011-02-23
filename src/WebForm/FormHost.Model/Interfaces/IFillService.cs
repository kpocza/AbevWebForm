using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormHost.Model.Forms;
using FormHost.Model.Fillings;

namespace FormHost.Model.Interfaces
{
    /// <summary>
    /// Kitöltés szolgáltatás
    /// </summary>
    public interface IFillService : IFormHostService
    {
        /// <summary>
        /// Kitöltés lekérdezése
        /// </summary>
        /// <returns></returns>
        Fills ListFills();
        
        /// <summary>
        /// Kitöltés lekérdezése
        /// </summary>
        /// <returns></returns>
        Fill GetFillContent(int id);

        /// <summary>
        /// Kitöltés mentése
        /// </summary>
        /// <returns></returns>
        Fill Save(Fill fill);
    }
}
