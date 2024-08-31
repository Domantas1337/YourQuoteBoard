import { SpecificRating } from "../SpecificRating";

export interface BookRating{
    overallRating?: number;
    specificRatings: SpecificRating[];
}