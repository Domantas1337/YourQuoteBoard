import { useParams } from "react-router-dom";
import { QuoteFullDisplayDTO } from "../../models/quotes/QuoteFullDisplayDTO"
import { useEffect, useState } from "react";
import { getQuoteForDesignatedPage } from "../../api/quote";
import './quote.css';

export default function Quote(){
    const [quote, setQuote] = useState<QuoteFullDisplayDTO | null>(null);
    const {id} = useParams();
   
    useEffect(() => {
        const fetchQuote = async () => {
            try {
                if (id){
                    const fetchedQuote = await getQuoteForDesignatedPage(id);
                    setQuote(fetchedQuote);
                }
            }catch(excepiton){
                console.log("Exception while fetching the quote: ", excepiton);
            }
        }
        fetchQuote();
    }, [id]);
    
    return (
    <div className="quote-wrapper">
        <div className="single-quote-symbol-container">
            <span className="quote-symbol">"</span>
        </div>
        <div className="quote-container">
            <p>{quote?.title}</p>
        </div>
        <div className="single-quote-symbol-container">
            <span className="quote-symbol">"</span>
        </div>
    </div>
    )
}