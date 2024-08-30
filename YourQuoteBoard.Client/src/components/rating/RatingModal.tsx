import { Modal } from "antd";
import AssignRating from "./AssignRating";
import { SpecificRating } from "../../models/rating/SpecificRating";
import { ItemType } from "../../enums/ItemType";
import { QuoteRatingCategory } from "../../enums/QuoteRatingCategory";
import { BookRatingCategory } from "../../enums/BookRatingCategory";

interface RatingModalProps{
    ratings: SpecificRating[];
    itemType: ItemType;
    isOpen: boolean;
    title: string;
    handleClose: () => void;
    handleRatingCompletedClick: () => void; 
    handleRatingChange: (value: number, whatIsBeingRated: QuoteRatingCategory | BookRatingCategory) => void;
}


export default function RatingModal({ratings, itemType, isOpen, title, handleClose,  handleRatingCompletedClick, handleRatingChange} : RatingModalProps){

    const ratingCategoeies = itemType == ItemType.Quote ? Object.values(QuoteRatingCategory) : Object.values(BookRatingCategory);

    return  <Modal title={title} open={isOpen} onOk={handleRatingCompletedClick} onCancel={handleClose}>                            
                {
                    ratingCategoeies.map( (ratingCategory, key)  => 
                        <AssignRating 
                        key={key} 
                        handleGivenRating={handleRatingChange} 
                        rating={
                            ratings?.find(
                                (rating) => rating.ratingCategory === ratingCategory  
                            )?.rating || undefined   
                        } 
                        ratingKey={ratingCategory} />
                    )
                }
            </Modal>
}