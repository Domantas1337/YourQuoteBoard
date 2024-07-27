import { useEffect, useState } from "react";
import { getAllFavoritesByUserId } from "../api/favorite";

export default function useFavorites(){
    const [favoriteQuotes, setFavoriteQuotes] = useState<string[]>([]);

    useEffect( () => {
        const fetchFavoriteQuotes = async () => {
            try{
                const fetchedQuotes = await getAllFavoritesByUserId();
            
                setFavoriteQuotes(fetchedQuotes);
            }catch(error){
                console.log("Failed to fetch favorite quotes: ", error);
            }
        }

        fetchFavoriteQuotes();
    }, []);

    return {favoriteQuotes}
}