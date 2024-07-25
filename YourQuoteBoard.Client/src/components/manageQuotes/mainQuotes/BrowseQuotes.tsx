import QuoteDisplayComponent from "./QuoteDisplayComponent";
import useQuotesGetter from "../hooks/useQuotesGetter";

function BrowseQuotes(){
    
    const {quotes} = useQuotesGetter();


    return (
        <QuoteDisplayComponent quotes={quotes} />
    );
}

export default BrowseQuotes;