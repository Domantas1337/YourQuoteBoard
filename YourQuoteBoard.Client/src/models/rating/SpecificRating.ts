import { BookRatingCategory } from "../../enums/BookRatingCategory";
import { QuoteRatingCategory } from "../../enums/QuoteRatingCategory";

export interface SpecificRating{
    specificRatingId?: number;
    rating?: number;
    ratingCategory: QuoteRatingCategory | BookRatingCategory;
}