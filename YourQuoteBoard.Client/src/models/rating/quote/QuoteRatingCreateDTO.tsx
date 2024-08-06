import { QuoteRatingInDetail } from "./QuoteRatingInDetail";

export interface QuoteRatingCreateDTO{
    overallRating: number;
    quoteRatingInDetail: QuoteRatingInDetail;
    quoteId: string;
}