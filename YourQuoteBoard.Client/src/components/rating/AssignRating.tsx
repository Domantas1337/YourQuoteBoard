import { Rate } from "antd";

interface AssignRatingProps{
    rating: number | undefined;
    label: string;
    ratingKey: string;
    handleGivenRating: (value: number, whatIsRated: string) => void;
}

export default function AssignRating({rating, label, ratingKey, handleGivenRating} : AssignRatingProps){
    return <>
    {
        rating ? (
            <div className="rating-container">       
                <span className="rating-span">Your {label} rating: {rating}</span>       
                <br />
                <Rate className="rating-options" allowHalf value={rating} onChange={(value) => handleGivenRating(value, ratingKey)} />
            </div>  
        ) : (
            <div className="rating-container">       
                <span className="rating-span">{label}:</span>       
                <br />
                <Rate className="rating-options" allowHalf value={2} onChange={(value) => handleGivenRating(value, ratingKey)} />
            </div> 
        )
    }
    </>
}