import { BookRating } from "./BookRating";

export default interface BookRatingUpdateDTO{
    bookRatingId: string;
    bookId: string;
    currentRating: BookRating;
    newRating: BookRating;
}