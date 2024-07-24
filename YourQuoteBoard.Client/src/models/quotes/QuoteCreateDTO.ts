export interface QuoteCreateDTO{
    title: string;
    description: string;
    author: string;
    bookId: string | null;
    tagIds: string[];
}