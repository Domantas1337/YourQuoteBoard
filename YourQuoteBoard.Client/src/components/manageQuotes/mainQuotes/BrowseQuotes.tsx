import QupteDisplayAndAddCpmponent from "./QuoteDisplayAndAddComponent";
import useQuotesGetter from "../hooks/useQuotesGetter";

function BrowseQuotes(){
    
    const {quotes} = useQuotesGetter();

    return (
        <QupteDisplayAndAddCpmponent quotes={quotes} allowToAddQuotes={false}/>
    );
}

export default BrowseQuotes;