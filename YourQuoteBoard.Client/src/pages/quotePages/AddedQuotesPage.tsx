import NumberOfItems from "../../components/basic/NumberOfItems";
import Title from "../../components/basic/Title";
import useQuotesGetter from "../../components/manageQuotes/hooks/useQuotesGetter";
import QuoteDisplayComponent from "../../components/manageQuotes/mainQuotes/QuoteDisplayComponent";

export default function AddedQuotesPage(){
    const {quotes} = useQuotesGetter("personal");
     
    return (
        <>
            <Title title="Your added quotes" />
            <NumberOfItems itemName="quote" listLength={quotes.length}/>
            <QuoteDisplayComponent quotes={quotes} allowToAddQuotes={true}/>
        </>
    );
}
