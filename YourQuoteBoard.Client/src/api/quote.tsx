import { QuoteDisplayDTO } from "../models/QuoteDisplayDTO";
import { apiClient } from "../apiClient";

async function getAllQuotes(): Promise<QuoteDisplayDTO[]>{
    const response = await apiClient.get<QuoteDisplayDTO[]>('api/Quote/allQuotes') 
    
    return response.data;
}

export default getAllQuotes