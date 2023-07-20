namespace BookShop.Domain.Entities.Books
{
    public class Book:Auditable
    {
        public string Title { get; set; } = String.Empty;

        public long CategoryID { get; set; }

        public string Description { get; set; } = String.Empty;

        public double UnitPrice { get; set; }

        public string ImagePath { get; set; } = String.Empty;

        public string ISBN { get; set; } = String.Empty;

        public string Author { get; set; } = String.Empty;

        public string BookLanguage { get; set; } = String.Empty;

        public string Inscription { get; set; } = String.Empty;

        public int PageCount { get; set; }

        public string PaperFormat { get; set; } = String.Empty;
        
        public string Publisher { get; set; } = String.Empty;

        public string Cover { get; set; } = String.Empty;

        public string YeraOfPublication { get; set; } = String.Empty;

    }
}
