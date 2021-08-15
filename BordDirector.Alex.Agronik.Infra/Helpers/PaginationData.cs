using System;
using System.Collections.Generic;
using System.Text;

namespace BordDirector.Alex.Agronik.Infra.Helpers
{
    public class PaginationData
    {
        public int PageNumber { get; set; }
        public int ItemsOnPage { get; set; }
        public int Skip { get => PageNumber < 1 ? 0 : (PageNumber - 1) * ItemsOnPage; }
    }
}
