import { QuoteDisplayDTO } from "../models/quotes/QuoteDisplayDTO";
import { apiClient } from "../apiClient";
import { QuoteCreateDTO } from "../models/quotes/QuoteCreateDTO";
import { QuoteFullDisplayDTO } from "../models/quotes/QuoteFullDisplayDTO";

export async function getAllQuotes(): Promise<QuoteDisplayDTO[] | null>{
    const response = await apiClient.get<QuoteDisplayDTO[]>('api/Quote/all-quotes') 
    const quotes = response.data;

    return quotes;
}

export async function getQuoteForDesignatedPage(quoteId: string): Promise<QuoteFullDisplayDTO>{
    const response = await apiClient.get<QuoteFullDisplayDTO>(`api/Quote/quote/${quoteId}`) 
    const quote = response.data;

    return quote;
}

export async function getAllPersonalQuotes(): Promise<QuoteDisplayDTO[]>{
    const response = await apiClient.get<QuoteDisplayDTO[]>('api/Quote/all-personal-quotes') 
    const quotes = response.data;

    return quotes;
}

export async function getQuotesByBookId(bookId: string) : Promise<QuoteDisplayDTO[] | null>{
    const response = await apiClient.get(`api/Quote/quotes-by-book/${bookId}`)
    const quotes = response.data;

    return quotes;
}

export async function createQuote(newQuote: QuoteCreateDTO){
    const response = await apiClient.post('api/Quote/add-quote/', newQuote)

    return response
}

export async function deleteSingleQuote(id: string){
    const response = await apiClient.delete(`api/Quote/delete-quote/${id}`)

    return response
}

export async function pingQuoteOwner(quoteId: string) {
    console.log("What id");
    console.log(quoteId);
    const response = await apiClient.get(`api/Quote/is-quote-users/${quoteId}`)
    const data = response.data;

    return data
}