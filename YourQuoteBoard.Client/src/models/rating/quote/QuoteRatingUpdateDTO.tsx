import { SpecificRating } from "../SpecificRating";

export interface QuoteRatingUpdateDTO{
    quoteRatingId: string;
    specificRatings: SpecificRating[];
    overallRating: number;
    quoteId: string;
}