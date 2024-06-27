export default interface BookDisplayDTO{
    bookId: string;
    title: string;
    author: string;
    coverImagePath: string;
    averageRating: number | null;
    numberOfRatings: number | null;
}