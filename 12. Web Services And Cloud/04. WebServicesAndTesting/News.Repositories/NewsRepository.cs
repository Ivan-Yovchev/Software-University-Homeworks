namespace News.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class NewsRepository : IRepository<NewsItem>
    {
        private readonly DbContext context;

        public NewsRepository(DbContext context)
        {
            this.context = context;
        }

        public NewsItem Add(NewsItem entity)
        {
            this.context.Set<NewsItem>().Add(entity);
            return entity;
        }

        public NewsItem Find(int id)
        {
            var entity = this.context.Set<NewsItem>().Find(id);
            if (entity == null)
            {
                throw new IndexOutOfRangeException();
            }

            return entity;
        }

        public IQueryable<NewsItem> All()
        {
            return this.context.Set<NewsItem>();
        }

        public void Delete(NewsItem entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public void Update(NewsItem entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private void ChangeState(NewsItem news, EntityState state)
        {
            var entry = this.context.Entry(news);
            if (entry.State == EntityState.Detached)
            {
                this.context.Set<NewsItem>().Attach(news);
            }

            entry.State = state;
        }
    }
}
