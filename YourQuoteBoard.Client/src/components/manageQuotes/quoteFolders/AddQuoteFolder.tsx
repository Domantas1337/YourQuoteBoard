import { PlusOutlined } from '@ant-design/icons';
import QuoteFolder from './QuoteFolder';
import {useState} from 'react';
import { Col } from 'antd';

export default function AddQuoteFolder(){

    const [addFolder, setAddFolder] = useState<boolean>(false);

    const handleAddingFolder = () => {
        setAddFolder(true);
    }

    return <>
                { 
                 
                    !addFolder ? (
                        <Col className="gutter-row" xs={24} sm={12} md={8} lg={6}>
                            <div className="folder-container">
                                <PlusOutlined className="quote-folder" name='Name' />
                                <button type="submit" className="folder-button" onClick={handleAddingFolder}>Add folder</button>
                            </div>
                        </Col>                                                     
                    ) : 
                    (
                        <>
                            <Col className="gutter-row" xs={24} sm={12} md={8} lg={6}>
                                <QuoteFolder name={null}/>
                            </Col>
                            <Col className="gutter-row" xs={24} sm={12} md={8} lg={6}>
                                <div className="folder-container">
                                    <PlusOutlined className="quote-folder" name='Name' />
                                    <button type="submit" className="folder-button" onClick={handleAddingFolder}>Add folder</button>
                                </div>
                            </Col>

                        </>
                    )
                } 
                
            </>
}