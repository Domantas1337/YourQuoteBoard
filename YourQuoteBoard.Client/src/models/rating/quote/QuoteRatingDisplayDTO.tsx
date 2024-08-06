import { QuoteRatingInDetail } from "./QuoteRatingInDetail";

export interface QuoteRatingDisplayDTO{
    overallRating: number;
    quoteRatingInDetail: QuoteRatingInDetail;
    quoteId: string;
}