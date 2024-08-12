import { deleteSingleQuote, pingQuoteOwner } from "../api/quote";
import { ButtonConfig } from "../types/ButtonConfig";


export async function getQuoteManagementButtons(quoteId: string){

    const buttonArray: ButtonConfig[] = [];

    const isQuoteUsers: boolean = await pingQuoteOwner(quoteId);
    
    if (isQuoteUsers){
        buttonArray.push(deleteButtonConfig(quoteId));
    }

    return buttonArray;
}

const deleteQuote = (id: string) => {
    if (id){
        deleteSingleQuote(id);
    }
};

export const deleteButtonConfig = (selectedQuoteId: string): ButtonConfig => ({
        label: "Delete quote",
        onClick: deleteQuote,
        data: selectedQuoteId,
        className: "btn btn-default delete-button"
    });