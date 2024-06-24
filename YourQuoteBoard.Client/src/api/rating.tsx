import { apiClient } from "../apiClient";
import BookRatingForDirectUserInteractionDTO from "../models/rating/BookRatingForDirectUserInteractionDTO";
import BookRatingUpdateDTO from "../models/rating/BookRatingUpdateDTO";

export async function addBookRating(rating: BookRatingForDirectUserInteractionDTO){
    console.log("Response");
    const response = await apiClient.post("api/Ratings/book-rating", rating); 
    console.log("Response");
    console.log(response);
    return response;
}

export async function getUserBookRating(bookId: string) : Promise<BookRatingForDirectUserInteractionDTO | null>{
    const response = await apiClient.get(`api/Ratings/book-rating-by-user/${bookId}`); 
    const rating = response.data;

    return rating;
}

export async function updateBookRating(bookRating: BookRatingUpdateDTO){
    const response = await apiClient.put("api/Ratings/update-book-rating", bookRating);
    return response;
}