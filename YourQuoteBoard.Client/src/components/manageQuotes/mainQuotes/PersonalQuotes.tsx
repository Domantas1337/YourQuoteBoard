import QuoteDisplayComponent from "./QuoteDisplayComponent";
import useQuotesGetter from "../hooks/useQuotesGetter";

export default function PersonalQuotes(){
    const {quotes} = useQuotesGetter("personal");
     
    return (
        <QuoteDisplayComponent quotes={quotes} />
    );
}
