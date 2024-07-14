import BookDisplayDTO from "../books/BookDisplayDTO";
import { QuoteDisplayDTO } from "../quotes/QuoteDisplayDTO";

export interface FolderUpdateDTO {
    id: string;
    name: string;
    items: QuoteDisplayDTO[] | BookDisplayDTO[];
}