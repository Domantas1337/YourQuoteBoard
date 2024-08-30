import { SpecificRating } from "../SpecificRating";

export interface QuoteRatingCreateDTO{
    overallRating: number;
    specificRatings?: SpecificRating[];
    quoteId: string;
}
