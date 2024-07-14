﻿namespace YourQuoteBoard.Entity
{
    public class Folder
    {
        public Guid FolderId { get; set; }
        public string Name { get; set; } = "No name";
        public string Description { get; set; } = string.Empty;
        public int childQuotesCount { get; set; } = 0;
        public string ApplicationUserId { get; set; }
        public List<Quote>? Quotes { get; set; }
    }
}
