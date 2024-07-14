import { PlusOutlined } from '@ant-design/icons';
import QuoteFolder from './QuoteFolder';
import {useState} from 'react';

export default function AddQuoteFolder(){

    const [showAddFolderButton, setShowAddFolderButton] = useState<boolean>(true);

    const handleAddingFolder = () => {
        setShowAddFolderButton(false);
    }

    return  <div className="folder-container">
                { 
                    showAddFolderButton ? (
                        <>
                            <PlusOutlined className="quote-folder" name='Name' />
                            <button type="submit" className="folder-button" onClick={handleAddingFolder}>Add folder</button>
                        </>
                    )
                    : (
                        <QuoteFolder />
                    )
                } 
            </div>  
}