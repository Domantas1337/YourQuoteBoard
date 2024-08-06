import { apiClient } from "../apiClient";
import { QuoteRatingCreateDTO } from "../models/rating/quote/QuoteRatingCreateDTO";
import { QuoteRatingForDirectUserInteractionDTO } from "../models/rating/quote/QuoteRatingForDirectUserInteractionDTO";
import { QuoteRatingUpdateDTO } from "../models/rating/quote/QuoteRatingUpdateDTO";

export async function addQuoteRating(rating: QuoteRatingCreateDTO){
    const response = await apiClient.post("api/QuoteRating/quote-rating", rating); 
    return response;
}

export async function getUserQuoteRating(quoteId: string) : Promise<QuoteRatingForDirectUserInteractionDTO | null>{
    const response = await apiClient.get(`api/QuoteRating/quote-rating-by-user/${quoteId}`); 
    const rating = response.data;

    console.log(rating);
    return rating;
}

export async function updateQuoteRating(quoteRating: QuoteRatingUpdateDTO){
    const response = await apiClient.put("api/QuoteRating/update-quote-rating", quoteRating);
    return response;
}