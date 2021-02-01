using ElectronicShop.Data.Infrastructure;
using ElectronicShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicShop.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            //var query = from p in DbContext.Posts
            //            join pt in DbContext.PostTags
            //            on p.ID equals pt.PostID
            //            where pt.TagID == tag && p.Status
            //            orderby p.CreatedDate descending
            //            select p;

            var query = DbContext.Posts
                .Where(p => p.Status)
                .Join(
                    DbContext.PostTags.Where(pt => pt.TagID == tag),
                    p => p.ID,
                    pt => pt.PostID,
                    (p, pt) => p
                );

            query = query.OrderByDescending(p => p.CreatedDate);
            totalRow = query.Count();

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return query;
        }
    }
}