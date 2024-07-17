import { QuoteDisplayDTO } from "../quotes/QuoteDisplayDTO";

export interface FolderContentDisplayDTO {
    folderId: string;
    name: string;
    childFolderCount: number;
    quotes: QuoteDisplayDTO[];
}