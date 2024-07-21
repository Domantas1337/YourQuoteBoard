import { useNavigate, useParams } from "react-router-dom";
import { QuoteFullDisplayDTO } from "../../models/quotes/QuoteFullDisplayDTO"
import { useEffect, useState } from "react";
import { getQuoteForDesignatedPage } from "../../api/quote";
import './quoteStyle.css';
import { Rate } from "antd";

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
    <div className="quote-page-container">
        <div className="quote-wrapper">
            
            <div className="main-quote-container">
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
            <div className="quote-rating-container">
                <h6>Readers of the book have given it this rating:</h6>
                <div className="disabled-rating-container">
                    <Rate disabled defaultValue={2}/>
                    <h5>2</h5>
                </div>
            </div>
        </div>

        <div className="user-rating-container">
            <h6>Your rating:</h6>
            <Rate allowHalf defaultValue={0} />
        </div>

        <div className="section-icon section-author">
            <p>Quote author</p>
        </div>
        <div className="quote-author">
            <p>John</p>
        </div>

        <div className="section-icon section-description">
            <span>Desctiprion</span>
        </div>
        <div className="quote-description">
            <span>{quote?.description}</span>
        </div>

        <div className="section-icon section-book">
            <span>From Book</span>
        </div>
        <div className="quote-book-container">
            <span className="book-title">{quote?.bookTitle}</span>
            <button className="book-button" onClick={() => handleBookVisit(quote!.bookId)}>Visit book</button>
        </div>

    </div>
    )
}