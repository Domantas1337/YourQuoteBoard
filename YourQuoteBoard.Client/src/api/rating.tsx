import { apiClient } from "../apiClient";
import BookRatingDTO from "../models/rating/BookRatingDTO";

export async function addBookRating(rating: BookRatingDTO){
    const response = await apiClient.post("api/Ratings/book-rating", rating); 
    return response;
}