import BookDisplayDTO from "../books/BookDisplayDTO";
import { QuoteDisplayDTO } from "../quotes/QuoteDisplayDTO";

export interface FolderUpdateDTO {
    folderId: string;
    name: string;
    items: QuoteDisplayDTO[] | BookDisplayDTO[];
}