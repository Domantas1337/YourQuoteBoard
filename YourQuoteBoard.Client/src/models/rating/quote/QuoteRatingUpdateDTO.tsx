import { QuoteRatingInDetail } from "./QuoteRatingInDetail";

export interface QuoteRatingUpdateDTO{
    quoteRatingId: string;
    quoteRatingInDetail: QuoteRatingInDetail;
    overallRating: number;
    quoteId: string;
}