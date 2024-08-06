import { BookRating } from "./BookRating";

export default interface BookRatingDisplayDTO{
    bookId: string;
    bookRating: BookRating;
}