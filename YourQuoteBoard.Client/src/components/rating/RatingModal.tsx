import { Modal } from "antd";
import AssignRating from "./AssignRating";
import { RatingCategory } from "../../models/rating/RatingCategory";

interface RatingModalProps{
    isOpen: boolean;
    title: string;
    handleClose: () => void;
    handleSetRating: () => void; 
    handleRatingChange: (value: number, whatIsBeingRated: string) => void;
    categories: RatingCategory[];
}

export default function RatingModal({isOpen, title, handleClose,  handleSetRating, handleRatingChange, categories} : RatingModalProps){
    return <Modal title={title} open={isOpen} onOk={handleSetRating} onCancel={handleClose}>
                {
                    categories.map( (category, key)  => 
                        <AssignRating key={key} handleGivenRating={handleRatingChange} rating={category.value} label={category.label} ratingKey={category.key} />
                    )
                }
           </Modal>
}