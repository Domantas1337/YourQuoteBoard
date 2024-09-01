import { useState } from "react";
import { QuoteDisplayDTO } from "../../../models/quotes/QuoteDisplayDTO"
import AddQuoteCard from "../quotesCard/AddQuoteCard";
import QuoteCard from "../quotesCard/QuoteCard";
import ItemManagementModal from "../../basic/ItemManagementModal";
import { getQuoteManagementButtons } from "../../../helpers/button/modalButtonConfig";
import { ButtonConfig } from "../../../types/ButtonConfig";

interface QuoteDisplayComponentProps{
    quotes: QuoteDisplayDTO[] | null;
    allowToAddQuotes: boolean;
}

export default function QuoteDisplayAndAddComponent({quotes, allowToAddQuotes} : QuoteDisplayComponentProps){
    
    const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
    const [managementButtons, setManagementButtons] = useState<ButtonConfig[]>([]);

    async function openModal(id: string){
        setManagementButtons( await getQuoteManagementButtons(['delete'], id) );
        setIsModalOpen(true);
    }

    function closeModal(){
        setIsModalOpen(false);
    }

    return <div> 
            <div className='card-container'>
                <ItemManagementModal buttons={managementButtons} title="Quote information" isOpen={isModalOpen} handleClose={closeModal}/>

                {quotes &&
                    quotes.map( (quote, index) => (
                        <QuoteCard key={index} quoteId={quote.quoteId} 
                            title={quote.title} shortDescription={quote.shortDescription} 
                            averageRating={quote.averageRating} openManagementModal={openModal}/>
                    ))
                } 
                  
                { 
                    allowToAddQuotes === true ? 
                        <AddQuoteCard /> : <></>
                }
                
            </div>
        </div>
    
}