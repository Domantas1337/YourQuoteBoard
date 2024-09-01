import { useEffect, useState } from "react";
import QuoteDisplayAndAddComponent from "../../components/manageQuotes/mainQuotes/QuoteDisplayAndAddComponent";
import { QuoteDisplayDTO } from "../../models/quotes/QuoteDisplayDTO";
import { getAllFavoritesByUserId } from "../../api/favorite";
import Title from "../../components/basic/Title";
import NumberOfItems from "../../components/basic/NumberOfItems";

export default function FavoriteQuotePage(){
    const [favorites, setFavorites] = useState<QuoteDisplayDTO[]>([]);

    useEffect(
        () => {
            const fetchQuotes = async () =>{
                try {
                    const quotes = await getAllFavoritesByUserId();
                    setFavorites(quotes);
                    console.log(quotes.length);
                }catch (error){
                    console.log("Failed to fetch favorites: ", error);
                }
            }
            fetchQuotes();
        }, []
    );
    return <>
                <Title title="Your favorite quotes" />
                <NumberOfItems itemName="favorite" listLength={favorites.length}/>
                <QuoteDisplayAndAddComponent quotes={favorites} allowToAddQuotes={false}/>
           </>
}