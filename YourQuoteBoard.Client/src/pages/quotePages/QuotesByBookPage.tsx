import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import { getQuotesByBookId } from "../../api/quote";
import { QuoteDisplayDTO } from "../../models/quotes/QuoteDisplayDTO";
import QuoteDisplayComponent from "../../components/manageQuotes/mainQuotes/QuoteDisplayComponent";

export default function QuotesByBookPage(){
    const {bookId} = useParams();
    const [bookQuotes, setBookQuotes] = useState<QuoteDisplayDTO[] | null>(null);

    useEffect(() => {
            const getQuotesForBook = async () => {
                try{
                    if (bookId != undefined){
                        const quotes = await getQuotesByBookId(bookId);
                        setBookQuotes(quotes);
                    }
                }catch(error){
                    console.log("Failed to fetch quotes for book with id: ", bookId);
                }
            }
            getQuotesForBook();
        }
    );

    return (
    <>
        <div className="BookTitleHeader">
            <h2>bookId</h2>
        </div>
        <QuoteDisplayComponent quotes={bookQuotes} />
        
    </>
    );
}