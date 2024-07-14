import { QuoteDisplayDTO } from "../quotes/QuoteDisplayDTO";

export interface FolderContentDisplayDTO {
    id: string;
    name: string;
    childFolderCount: number;
    quotes: QuoteDisplayDTO[];
}