import { useEffect, useState } from "react";
import BookDisplayDTO from "../models/books/BookDisplayDTO";
import { getBookById } from "../api/book";
import { getUserBookRating } from "../api/rating";
import { SpecificRating } from "../models/rating/SpecificRating";

export default function useBookInfo(id: string){

    const [book, setBook] = useState<BookDisplayDTO>({
        bookId: "none",
        title: "",
        author: "",
        coverImagePath: "",
        averageRating: 0,
        numberOfRatings: 0,
        tags: []
    });

    const [bookRatingId, setBookRatingId] = useState<string | undefined>(undefined);
    const [overallRating, setOverallRating] = useState<number>(0);
    const [specificRatings, setSpecificRatings] = useState<SpecificRating[]>([]);

    useEffect(() => {
            const fetchBookInfo = async () => {
                const book = await getBookById(id);
                const rating = await getUserBookRating(id);

                setBook(book);
                if (rating){
                    setBookRatingId(rating.bookRatingId);
                    console.log(rating.bookRatingId);
                    setOverallRating(rating.overallRating);
                    console.log("overallerRating");
                    console.log(rating.overallRating);
                    setSpecificRatings(rating.specificRatings);
                }
            }
            fetchBookInfo();
        },[id]
    )

    return { 
                book, 
                bookRatingId, setBookRatingId, 
                overallRating, setOverallRating, 
                specificRatings, setSpecificRatings
           };
}

