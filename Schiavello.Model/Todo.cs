namespace Schiavello.Model
{
    public abstract class RowEntity
    {
        public bool IsEdit { get; set; }
        public string ButtonText { get; set; } = "Edit";
    }
    public class Todo : RowEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}