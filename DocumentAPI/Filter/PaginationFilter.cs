using System.Runtime.Serialization;

namespace DocumentAPI.Filter
{
    public class PaginationFilter
    {
        [DataMember(Name = "page")]
        public int Page { get; set; }

        [DataMember(Name = "perPage")]
        public int PerPage { get; set; }

        public PaginationFilter()
        {
            this.Page = 1;
            this.PerPage = 10;
        }
        public PaginationFilter(int page, int perPage)
        {
            this.Page = page < 1 ? 1 : page;
            this.PerPage = perPage > 10 ? 10 : perPage;
        }
    }
}
