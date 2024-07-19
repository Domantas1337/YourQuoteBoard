import { useEffect, useState } from "react";
import { QuoteDisplayDTO } from "../../../models/quotes/QuoteDisplayDTO";
import { getAllQuotes } from "../../../api/quote";
import QuoteCard from "../quotesCard/QuoteCard";
import AddQuoteCard from "../quotesCard/AddQuoteCard";
import { useNavigate } from "react-router-dom";

function BrowseQuotes(){
    
    const [quotes, setQuotes] = useState<QuoteDisplayDTO[]>([])
    const navigate = useNavigate();

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

    const handleCardClick = (quoteId: string) => {
        console.log(`Navigating to quote/${quoteId}`); 
        navigate(`/quote/${quoteId}`);
    }

    return (
        <div className='card-container'>
            {
                quotes.map( (quote, index) => (
                    <div className="test-classname" key={index}>
                        <QuoteCard title={quote.title} shortDescription="desc" 
                            onClick={
                                () => handleCardClick(quote.quoteId)
                            }
                            />
                    </div>
                ))
            }
            <AddQuoteCard />
        </div>
    );
}

export default BrowseQuotes;