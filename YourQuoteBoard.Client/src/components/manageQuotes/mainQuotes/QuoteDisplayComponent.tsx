import { QuoteDisplayDTO } from "../../../models/quotes/QuoteDisplayDTO"
import AddQuoteCard from "../quotesCard/AddQuoteCard";
import QuoteCard from "../quotesCard/QuoteCard";

interface QuoteDisplayComponentProps{
    quotes: QuoteDisplayDTO[] | null;
    allowToAddQuotes: boolean;
}

export default function QuoteDisplayAndAddComponent({quotes, allowToAddQuotes} : QuoteDisplayComponentProps){
    
    return (
        <div> 
            <div className='card-container'>
                {quotes && 
                    quotes.map( (quote, index) => (
                        <QuoteCard key={index} quoteId={quote.quoteId} title={quote.title} shortDescription="description" />
                    ))
                }
                { allowToAddQuotes === true ? 
                    <AddQuoteCard /> : <></>
                }
                
            </div>
        </div>
    );
}