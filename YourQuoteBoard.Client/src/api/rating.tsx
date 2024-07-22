import { apiClient } from "../apiClient";
import BookRatingCreateDTO from "../models/rating/BookRatingCreateDTO";
import BookRatingForDirectUserInteractionDTO from "../models/rating/BookRatingForDirectUserInteractionDTO";
import BookRatingUpdateDTO from "../models/rating/BookRatingUpdateDTO";

export async function addBookRating(rating: BookRatingCreateDTO){
    const response = await apiClient.post("api/BookRating/book-rating", rating); 
    return response;
}

export async function getUserBookRating(bookId: string) : Promise<BookRatingForDirectUserInteractionDTO | null>{
    const response = await apiClient.get(`api/BookRating/book-rating-by-user/${bookId}`); 
    const rating = response.data;

    return rating;
}

export async function updateBookRating(bookRating: BookRatingUpdateDTO){
    const response = await apiClient.put("api/BookRating/update-book-rating", bookRating);
    return response;
}