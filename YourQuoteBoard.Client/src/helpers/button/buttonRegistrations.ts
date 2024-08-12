import { deleteSingleQuote } from "../../api/quote";
import {ButtonRegistry} from "./ButtonFactory";

function deleteQuote(quoteId: string){
    if (quoteId){
        deleteSingleQuote(quoteId);
    }   
}

ButtonRegistry.registerButton<string>('delete', (selectedQuoteId) => ({
        label: "Delete quote",
        onClick: deleteQuote,
        data: selectedQuoteId,
        className: "btn btn-default delete-button"
    }
))