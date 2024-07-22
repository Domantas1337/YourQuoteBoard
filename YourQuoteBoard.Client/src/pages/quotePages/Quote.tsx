import { useNavigate, useParams } from "react-router-dom";
import { QuoteFullDisplayDTO } from "../../models/quotes/QuoteFullDisplayDTO"
import { useEffect, useState } from "react";
import { getQuoteForDesignatedPage } from "../../api/quote";
import './quoteStyle.css';
import { Rate } from "antd";
import { QuoteRatingForDirectUserInteractionDTO } from "../../models/rating/quote/QuoteRatingForDirectUserInteractionDTO";
import { addQuoteRating, getUserQuoteRating, updateQuoteRating } from "../../api/quoteRating";

interface QuoteInfo{
    currentQuote: QuoteFullDisplayDTO;
    quoteRating: QuoteRatingForDirectUserInteractionDTO | null;
}

export default function Quote(){
    
    const [quote, setQuote] = useState<QuoteInfo | null>(null);
    const {id} = useParams();
    const navigate = useNavigate();

    console.log(quote?.currentQuote.title);

    useEffect(() => {
        const fetchQuote = async () => {
            try {
                if (id){
                    const fetchedQuote = await getQuoteForDesignatedPage(id);
                    const rating = await getUserQuoteRating(id);
                    console.log("Is it");
                    console.log(fetchedQuote?.averageRating);

                    setQuote({currentQuote: fetchedQuote, quoteRating: rating});
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

    const handleGivenRating = async (value: number) => {
        if (quote?.quoteRating && id) {
            
            const { quoteRatingId } = quote.quoteRating;
            
            if (quoteRatingId) {
                console.log()
                await updateQuoteRating({quoteRatingId, quoteId: id, previousRating: quote.quoteRating.overallRating, newRating: value});
                setQuote({currentQuote: quote?.currentQuote, quoteRating: {quoteRatingId: quoteRatingId, quoteId: id, overallRating: value}});
                console.log("Updated existing quote rating.");
            } else {
                const response = await addQuoteRating({quoteId: id, overallRating: value});
                const quoteRating = response.data;

                setQuote({currentQuote: quote?.currentQuote, quoteRating: quoteRating})
                console.log("Added new quote rating.");
            }
        } else {
            if (id && quote) {
                const response = await addQuoteRating({quoteId: id, overallRating: value});
                const quoteRating = response.data;

                setQuote({currentQuote: quote?.currentQuote, quoteRating: quoteRating})
                console.log("Added new quote rating as no existing rating was found.");
            } else {
                console.log("Failed to process rating: No quote ID found.");
            }
        }
    }

    return (
    <div className="quote-page-container">
        <div className="quote-wrapper">
            
            <div className="main-quote-container">
                <div className="single-quote-symbol-container">
                    <span className="quote-symbol">"</span>
                </div>
                <div className="quote-container">
                    <p>{quote?.currentQuote.title}</p>
                </div>
                <div className="single-quote-symbol-container">
                    <span className="quote-symbol">"</span>
                </div>
            </div>
            <div className="quote-rating-container">
                <h6> Average quote rating:</h6>
                {
                    quote?.currentQuote?.averageRating ? (
                    <div className="disabled-rating-container">
                    
                        <Rate disabled value={quote!.currentQuote!.averageRating}/>
                        <h5>{quote!.currentQuote!.averageRating}</h5>
                    </div> 
                    ) : (
                        <div className="disabled-rating-container">
                    
                        <Rate disabled value={0}/>
                        <h5>No rating</h5>
                    </div> 
                    )
                }
            </div>
        </div>

        <div className="user-rating-container">
            {
                quote?.quoteRating?.overallRating ? (
                    <div className="rating-container">       
                        <span className="rating-span">Your rating: {quote?.quoteRating.overallRating}</span>       
                        <br />
                        <Rate allowHalf value={quote?.quoteRating.overallRating} onChange={handleGivenRating} />
                    </div>  
                ) : (
                    <div className="rating-container">       
                        <span className="rating-span">Rate this book:</span>       
                        <br />
                        <Rate allowHalf value={2} onChange={handleGivenRating} />
                    </div> 
                )
                }
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
            <span>{quote?.currentQuote.description}</span>
        </div>

        <div className="section-icon section-book">
            <span>From Book</span>
        </div>
        <div className="quote-book-container">
            <span className="book-title">{quote?.currentQuote.bookTitle}</span>
            <button className="book-button" onClick={() => handleBookVisit(quote!.currentQuote.bookId)}>Visit book</button>
        </div>

    </div>
    )
}