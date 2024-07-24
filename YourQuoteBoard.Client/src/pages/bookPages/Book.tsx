import { useNavigate, useParams } from "react-router-dom";
import BookDisplayDTO from "../../models/books/BookDisplayDTO";
import { useEffect, useState } from "react";
import { getBookById } from "../../api/book";
import "./BookStyle.css";
import { Rate } from 'antd';
import { addBookRating, getUserBookRating, updateBookRating } from "../../api/rating";
import BookRatingForDirectUserInteractionDTO from "../../models/rating/BookRatingForDirectUserInteractionDTO";

interface bookInfo{
    currentBook: BookDisplayDTO;
    bookRating: BookRatingForDirectUserInteractionDTO | null;
}

export default function Book() {
    const { id } = useParams();
    const navigate = useNavigate();

    const [bookToDisplay, setBookToDisplay] = useState<bookInfo | null>(null);

    useEffect(() => {
        const fetchBookInfo = async () => {
            try {
                if (id != undefined) {
                    const book = await getBookById(id);
                    const rating = await getUserBookRating(id);

                    setBookToDisplay({currentBook: book, bookRating:  rating});
                }
            }catch (error) {
                console.log("Error while fetching the book ", error);
            }
        };
        fetchBookInfo();
    }, [id]);

    const handleQuoteViewing = () => {
        navigate(`bookQuotes/${id}`)
    };

    const handleGivenRating = async (value: number) => {
        if (bookToDisplay?.bookRating && id) {
            
            const { bookRatingId } = bookToDisplay.bookRating;
            
            if (bookRatingId) {
                await updateBookRating({bookRatingId, bookId: id, previousRating: bookToDisplay.bookRating.overallRating, newRating: value});
                setBookToDisplay({currentBook: bookToDisplay?.currentBook, bookRating: {bookRatingId, bookId: id, overallRating: value}});
            } else {
                const response = await addBookRating({bookId: id, overallRating: value});
                const bookRatingdto = response.data;

                setBookToDisplay({currentBook: bookToDisplay?.currentBook, bookRating: bookRatingdto})
            }
        } else {
            if (id && bookToDisplay) {
                const response = await addBookRating({bookId: id, overallRating: value});
                const bookRatingdto = response.data;

                setBookToDisplay({currentBook: bookToDisplay?.currentBook, bookRating: bookRatingdto})
            } else {
                console.log("Failed to process rating: No book ID found.");
            }
        }
    }
    

    return (
        <>
        <div className="book-detail-container">
            <div className="book-header">
                <h2 className="book-title">{bookToDisplay?.currentBook.title}</h2>
            </div>
            <div className="book-main">
    <div className="book-info-wrapper">
        <div className="book-cover-container">
            <img src={bookToDisplay?.currentBook.coverImagePath} alt={bookToDisplay?.currentBook.title} className="book-cover-image" />
        </div>
        <div className="book-info-container">
            <p className="book-author">By {bookToDisplay?.currentBook.author}</p>
            <h6>Readers of the book have given it this rating:</h6>
            {
                bookToDisplay?.currentBook.averageRating ? (
                    <div className="disabled-rating-container">
                        <Rate disabled value={bookToDisplay!.currentBook!.averageRating}/>
                        <h5>{bookToDisplay!.currentBook!.averageRating}</h5>
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
            bookToDisplay?.currentBook.tags.map((tag, index) => (
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
                bookToDisplay?.bookRating?.overallRating ? (
                    <div className="book-rating-container">       
                        <span className="book-rating-span">Your rating: {bookToDisplay?.bookRating.overallRating}</span>       
                        <br />
                        <Rate allowHalf value={bookToDisplay?.bookRating.overallRating} onChange={handleGivenRating} />
                    </div>  
                ) : (
                    <div className="book-rating-container">       
                        <span className="book-rating-span">Rate this book:</span>       
                        <br />
                        <Rate allowHalf value={2} onChange={handleGivenRating} />
                    </div> 
                )
                }

            </div>

        </div>

        </>
    );
}
