import { BookRating } from "./BookRating";

export default interface BookRatingCreateDTO{
    bookId: string;
    bookRating: BookRating;
}