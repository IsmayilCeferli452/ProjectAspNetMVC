namespace FiorelloAsp.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool SoftDeleted { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
