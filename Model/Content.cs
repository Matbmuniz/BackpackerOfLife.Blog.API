namespace BackpackerOfLife.Blog.API.Model
{
    public sealed class Content
    {
        public int Id { get; set; }
        public int Views { get; set; } = 0;
        public int Likes { get; set; } = 0;
        public string Title { get; set; }
        public bool IsActive { get; set; } = true;
        public string Description { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime? FinishedDate { get; set; }
    }
}
