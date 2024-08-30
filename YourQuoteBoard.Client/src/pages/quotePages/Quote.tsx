import { useNavigate, useParams } from "react-router-dom";
import { EllipsisOutlined } from '@ant-design/icons';
import { useState } from "react";
import './quoteStyle.css';
import { Rate } from "antd";
import { addQuoteRating, updateQuoteRating } from "../../api/quoteRating";
import { ItemType } from "../../enums/ItemType";
import Favorite from "../../components/favorites/Favorite";
import useQuoteInfo from "../../hooks/useQuoteInfo";
import RatingModal from "../../components/rating/RatingModal";
import ItemManagementModal from "../../components/basic/ItemManagementModal";
import { ButtonConfig } from "../../types/ButtonConfig";
import { getQuoteManagementButtons } from "../../helpers/button/modalButtonConfig";
import { QuoteRatingCategory } from "../../enums/QuoteRatingCategory";
import { BookRatingCategory } from "../../enums/BookRatingCategory";


export default function Quote(){
    
    const {id} = useParams();
    const {quote, 
           quoteRatingId,
           overallRating, setOverallRating,
           specificRatings, setSpecificRatings,
           } = useQuoteInfo(id || "");
    
    const [isRatingModalOpen, setIsRatingModalOpen] = useState<boolean>(false);
    const [isDetailModalOpen, setIsDetailModalOpen] = useState<boolean>(false);
    const [buttonConfigs, setButtonConfigs] = useState<ButtonConfig[]>([]);

    const navigate = useNavigate();

    const handleBookVisit = (bookId: string) => {
        navigate(`/book/${bookId}`)
    }

    function handleQuoteSave(){
        navigate(`/my-quotes?quoteId=${id}`);
    }

    function handleOverallRating(value: number){
        setOverallRating(value);
        setIsRatingModalOpen(true);
    }


    async function openModal(){
        setButtonConfigs(await getQuoteManagementButtons(['delete'], id));
        setIsDetailModalOpen(true);
    }

    function closeDetailModal(){
        setIsDetailModalOpen(false);
    }

    function handleClose(){
        setIsRatingModalOpen(false);
    }
    
    async function handleSpecificRating(value: number, whatIsBeingRated: QuoteRatingCategory | BookRatingCategory) {
        if (whatIsBeingRated == QuoteRatingCategory.OverallRating){
            setOverallRating(value)
        }
        else{
            setSpecificRatings((prevRatings) => {
                const ratingExists = prevRatings.some(
                    (rating) => rating.ratingCategory === whatIsBeingRated
                );
        
                if (ratingExists) {
                    return prevRatings.map((rating) =>
                        rating.ratingCategory === whatIsBeingRated
                            ? { ...rating, rating: value }
                            : rating
                    );
                } else {
                    return [
                        ...prevRatings,
                        { rating: value, ratingCategory: whatIsBeingRated },
                    ];
                }
            });
        }
    }

    async function hanldeUploadedRating(){
        if (!quoteRatingId && id){
            console.log("not");
            addQuoteRating({overallRating: overallRating, specificRatings: specificRatings, quoteId: id});
        }
        else if (quoteRatingId && id){
            console.log("is");
            updateQuoteRating(
                {
                    overallRating: overallRating, 
                    specificRatings: specificRatings, 
                    quoteId: id, 
                    quoteRatingId: quoteRatingId
                }
            )
        }

        setIsRatingModalOpen(false);
    }
    

    return (
    <div className="quote-page-container">
        <div className="quote-wrapper">
            
            <div className="favorite-container">
                {   id ? 
                        <Favorite itemId={id} itemType={ItemType.Quote} /> 
                       : 
                        <></>
                }

                <EllipsisOutlined className="options-button" onClick={openModal} />
            </div> 

            <ItemManagementModal buttons={buttonConfigs} title="Quote information" isOpen={isDetailModalOpen} handleClose={closeDetailModal}/>

            <div className="main-quote-container">      
                <div className="single-quote-symbol-container">
                    <span className="quote-symbol">"</span>
                </div>
                <div className="quote-container">
                    <p>{quote.title}</p>
                </div>
                <div className="single-quote-symbol-container">
                    <span className="quote-symbol">"</span>
                </div>
            </div>

            <div className="quote-tag-container">
                {
                    quote.tags.map((tag, index) => (
                        <div key={index} className="quote-tag">
                            <span>{tag.name}</span>
                        </div>
                    ))
                }
            </div>

            <RatingModal 
                ratings={specificRatings}
                handleRatingCompletedClick={hanldeUploadedRating}
                itemType={ItemType.Quote}
                handleRatingChange={handleSpecificRating}
                handleClose={handleClose}
                title="Rate the quote content"
                isOpen={isRatingModalOpen}
                />
            <div className="quote-rating-container">
                <h6> Average quote rating:</h6>
                {
                    quote.averageRating ? (
                    <div className="disabled-rating-container">
                    
                        <Rate className="rating-options" disabled value={quote.averageRating}/>
                        <h5>{quote.averageRating}</h5>
                    </div> 
                    ) : (
                        <div className="disabled-rating-container">
                    
                        <Rate className="rating-options" disabled value={0}/>
                        <h5>No rating</h5>
                    </div> 
                    )
                }
            </div>
        </div>

        <div className="user-action-container">
            {
                overallRating ? (
                    <div className="rating-container">       
                        <span className="rating-span">Your rating: {overallRating}</span>       
                        <br />
                        <Rate className="rating-options" allowHalf value={overallRating} onChange={handleOverallRating} />
                    </div>  
                ) : (
                    <div className="rating-container">       
                        <span className="rating-span">Rate this book:</span>       
                        <br />
                        <Rate className="rating-options" allowHalf value={2} onChange={handleOverallRating} />
                    </div> 
                )
            }

            <div className="save-to-folder">
                <button className="save-button" onClick={handleQuoteSave}>Save quote</button>
            </div>
        </div>

        <div className="section-icon section-author">
            <p>Quote author</p>
        </div>
        <div className="quote-author">
            <p>John</p>
        </div>

        <div className="section-icon section-description">
            <span>Desctiprion</span>
        </div>
        <div className="quote-description">
            <span>{quote.description}</span>
        </div>

        <div className="section-icon section-book">
            <span>From Book</span>
        </div>
        <div className="quote-book-container">
            <span className="book-title">{quote.bookTitle}</span>
            <button className="book-button" onClick={() => handleBookVisit(quote.bookId)}>Visit book</button>
        </div>

    </div>
    )
}