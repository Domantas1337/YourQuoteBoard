import { BookRatingCategory } from "../../enums/BookRatingCategory";
import { QuoteRatingCategory } from "../../enums/QuoteRatingCategory";

export interface SpecificRatingForUpdateDTO{
    specificRatingId: string;
    rating?: number;
    ratingCategory: QuoteRatingCategory | BookRatingCategory;
}