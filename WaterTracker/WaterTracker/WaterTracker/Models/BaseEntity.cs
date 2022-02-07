using SQLite;

namespace WaterTracker.Models
{
    public abstract class BaseEntity : IEntity
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public virtual int Id { get; set; }
    }
}
