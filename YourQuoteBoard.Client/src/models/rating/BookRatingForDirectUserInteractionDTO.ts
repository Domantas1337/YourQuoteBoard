import { BookRating } from "./BookRating";

export default interface BookRatingForDirectUserInteractionDTO{
    bookId?: string;
    bookRatingId?: string;
    bookRating: BookRating;
}