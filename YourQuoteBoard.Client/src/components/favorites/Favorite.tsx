import { useEffect, useState } from "react";
import { deleteFavorite, insertFavorite } from "../../api/favorite";
import { ItemType } from "../../enums/ItemType";
import usePingFavorite from "../../hooks/usePingFavorite";
import { HeartFilled, HeartOutlined } from '@ant-design/icons';

interface FavoriteProps{
    itemId: string;
    itemType: ItemType;
}

export default function Favorite({itemId, itemType}: FavoriteProps){
    const {isFavorite} = usePingFavorite(itemId, itemType);
    const [showFilledHeart, setShowFilledHeart] = useState<boolean>(false);

    useEffect( () => {
        if (isFavorite){
            setShowFilledHeart(true);
        }
    }, [isFavorite]);

    async function handleAddToFavorites(){
        try{
            const response = await insertFavorite(itemId);
            setShowFilledHeart(true);

            console.log("Added to favorites: ", response);
        }catch(error){
            console.log("Failed to add to favorite: ", error);
        }
    }

    async function handleDeleteFavorite(){
        try{
            const response = await deleteFavorite(itemId);
        
            console.log("Deleted from favorites: ", response);
        }catch(error){
            console.log("Failed to delete from favorites: ", error);
        }
    }

    return (
        <>
        {   
            showFilledHeart ? 
                <HeartFilled className="favorite-icon" onClick={handleDeleteFavorite}/>
            :
                <HeartOutlined className="favorite-icon" onClick={handleAddToFavorites}/>
        } 
        </>
    )
}