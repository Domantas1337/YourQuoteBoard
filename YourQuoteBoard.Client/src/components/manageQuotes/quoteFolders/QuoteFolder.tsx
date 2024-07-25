import { FolderOutlined } from '@ant-design/icons';
import { Input } from 'antd';
import '../quotes.css';
import React, { useEffect, useState } from 'react';
import { createFolder } from '../../../api/folder';
import { FolderType } from '../../../enums/FolderType';

interface QuoteFolderProps {
    name : string | null;
    onClick? : () => void;
    addQuoteMode: boolean;
}

export default function QuoteFolder({name, onClick, addQuoteMode} : QuoteFolderProps) {
    
    const [folderName, setFolderName] = useState("");
    const [folderNameSet, setFolderNameSet] = useState(false);

    console.log(addQuoteMode);

    useEffect(() => {
        if (name){
            setFolderName(name);
            setFolderNameSet(true);
        }
    }, [name])

    const handleFolderNameChange = (e : React.ChangeEvent<HTMLInputElement>) => {
        setFolderName(e.target.value);
    }

    const handleNameChangeSave = async (e : React.KeyboardEvent<HTMLInputElement>) => {
        if (e.key == "Enter"){
            if (folderName != null){
                
                try{
                    const response = await createFolder({name: folderName}, FolderType.QUOTE);

                    console.log("Folder created: ", response);
                }catch(error){
                    console.error("Error while crating folder: ", error);
                }

                setFolderNameSet(true)
            }
        }
    }

    return (
        <div className={`folder-container ${addQuoteMode ? 'add-quote' : 'regular-folder'}`} onClick={onClick}>
            <FolderOutlined className="quote-folder" name='Name'  />
            { 
                !folderNameSet ?
                <Input className="quote-folder-name-input" placeholder="Outlined" onChange={handleFolderNameChange} onKeyDown={handleNameChangeSave}/>
                :
                <button type="submit" className="folder-button visit-button">{folderName}</button>
            }
        </div>
    )
}