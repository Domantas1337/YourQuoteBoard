import { SpecificRating } from "../SpecificRating";

export default interface BookRatingDisplayDTO{
    overallRating: number;
    specificRatings: SpecificRating[];
    bookId: string;
}