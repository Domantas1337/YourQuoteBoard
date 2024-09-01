import { useEffect, useState } from "react";
import AddQuoteFolder from "../../components/manageQuotes/quoteFolders/AddQuoteFolder";
import QuoteFolder from "../../components/manageQuotes/quoteFolders/QuoteFolder";
import { Row, Col } from 'antd';
import { addQuoteToFolder, getQuoteFoldersByUserId } from "../../api/folder";
import { FolderType } from "../../enums/FolderType";
import { FoldersDisplayDTO } from "../../models/folders/FolderDisplayDTO";
import { useNavigate } from "react-router-dom";
import FavoritesFolder from "../../components/favorites/FavoritesFolder";

export default function FolderDisplayPage(){
    
    const [folders, setFolders] = useState<FoldersDisplayDTO[] | null>([]);
    
    const navigate = useNavigate();

    const quoteId = new URLSearchParams(location.search).get('quoteId');

    useEffect( () => {
        const fetchFolders = async () => {
            try { 
                const folders = await getQuoteFoldersByUserId(FolderType.QUOTE);
                setFolders(folders);
            }catch (error) {
                console.log("Error while fetching folders ", error);
            }
        }
        fetchFolders();
    }, []);
    
    const handleFavoritesFolderClick = () => {
        navigate("/favorite-quotes");
    }

    const handleFolderClick = async (id: string) => {
        if(quoteId){
            try{
                const response = await addQuoteToFolder(id, quoteId);         
                console.log("Saved quote to folder ", response);
            }catch(error){
                console.log("Failed to save ");
            }
        }else{
            navigate(`/quote-folder/${id}`);
        }
    }

    return (
        <Row className='quote-folder-row' gutter={[40, 24]}>         
            <FavoritesFolder onClick={handleFavoritesFolderClick}/>
            {
                folders?.map( (folder, index) => (
                        <Col className="gutter-row" key={index} xs={24} sm={12} md={8} lg={6}>
                            <QuoteFolder 
                                name={folder.name} 
                                onClick={() => 
                                    handleFolderClick(folder.folderId)
                                }
                                addQuoteMode={quoteId != null}
                            />
                        </Col>
                ))
            }
            <AddQuoteFolder />
        </Row>
    );
}