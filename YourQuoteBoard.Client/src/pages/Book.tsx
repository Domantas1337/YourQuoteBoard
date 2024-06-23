import { useNavigate, useParams } from "react-router-dom";
import BookDisplayDTO from "../models/books/BookDisplayDTO";
import { useEffect, useState } from "react";
import { getBookById } from "../api/book";
import "./BookStyle.css";
import { Rate } from 'antd';

export default function Book() {
    const { id } = useParams();
    const navigate = useNavigate();

    const [bookToDisplay, setBookToDisplay] = useState<BookDisplayDTO | null>(null);

    useEffect(() => {
        const fetchBook = async () => {
            try {
                if (id != undefined) {
                    const book = await getBookById(id);
                    setBookToDisplay(book);
                }
            } catch (error) {
                console.log("Error while fetching the book ", error);
            }
        };
        fetchBook();
    }, [id]);

    const handleQuoteViewing = () => {
        navigate(`bookQuotes/${id}`)
    };

    return (
        <>
        <div className="book-detail-container">
            <div className="book-header">
                <h2 className="book-title">{bookToDisplay?.title}</h2>
            </div>
            <div className="book-main">
                <div className="book-cover-container">
                    <img src={bookToDisplay?.coverImagePath} alt={bookToDisplay?.title} className="book-cover-image" />
                </div>
                <div className="book-info-container">
                    <p className="book-author">By {bookToDisplay?.author}</p>
                    <h6>Readers of the book have given it this rating:</h6>
                    <h6>Readers of the book have given it this rating:</h6>
                    <div className="disabled-rating-container">
                        <Rate disabled defaultValue={2} />
                        <h5>2</h5>
                    </div>
                </div>
            </div>
            <div className="book-actions-container">
                <button className="action-button" onClick={handleQuoteViewing}>Browse all quotes from this book</button>
                <button className="action-button quote">I found a quote in this book!</button>
                
                <div className="book-rating-container">       
                    <span className="book-rating-span">Rate this book:</span>       
                    <br />
                    <Rate allowHalf defaultValue={2.5} />
                </div>  
            </div>

        </div>

        </>
    );
}
