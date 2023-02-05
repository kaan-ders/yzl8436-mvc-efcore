namespace MvcEf.Models
{
    public abstract class ModelBase
    {
        public int Id { get; set; }
        public bool SilindiMi { get; set; } //soft delete
    }
}