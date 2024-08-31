import { SpecificRating } from "../SpecificRating";

export default interface BookRatingCreateDTO{
    bookId: string;
    specificRatings?: SpecificRating[];
    overallRating: number;
}