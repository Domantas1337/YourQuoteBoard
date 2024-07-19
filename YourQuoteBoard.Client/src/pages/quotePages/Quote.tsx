import { useNavigate, useParams } from "react-router-dom";
import { QuoteFullDisplayDTO } from "../../models/quotes/QuoteFullDisplayDTO"
import { useEffect, useState } from "react";
import { getQuoteForDesignatedPage } from "../../api/quote";
import './quoteStyle.css';

export default function Quote(){
    const [quote, setQuote] = useState<QuoteFullDisplayDTO | null>(null);
    const {id} = useParams();
    const navigate = useNavigate();

    console.log(quote?.title);

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
    
    const handleBookVisit = (bookId: string) => {
        navigate(`/book/${bookId}`)
    }

    return (
    <div className="quote-detail-container">
        <div className="quote-wrapper">
            <div className="single-quote-symbol-container">
                <span className="quote-symbol">"</span>
            </div>
            <div className="quote-container">
                <p>This </p>
            </div>
            <div className="single-quote-symbol-container">
                <span className="quote-symbol">"</span>
            </div>
        </div>
        <div className="quote-book-container">
            <p className="book-title">{quote?.bookTitle}</p>
            <button className="book-button" onClick={() => handleBookVisit(quote!.bookId)}>Visit book</button>
        </div>
        <div className="quote-description">
            <p>{quote?.description}</p>
        </div>
    </div>
    )
}