export default interface BookRatingUpdateDTO{
    bookRatingId: string;
    bookId: string;
    previousRating: number;
    newRating: number;
}