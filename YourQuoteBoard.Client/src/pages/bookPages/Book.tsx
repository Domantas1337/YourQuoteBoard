import { useNavigate, useParams } from "react-router-dom";
import { useState } from "react";
import "./BookStyle.css";
import { Rate } from 'antd';
import { addBookRating, updateBookRating } from "../../api/rating";
import { BookRating } from "../../models/rating/BookRating";
import RatingModal from "../../components/rating/RatingModal";
import useBookInfo from "../../hooks/useBookInfo";



export default function Book() {
    const { id } = useParams<{ id: string }>();
    const navigate = useNavigate();

    const {book, bookRatingId, bookRatingCategories, bookRating, setBookRating, setBookRatingCategores} = useBookInfo(id || ""); 
    const [bookRatingForManaging, setBookRatingForManaging] = useState<BookRating>(bookRating || {
        overallRating: undefined,
        plotRating: undefined,
        accuracyRating: undefined,
        writingStyleRating: undefined,
        worldBuildingRating: undefined,
        characterDevelopmentRating: undefined
    });

    const [isModalOpen, setIsModalOpen] = useState<boolean>(false);

    const handleQuoteViewing = () => {
        navigate(`/book-quotes/${id}`, { 
            state: { book: book }
        });
    };

    const handleRatingChange = (value: number) => {     
        setBookRatingForManaging(prevRating => ({
            ...prevRating,
            overallRating: value
        }));

        const updatedCategories = bookRatingCategories.map(category =>
            category.key === "overallRating" ? { ...category, value: value } : category
        );
        setBookRatingCategores(updatedCategories);

        setIsModalOpen(true);
    }
    function handleSpecificRating(value: number, whatIsRated: string){
        setBookRatingForManaging(prev => ({
            ...prev,
            [whatIsRated]: value
        }));

        const updatedCategories = bookRatingCategories.map(category =>
            category.key === whatIsRated ? { ...category, value: value } : category
        );

        console.log("first");
        console.log(bookRatingCategories);
        setBookRatingCategores(updatedCategories);
        console.log("second");
        console.log(bookRatingCategories);
    }

    const handleClose = () => setIsModalOpen(false);

    const handleSetRating = async () => {
        if (bookRatingId && bookRating ){  
            if (id){
                await updateBookRating({bookRatingId: bookRatingId, bookId: id, newRating: bookRatingForManaging, currentRating: bookRating});
                setBookRating(bookRating);
            }
        }else{
            if (id){
                const response = await addBookRating({bookId: id, bookRating: bookRatingForManaging});
                const bookRatingdto = response.data;

                console.log("Book rating added: ", bookRatingdto)
            }
        }
        setIsModalOpen(false);
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
                        
                        <RatingModal isOpen={isModalOpen} 
                                     title="Rate the book"
                                     handleSetRating={handleSetRating} 
                                     handleRatingChange={handleSpecificRating}
                                     categories={bookRatingCategories}
                                     handleClose={handleClose}/>

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
                bookRating ? (
                    <div className="book-rating-container">       
                        <span className="book-rating-span">Your rating: {bookRating.overallRating}</span>       
                        <br />
                        <Rate allowHalf value={bookRating.overallRating} onChange={handleRatingChange} />
                    </div>  
                ) : (
                    <div className="book-rating-container">       
                        <span className="book-rating-span">Rate this book:</span>       
                        <br />
                        <Rate allowHalf value={2} onChange={handleRatingChange} />
                    </div> 
                )
                }

            </div>

        </div>

        </>
    );
}
