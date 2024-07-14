import AddQuoteFolder from "../components/manageQuotes/quoteFolders/AddQuoteFolder";
import QuoteFolder from "../components/manageQuotes/quoteFolders/QuoteFolder";
import { Row, Col } from 'antd';

export default function MyQuotes(){
    return (
        <Row className='quote-folder-row' gutter={[40, 24]}>
            <Col className="gutter-row" span={6}>
                <QuoteFolder />
            </Col>

            <Col className="gutter-row" span={6}>
                <AddQuoteFolder />
            </Col>
        </Row>
    );
}