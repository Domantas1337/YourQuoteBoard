import { useEffect, useState } from "react";
import { QuoteDisplayDTO } from "../../../models/quotes/QuoteDisplayDTO";
import { getAllQuotes } from "../../../api/quote";
import QuoteCard from "../quotesCard/QuoteCard";
import AddQuoteCard from "../quotesCard/AddQuoteCard";

function BrowseQuotes(){
    
    const [quotes, setQuotes] = useState<QuoteDisplayDTO[]>([])

    useEffect(
        () => {
            const fetchQuotes = async () => {
                try{
                    const fetchedQuotes = await getAllQuotes();
                    
                    if (fetchedQuotes){
                        setQuotes(fetchedQuotes)
                    }
                }catch(error){
                    console.log("error fetching quotes: ", error)
                }
            };
            fetchQuotes();
        }, []
    );

    return (
        <div> 
            <div className='card-container'>
                {
                    quotes.map( (quote, index) => (
                        <QuoteCard key={index} title={quote.title} shortDescription="desc" />
                    ))
                }
                <AddQuoteCard />
            </div>
        </div>
    );
}

export default BrowseQuotes;