import { SpecificRating } from "../SpecificRating";

export default interface BookRatingUpdateDTO{
    bookRatingId: string;
    specificRatings: SpecificRating[];
    overallRating: number;
    bookId: string;
}