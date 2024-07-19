import { useEffect, useState } from "react";
import { FolderContentDisplayDTO } from "../../models/folders/FolderContentDisplayDTO";
import { useNavigate, useParams } from "react-router-dom";
import { getFolderContentById } from "../../api/folder";
import { FolderType } from "../../enums/FolderType";
import QuoteCard from "../../components/manageQuotes/quotesCard/QuoteCard";

export default function QuoteFolderPage(){
    const [folder, setFolder] = useState<FolderContentDisplayDTO | null>(null);
    const { id } = useParams();
    const navigate = useNavigate();

    useEffect( () => {
        const fetchFolder = async () => {
            try { 
                if (id) {
                    const folder = await getFolderContentById(id, FolderType.QUOTE);
                    setFolder(folder);
                }else{
                    throw new Error("Folder id is not provided or does not exist");
                }
            }catch (error) {
                console.log("Error while fetching folder ", error);
            }
        }
        fetchFolder();
    }, [id]);

    const handleQuoteClick = (quoteId: string) => {
        navigate(`/quote/${quoteId}`)
    }

    return (
        <>
            {
                folder?.quotes.map((quote, index) => (
                    <QuoteCard key={index} title={quote.title} shortDescription={"shortDescription"} onClick={() => handleQuoteClick(quote.quoteId)} />
                ))
            }
        </>
    );  
}