import { getAllQuotes } from '../../api/quote'
import { useState, useEffect } from 'react';
import { QuoteDisplayDTO } from '../../models/quotes/QuoteDisplayDTO'; 
import AddQuoteCard from './AddQuoteCard';
import QuoteCard from './QuoteCard';

function BrowseQuotes(){
    
    const [quotes, setQuotes] = useState<QuoteDisplayDTO[]>([])

    useEffect(
        () => {
            const fetchQuotes = async () => {
                try{
                    const fetchedQuotes = await getAllQuotes();
                    setQuotes(fetchedQuotes)
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