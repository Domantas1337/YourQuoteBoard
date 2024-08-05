import { QuoteDisplayDTO } from "../../../models/quotes/QuoteDisplayDTO"
import AddQuoteCard from "../quotesCard/AddQuoteCard";
import QuoteCard from "../quotesCard/QuoteCard";

interface MapAndAddQuotesProps{
    quotes: QuoteDisplayDTO[] | null;
    allowToAddQuotes: boolean;
}

export default function MapAndAddQuotesProps({quotes, allowToAddQuotes} : MapAndAddQuotesProps){

    return <>
           <div className='card-container'>
                {
                 quotes &&
                    quotes.map( (quote, index) => (
                        <QuoteCard key={index} quoteId={quote.quoteId} title={quote.title} shortDescription="desc" />
                    ))
                }
                {
                    allowToAddQuotes === true ? 
                        <AddQuoteCard />
                        :
                        <></>
                }
            </div>
            </>
}