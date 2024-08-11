import { useState } from "react";
import { QuoteDisplayDTO } from "../../../models/quotes/QuoteDisplayDTO"
import useQuoteTools from "../hooks/useQuoteTools";
import AddQuoteCard from "../quotesCard/AddQuoteCard";
import QuoteCard from "../quotesCard/QuoteCard";
import ItemManagementModal, { ButtonConfig } from "../../basic/ItemManagementModal";

interface QuoteDisplayComponentProps{
    quotes: QuoteDisplayDTO[] | null;
    allowToAddQuotes: boolean;
    allowToDeleteQuotes: boolean;
}

export default function QuoteDisplayAndAddComponent({quotes, allowToAddQuotes, allowToDeleteQuotes} : QuoteDisplayComponentProps){
    
    const {deleteQuote} = useQuoteTools();
    const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
    const [selectedQuoteId, setSelectedQuoteId] = useState<string>("");

    function openModal(id: string){
        setSelectedQuoteId(id);
        setIsModalOpen(true);
    }

    function closeModal(){
        setSelectedQuoteId("");
        setIsModalOpen(false);
    }

    const buttons : ButtonConfig<string>[] = [
        
        ...(allowToDeleteQuotes ? 
            [
                {
                    label: "Delete quote",
                    onClick: deleteQuote,
                    data: selectedQuoteId,
                    className: "btn btn-default delete-button"
                }
            ] : []
        )
    ]

    return <div> 
            <div className='card-container'>
                <ItemManagementModal buttons={buttons} title="Quote information" isOpen={isModalOpen} handleClose={closeModal}/>

                {quotes &&
                    quotes.map( (quote, index) => (
                        <QuoteCard key={index} quoteId={quote.quoteId} 
                            title={quote.title} shortDescription="description" 
                            openManagementModal={openModal}/>
                    ))
                } 
                  
                { 
                    allowToAddQuotes === true ? 
                        <AddQuoteCard /> : <></>
                }
                
            </div>
        </div>
    
}