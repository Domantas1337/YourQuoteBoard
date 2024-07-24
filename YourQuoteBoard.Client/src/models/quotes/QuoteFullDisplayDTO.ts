import { TagDisplayDTO } from "../tag/TagDisplayDTO";

export interface QuoteFullDisplayDTO{
    title: string;
    description: string;
    author: string;
    created: Date;
    bookTitle: string;
    bookId: string;
    averageRating: number | null;
    numberOfRatings: number | null;
    tags: TagDisplayDTO[]; 
}