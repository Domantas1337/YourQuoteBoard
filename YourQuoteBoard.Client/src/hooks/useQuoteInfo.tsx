import { useEffect, useState } from "react";
import { RatingCategory } from "../models/rating/RatingCategory";
import { getLabelOfProperty } from "../helpers/propertyToString";
import { QuoteFullDisplayDTO } from "../models/quotes/QuoteFullDisplayDTO";
import { getQuoteForDesignatedPage } from "../api/quote";
import { getUserQuoteRating } from "../api/quoteRating";
import { QuoteRatingInDetail } from "../models/rating/quote/QuoteRatingInDetail";

export default function useQuoteInfo(id: string){

    const [quote, setQuote] = useState<QuoteFullDisplayDTO>({
        title: "",
        description: "",
        author: "",
        created: new Date(2000, 1, 1),
        bookTitle: "",
        bookId: "",
        averageRating: 0,
        numberOfRatings: 0,
        tags: []
    });
    const [overallRating, setOverallRating] = useState<number>(0);
    const [detailedRating, setDetailedRating] = useState<QuoteRatingInDetail>({
        relevanceToTheTopicRating: undefined,
        originalityRating: undefined,
        inspirationalValueRating: undefined
    })
    const [quoteRatingCategories, setQuoteRatingCategories] = useState<RatingCategory[]>([]);
    const [quoteRatingId, setQuoteRatingId] = useState<string>("");

    useEffect(() => {
        const fetchQuoteInfo = async () => {
            try{
                const fetchedQuote = await getQuoteForDesignatedPage(id);
                const rating = await getUserQuoteRating(id);
    
                setQuote(fetchedQuote);
                
                if (rating){
                    setQuoteRatingId(rating.quoteRatingId);
                    setOverallRating(rating.overallRating);
                    setDetailedRating(rating.quoteRatingInDetail);
                    console.log("In detail ", quoteRatingCategories);
                    setQuoteRatingCategories(getQuoteCategories(rating.quoteRatingInDetail));
                    console.log("detail ", quoteRatingCategories);
                }
            }catch(error){
                console.log("Failed to fetch quote details: ", error);
            }

        }
        fetchQuoteInfo();
    }, [id])


    return {overallRating, setOverallRating, 
            quote, setQuote, 
            detailedRating, setDetailedRating,
            quoteRatingCategories, setQuoteRatingCategories,
            quoteRatingId};
}

function getQuoteCategories(rating: QuoteRatingInDetail){
    if (rating){
        const categoryEntries = Object.keys(rating) as Array<keyof QuoteRatingInDetail>;
                            
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