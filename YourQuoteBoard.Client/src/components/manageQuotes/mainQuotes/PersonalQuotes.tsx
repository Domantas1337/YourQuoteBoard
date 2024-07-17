import { useEffect, useState } from "react";
import { QuoteDisplayDTO } from "../../../models/quotes/QuoteDisplayDTO";
import { getAllPersonalQuotes } from "../../../api/quote";
import QuoteCard from "../quotesCard/QuoteCard";
import AddQuoteCard from "../quotesCard/AddQuoteCard";

export default function PersonalQuotes(){
    const [personalQuotes, setPersonalQuotes] = useState<QuoteDisplayDTO[]>([]); 

    useEffect(
        () => {
            const fetchQuotes = async () => {
                try{
                    const fetchedQuotes = await getAllPersonalQuotes();
                    setPersonalQuotes(fetchedQuotes);
                }catch(error){
                    console.log("Error whole fetching quotes: ", error);
                }
            }
            fetchQuotes();
        }, []
    );

    return (
        <div> 
            <div className='card-container'>
                {
                    personalQuotes.map( (quote, index) => (
                        <QuoteCard key={index} title={quote.title} shortDescription="desc" />
                    ))
                }
                <AddQuoteCard />
            </div>
        </div>
    );
}
