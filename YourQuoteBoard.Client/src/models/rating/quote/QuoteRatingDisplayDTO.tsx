import { SpecificRating } from "../SpecificRating";

export interface QuoteRatingDisplayDTO{
    overallRating: number;
    specificRatings: SpecificRating[];
    quoteId: string;
}