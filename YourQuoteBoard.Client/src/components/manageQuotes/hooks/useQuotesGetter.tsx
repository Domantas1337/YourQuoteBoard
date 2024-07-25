import { useEffect, useState } from "react"
import { QuoteDisplayDTO } from "../../../models/quotes/QuoteDisplayDTO";
import { getAllPersonalQuotes, getAllQuotes } from "../../../api/quote";

type QuoteType = "all" | "personal";

export default function useQuotesGetter(quoteType: QuoteType = 'all'){

    const [quotes, setQuotes] = useState<QuoteDisplayDTO[]>([]);

    useEffect(
        () => {
            const fetchQuotes = async () => {
                try{
                    const fetchedQuotes = quoteType === "all" ? 
                        await getAllQuotes() :
                        await getAllPersonalQuotes();
                    
                    
                    if (fetchedQuotes){
                        setQuotes(fetchedQuotes)
                    }
                }catch(error){
                    console.log("error fetching quotes: ", error)
                }
            };
            fetchQuotes();
        }, [quoteType]
    );

    return {quotes};
}