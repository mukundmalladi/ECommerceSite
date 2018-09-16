using System.Collections.Generic;

namespace EcommerceMvc.Models.ModelHelpers
{
    public class IndexToElasticSearch
    {
        public IndexToElasticSearch()
        {
            Items = new Dictionary<long, long>();
        }
        public long Id { get; set; }

        public Dictionary<long, long> Items { get; set; }
    }

    public class PartialIndexToElasticSearch
    {
        public Dictionary<long, long> Items { get; set; }
    }
}