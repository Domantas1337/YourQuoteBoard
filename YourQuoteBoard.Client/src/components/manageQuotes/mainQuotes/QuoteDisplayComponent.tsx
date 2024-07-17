import { QuoteDisplayDTO } from "../../../models/quotes/QuoteDisplayDTO"
import AddQuoteCard from "../quotesCard/AddQuoteCard";
import QuoteCard from "../quotesCard/QuoteCard";

interface QuoteDisplayComponentProps{
    quotes: QuoteDisplayDTO[] | null
}

export default function QuoteDisplayComponent({quotes} : QuoteDisplayComponentProps){
    return (
        <div> 
            <div className='card-container'>
                {quotes &&
                    quotes.map( (quote, index) => (
                        <QuoteCard key={index} title={quote.title} shortDescription="desc" />
                    ))
                }
                <AddQuoteCard />
            </div>
        </div>
    );
}