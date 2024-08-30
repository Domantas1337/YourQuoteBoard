import { Rate } from "antd";

interface AssignRatingProps{
    rating: number | undefined;
    ratingKey: QuoteRatingCategory | BookRatingCategory;
    handleGivenRating: (value: number, whatIsRated: QuoteRatingCategory | BookRatingCategory) => void;
}

export default function AssignRating({rating, ratingKey, handleGivenRating} : AssignRatingProps){
    
    const label: string = ratingKey.replace(/([A-Z])/g, ' $1') 
                          .replace(/^./, (str: string)  => str.toUpperCase()) 
                          .trim();
    
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