namespace ECommerceServices.Catalog.AppSettings
{
    public interface IDatabaseSettings
    {
        public string CategoryCollection { get; set; }
        public string CourseCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DBName { get; set; }
    }
}
