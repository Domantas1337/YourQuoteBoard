import { useNavigate } from "react-router-dom";
import { EllipsisOutlined } from '@ant-design/icons';


interface QuoteCardProps {
  title : string;
  shortDescription : string;
  openManagementModal : (id: string) => void;
  quoteId : string;
}

export default function QuoteCard ({ title, shortDescription, quoteId, openManagementModal} : QuoteCardProps) {

  const navigate = useNavigate();

  function handleQuoteVisit(){
    navigate(`/quote/${quoteId}`);
  }


  return (
    <div className="card" onClick={handleQuoteVisit}>
      <div className="card-body">
        <EllipsisOutlined onClick={(event) => {
          event.stopPropagation();
          openManagementModal(quoteId);
          }} />
        <h5 className="card-title">{title}</h5>
        <p className="card-text">{shortDescription}</p>
      </div>
    </div>
  )
}

