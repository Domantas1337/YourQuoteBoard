import { useEffect, useState } from "react";
import { useLocation, useParams } from "react-router-dom"
import { getQuotesByBookId } from "../../../api/quote";
import { QuoteDisplayDTO } from "../../../models/quotes/QuoteDisplayDTO";
import QuoteDisplayComponent from "../../../components/manageQuotes/mainQuotes/QuoteDisplayAndAddComponent";
import "./quotes_by_book.css"

export default function QuotesByBookPage(){
    
    const {id} = useParams();
    const location = useLocation();
    const book = location.state?.book;
    const [bookQuotes, setBookQuotes] = useState<QuoteDisplayDTO[] | null>(null);

    console.log(book);
    console.log("ka");
    useEffect(() => {
            const getQuotesForBook = async () => {
                try{
                    if (id != undefined){
                        const quotes = await getQuotesByBookId(id);
                        setBookQuotes(quotes);
                    }
                }catch(error){
                    console.log("Failed to fetch quotes for book with id: ", id);
                }
            }
            getQuotesForBook();
        }, [id]
    );

    return (
    <div className="book-quotes-page">
        <div className="book-info-section">
            <div className="book-title-header">
                <h2>{book.title}</h2>
            </div>
            <div className="book-cover-image-container">
                <img className="cover-image" src={book.coverImagePath} alt={book.Title}/>
            </div>
            <div className="book-info-container">
                <span className="quote-count">There are <strong>{bookQuotes?.length}</strong> quotes assigned to this book</span>     
            </div>
        </div>
        <div className="quotes-section">
            <QuoteDisplayComponent quotes={bookQuotes} allowToAddQuotes={false}/>
        </div>
    </div>
    );
}