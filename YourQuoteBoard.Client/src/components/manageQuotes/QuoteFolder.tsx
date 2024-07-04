import { FolderOutlined, PlusOutlined } from '@ant-design/icons';
import { Input, Row, Col } from 'antd';
import './quotes.css';
import { useState } from 'react';

export default function QuoteFolder(){
    
    const [folderName, setFolderName] = useState("");
    const [folderNameSet, setFolderNameSet] = useState(false);

    const handleFolderNameChange = (e : React.ChangeEvent<HTMLInputElement>) => {
        setFolderName(e.target.value);
    }

    const handleNameChangeSave = (e : React.KeyboardEvent<HTMLInputElement>) => {
        if (e.key == "Enter"){
            if (folderName != ""){
                console.log(folderName);
                setFolderNameSet(true)
            }
        }
    }

    return (
            <Row className='quote-folder-row' gutter={[40, 24]}>
            
                <Col className="gutter-row" span={6}>
                    <div className="folder-container">
                        <FolderOutlined className="quote-folder" name='Name'  />
                        { 
                            !folderNameSet ?
                            <Input className="quote-folder-name-input" placeholder="Outlined" onChange={handleFolderNameChange} onKeyDown={handleNameChangeSave}/>
                            :
                            <button type="submit" className="folder-button visit-button">{folderName}</button>
                        }
                    </div>
                </Col>

                <Col className="gutter-row" span={6}>
                    <div className="folder-container">
                        <PlusOutlined className="quote-folder" name='Name' />
                        <button type="submit" className="folder-button">Submit book</button>
                    </div>          
                </Col>

            </Row>

        
    )
}