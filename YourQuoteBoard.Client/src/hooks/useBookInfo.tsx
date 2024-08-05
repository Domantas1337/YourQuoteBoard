import { useEffect, useState } from "react";
import BookDisplayDTO from "../models/books/BookDisplayDTO";
import { getBookById } from "../api/book";
import { getUserBookRating } from "../api/rating";
import { RatingCategory } from "../models/rating/RatingCategory";
import { BookRating } from "../models/rating/BookRating";
import { getLabelOfProperty } from "../helpers/propertyToString";

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
    const [bookRating, setBookRating] = useState<BookRating>();
    const [bookRatingCategories, setBookRatingCategores] = useState<RatingCategory[]>([]);

    useEffect(() => {
            const fetchBookInfo = async () => {
                const book = await getBookById(id);
                const rating = await getUserBookRating(id);

                setBook(book);
                setBookRating(rating?.bookRating);
                setBookRatingId(rating?.bookRatingId);

                if (rating){
                    setBookRatingCategores(getBookCategories(rating.bookRating));
                }
            }
            fetchBookInfo();
        },[id]
    )

    return {book, bookRatingId, bookRating, setBookRating, bookRatingCategories, setBookRatingCategores};
}

function getBookCategories(rating: BookRating){
    if (rating){
        const categoryEntries = Object.keys(rating) as Array<keyof BookRating>;
                            
        const ratingCategories: RatingCategory[] = categoryEntries.map( (categoryKey) => ({
            key: categoryKey,
            value: rating[categoryKey],
            label: getLabelOfProperty(categoryKey)
        }));

        return ratingCategories;
    }else{
        return [];
    }
}