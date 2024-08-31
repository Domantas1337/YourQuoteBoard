import { useNavigate, useParams } from "react-router-dom";
import { useState } from "react";
import "./BookStyle.css";
import { Rate } from 'antd';
import { addBookRating, updateBookRating } from "../../api/rating";
import RatingModal from "../../components/rating/RatingModal";
import useBookInfo from "../../hooks/useBookInfo";
import { QuoteRatingCategory } from "../../enums/QuoteRatingCategory";
import { BookRatingCategory } from "../../enums/BookRatingCategory";
import { ItemType } from "../../enums/ItemType";

export default function Book() {
    const { id } = useParams<{ id: string }>();
    const navigate = useNavigate();

    const { book, 
            bookRatingId, setBookRatingId, 
            overallRating, setOverallRating,
            specificRatings, setSpecificRatings    
        } = useBookInfo(id || ""); 

    console.log("overallRating");
    console.log(overallRating);
    const [isRatingModalOpen, setIsRatingModalOpen] = useState<boolean>(false);

    const handleQuoteViewing = () => {
        navigate(`/book-quotes/${id}`, { 
            state: { book: book }
        });
    };

    const handleOverallRating = (value: number) => {
        setOverallRating(value);
        setIsRatingModalOpen(true);
    }

    const handleSpecificRating = (value: number, whatIsBeingRated: QuoteRatingCategory | BookRatingCategory) => {
        if (whatIsBeingRated === BookRatingCategory.OverallRating) {
            setOverallRating(value);
        } else {
            setSpecificRatings(prevRatings => {
                const existingRatingIndex = prevRatings.findIndex(rating => rating.ratingCategory === whatIsBeingRated);
                if (existingRatingIndex !== -1) {
                    return prevRatings.map((rating, index) =>
                        index === existingRatingIndex ? { ...rating, rating: value } : rating
                    );
                }
                return [...prevRatings, { rating: value, ratingCategory: whatIsBeingRated }];
            });
        }
    };

    const handleClose = () => setIsRatingModalOpen(false);

    async function handleUploadedRating(){
        if (!bookRatingId && id ){
            const newBookRatingId = await addBookRating({overallRating: overallRating, specificRatings: specificRatings, bookId: id});
            setBookRatingId(newBookRatingId);
        }
        else if (bookRatingId && id){
            await updateBookRating(
                {
                    overallRating: overallRating, 
                    specificRatings: specificRatings, 
                    bookId: id, 
                    bookRatingId: bookRatingId
                }
            )
        }
        setIsRatingModalOpen(false);
    }

    return (
        <>
        <div className="book-detail-container">
            <div className="book-header">
                <h2 className="book-title">{book?.title}</h2>
            </div>
            <div className="book-main">
                <div className="book-info-wrapper">
                    <div className="book-cover-container">
                        <img src={book?.coverImagePath} alt={book?.title} className="book-cover-image" />
                    </div>
                    <div className="book-info-container">
                        <p className="book-author">By {book?.author}</p>
                        <h6>Readers of the book have given it this rating:</h6>
                        
                        <RatingModal 
                            ratings={specificRatings}
                            handleRatingCompletedClick={handleUploadedRating}
                            itemType={ItemType.Book}
                            handleRatingChange={handleSpecificRating}
                            handleClose={handleClose}
                            title="Rate the quote content"
                            isOpen={isRatingModalOpen}
                            />

                        {
                            book?.averageRating ? (
                                <div className="disabled-rating-container">
                                    <Rate disabled value={book!.averageRating}/>
                                    <h5>{book!.averageRating}</h5>
                                </div>
                            ) : (
                                <div className="disabled-rating-container">
                                    <Rate disabled value={0}/>
                                    <h5>No rating</h5>
                                </div>
                            )
                        }
                    </div>
                </div>
                <div className="book-tag-container">
                {
                    book?.tags.map((tag, index) => (
                        <div key={index} className="book-tag">
                            <span>{tag.name}</span>
                        </div>
                    ))
                }
                </div>
            </div>
            <div className="book-actions-container">
                <button className="action-button" onClick={handleQuoteViewing}>Browse all quotes from this book</button>
                <button className="action-button quote">I found a quote in this book!</button>
                
                {
                overallRating ? (
                    <div className="book-rating-container">       
                        <span className="book-rating-span">Your rating: {overallRating}</span>       
                        <br />
                        <Rate allowHalf value={overallRating} onChange={handleOverallRating} />
                    </div>  
                ) : (
                    <div className="book-rating-container">       
                        <span className="book-rating-span">Rate this book:</span>       
                        <br />
                        <Rate allowHalf value={2} onChange={handleOverallRating} />
                    </div> 
                )
                }

            </div>

        </div>

        </>
    );
}
