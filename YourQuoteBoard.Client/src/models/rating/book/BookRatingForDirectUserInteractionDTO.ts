import { SpecificRating } from "../SpecificRating";

export default interface BookRatingForDirectUserInteractionDTO{
    bookRatingId: string;
    overallRating: number;
    specificRatings: SpecificRating[];
    bookId: string;
}