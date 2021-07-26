namespace Api.Data.Context
{
    public class MyContext:DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public MyContext (DbCOntextOptions<MyContext> options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
