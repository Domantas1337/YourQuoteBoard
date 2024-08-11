import { useEffect, useState } from "react";
import { QuoteDisplayDTO } from "../../models/quotes/QuoteDisplayDTO";
import QuoteDisplayComponent from "../../components/manageQuotes/mainQuotes/QuoteDisplayAndAddComponent";
import { getAllQuotes } from "../../api/quote";

export default function RecommendedQuotesPage(){
    const [recommendedQuotes, setRecommendedQuotes] = useState<QuoteDisplayDTO[] | null>(null);

    useEffect(() => {
        const getRecommendedQuotes = async () => {
            try{
                const quotes = await getAllQuotes();
                setRecommendedQuotes(quotes);
            }catch(error){
                console.log("Error while fetching quotes", error)
            }
        }
        getRecommendedQuotes();
    }, []);

    return <><QuoteDisplayComponent quotes={recommendedQuotes} allowToAddQuotes={false}/></>
}