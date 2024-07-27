import { useEffect, useState } from "react";
import { FolderContentDisplayDTO } from "../../models/folders/FolderContentDisplayDTO";
import { useParams } from "react-router-dom";
import { getFolderContentById } from "../../api/folder";
import { FolderType } from "../../enums/FolderType";
import QuoteCard from "../../components/manageQuotes/quotesCard/QuoteCard";
import "./folderStyle.css"
import Title from "../../components/basic/Title";
import NumberOfItems from "../../components/basic/NumberOfItems";
import FolderContent from "../../components/manageQuotes/quoteFolders/FolderContent";

export default function FolderContentPage(){
    const [folder, setFolder] = useState<FolderContentDisplayDTO | null>(null);
    const { id } = useParams();

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


    return (
        <div className="folder-content-container">
            {   
                folder ? (
                    <FolderContent title={folder?.name} numberOfItems={folder.quotes.length} quotes={folder.quotes} />
                ) :
                (
                    <h3>No contnet</h3>
                )
            }
        </div>
     );  
}