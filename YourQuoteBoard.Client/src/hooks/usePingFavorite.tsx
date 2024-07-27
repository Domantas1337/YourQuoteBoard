import { useEffect, useState } from "react";
import { ItemType } from "../enums/ItemType";
import { pingFavorite } from "../api/favorite";


export default function usePingFavorite(itemId: string | undefined, itemType: ItemType){

    const [isFavorite, setIsFavorite] = useState<boolean>();

    useEffect( () => {
        const fetchIsFavorite = async () =>{
            if (itemId){
                try{
                    const fetchedIsFavorite = await pingFavorite(itemId, itemType);
                    setIsFavorite(fetchedIsFavorite);
                }catch(error){
                    console.log("Failed to check if the item is a favorite: ", error);
                }
            }
        }

        fetchIsFavorite();
    }, [itemId, itemType]);

    return {isFavorite};
}