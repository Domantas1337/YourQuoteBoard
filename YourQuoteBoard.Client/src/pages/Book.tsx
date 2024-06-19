import { useParams } from "react-router-dom"
import BookDisplayDTO from "../models/books/BookDisplayDTO";
import { useEffect, useState } from "react";
import { getBookById } from "../api/book";

export default function Book(){
    const {id} = useParams();

    const [bookToDisplay, setBookToDisplay] = useState<BookDisplayDTO | null>(null);

    console.log("Ttiel");
    console.log(bookToDisplay?.title);
    useEffect(() => {
        const fetchBook = async () => {
            try{
                if (id != undefined){
                    const book = await getBookById(id);
                    setBookToDisplay(book);
                }
            }catch(error){
                console.log("Error while fetching the book ", error);
            }
        }
        fetchBook();
    }, [id]);

    return (
        <div>
            {bookToDisplay ? (
                <h1>{bookToDisplay.title}</h1>
            ) : (
                <p>Loading...</p>
            )}
        </div>
    );
}