import { SpecificRating } from "../SpecificRating";

export interface QuoteRatingForDirectUserInteractionDTO{
    quoteRatingId: string;
    overallRating: number;
    specificRatings: SpecificRating[];
    quoteId: string;
}