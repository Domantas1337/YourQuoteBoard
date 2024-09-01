import { apiClient } from "../apiClient";
import { ItemType } from "../enums/ItemType";
import { QuoteDisplayDTO } from "../models/quotes/QuoteDisplayDTO";

export async function getAllFavoritesByUserId() : Promise<QuoteDisplayDTO[]>{
    const response = await apiClient.get("api/Favorite/user")
    const favorites = response.data;

    return favorites
}

export async function insertFavorite(quoteId: string){
    const response = await apiClient.post(`api/Favorite/${quoteId}`)

    return response;
}

export async function pingFavorite(quoteId: string, itemType: ItemType) : Promise<boolean>{
    const response = await apiClient.get(`api/Favorite/ping-favorite-${itemType}/${quoteId}`);
    const isFavorite = response.data;

    return isFavorite;
}

export async function deleteFavorite(quoteId: string){
    const response = await apiClient.delete(`api/Favorite/delete/${quoteId}`);
    return response;
}
