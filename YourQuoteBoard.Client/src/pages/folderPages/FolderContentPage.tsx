import { useEffect, useState } from "react";
import { FolderContentDisplayDTO } from "../../models/folders/FolderContentDisplayDTO";
import { useParams } from "react-router-dom";
import { getFolderContentById } from "../../api/folder";
import { FolderType } from "../../enums/FolderType";
import QuoteCard from "../../components/manageQuotes/quotesCard/QuoteCard";
import "./folderStyle.css"
import Title from "../../components/basic/Title";
import NumberOfItems from "../../components/basic/NumberOfItems";

export default function FolderContentPage(){
    const [folder, setFolder] = useState<FolderContentDisplayDTO | null>(null);
    const { id } = useParams();

    useEffect( () => {
        const fetchFolder = async () => {
            console.log("kaaaaab");

            try { 
                if (id) {
                    const folder = await getFolderContentById(id, FolderType.QUOTE);
                    console.log("kaaaaac");
                    console.log(folder?.name);
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


    return (
        <div className="folder-content-container">
            { 
                folder?.name ? (
                <>
                    <Title title={folder?.name}/>   
                    <NumberOfItems itemName="quote" listLength={folder!.quotes.length} />
                </>
                ):(
                <>
                    <Title title="Content not found"/>   
                </>
                )
            } 

            <div className="cards-container">
                {
                    folder?.quotes.map((quote, index) => (
                        <QuoteCard key={index} title={quote.title} shortDescription={"shortDescription"} quoteId={quote.quoteId} />
                    ))
                }
            </div>
        </div>
    );  
}