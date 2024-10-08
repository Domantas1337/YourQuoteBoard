import { apiClient } from "../apiClient";
import BookRatingCreateDTO from "../models/rating/book/BookRatingCreateDTO";
import BookRatingForDirectUserInteractionDTO from "../models/rating/book/BookRatingForDirectUserInteractionDTO";
import BookRatingUpdateDTO from "../models/rating/book/BookRatingUpdateDTO";

export async function addBookRating(rating: BookRatingCreateDTO) : Promise<string>{
    const response = await apiClient.post("api/BookRating/book-rating", rating); 
    return response.data;
}

export async function getUserBookRating(bookId: string) : Promise<BookRatingForDirectUserInteractionDTO | null>{
    const response = await apiClient.get(`api/BookRating/book-rating-by-user/${bookId}`); 
    const rating = response.data;

    return rating;
}

export async function updateBookRating(bookRating: BookRatingUpdateDTO){
    console.log(bookRating);
    const response = await apiClient.put("api/BookRating/update-book-rating", bookRating);
    return response;
}