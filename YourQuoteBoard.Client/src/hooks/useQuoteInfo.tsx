import { useEffect, useState } from "react";
import { QuoteFullDisplayDTO } from "../models/quotes/QuoteFullDisplayDTO";
import { getQuoteForDesignatedPage } from "../api/quote";
import { getUserQuoteRating } from "../api/quoteRating";
import { SpecificRating } from "../models/rating/SpecificRating";

export default function useQuoteInfo(id: string){

    const [quote, setQuote] = useState<QuoteFullDisplayDTO>({
        title: "",
        description: "",
        author: "",
        created: new Date(2000, 1, 1),
        bookTitle: "",
        bookId: "",
        averageRating: 0,
        numberOfRatings: 0,
        tags: []
    });
    const [overallRating, setOverallRating] = useState<number>(0);
    const [specificRatings, setSpecificRatings] = useState<SpecificRating[]>([])
    const [quoteRatingId, setQuoteRatingId] = useState<string | undefined>(undefined);

    useEffect(() => {
        const fetchQuoteInfo = async () => {
            try{
                const fetchedQuote = await getQuoteForDesignatedPage(id);
                const rating = await getUserQuoteRating(id);
    
                setQuote(fetchedQuote);
                
                if (rating){
                    setQuoteRatingId(rating.quoteRatingId);
                    setOverallRating(rating.overallRating);
                    setSpecificRatings(rating.specificRatings);
                }
            }catch(error){
                console.log("Failed to fetch quote details: ", error);
            }

        }
        fetchQuoteInfo();
    }, [id])


    return {overallRating, setOverallRating, 
            quote, setQuote, 
            specificRatings, setSpecificRatings,
            quoteRatingId};
}

