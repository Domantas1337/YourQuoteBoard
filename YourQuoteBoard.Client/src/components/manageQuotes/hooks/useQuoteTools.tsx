import { deleteSingleQuote } from "../../../api/quote";

export default function useQuoteTools(){

    function deleteQuote(id: string){
        if (id){
            deleteSingleQuote(id);
        }
    }

    return {deleteQuote};
}