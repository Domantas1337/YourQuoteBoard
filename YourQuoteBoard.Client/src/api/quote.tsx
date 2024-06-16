import { QuoteDisplayDTO } from "../models/QuoteDisplayDTO";
import { apiClient } from "../apiClient";
import { QuoteCreateDTO } from "../models/QuoteCreateDTO";

export async function getAllQuotes(): Promise<QuoteDisplayDTO[]>{
    const response = await apiClient.get<QuoteDisplayDTO[]>('api/Quote/all-quotes') 
    const quotes = response.data;

    return quotes;
}

export async function createQuote(newQuote: QuoteCreateDTO){
    const response = await apiClient.post('api/Quote/add-quote', newQuote)

    return response
}
