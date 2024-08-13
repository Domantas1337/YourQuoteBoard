import { QuoteDisplayDTO } from "../../../models/quotes/QuoteDisplayDTO";
import NumberOfItems from "../../basic/NumberOfItems";
import Title from "../../basic/Title";
import QuoteCard from "../quotesCard/QuoteCard";

interface FolderContentProps{
    title: string;
    numberOfItems: number;
    quotes: QuoteDisplayDTO[];
}

export default function FolderContent({title, numberOfItems, quotes}  : FolderContentProps){
    return (
        <div className="folder-content-container">     
            <Title title={title}/>   
            <NumberOfItems itemName="quote" listLength={numberOfItems} />       
            <div className="cards-container">
                {
                    quotes.map((quote, index) => (
                        <QuoteCard key={index} title={quote.title} averageRating={quote.averageRating} shortDescription={quote.shortDescription} quoteId={quote.quoteId} />
                    ))
                }
            </div>
        </div>
    ); 
}