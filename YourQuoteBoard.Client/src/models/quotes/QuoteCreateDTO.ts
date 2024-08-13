export interface QuoteCreateDTO{
    title: string;
    shortDescription: string;
    description: string;
    author: string;
    bookId: string | null;
    tagIds: string[];
}