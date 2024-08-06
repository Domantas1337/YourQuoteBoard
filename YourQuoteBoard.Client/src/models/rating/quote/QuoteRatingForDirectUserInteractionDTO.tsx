import { QuoteRatingInDetail } from "./QuoteRatingInDetail";

export interface QuoteRatingForDirectUserInteractionDTO{
    quoteRatingId: string;
    overallRating: number;
    quoteRatingInDetail: QuoteRatingInDetail;
    quoteId: string;
}