import { useNavigate } from "react-router-dom";
import { EllipsisOutlined, StarFilled } from '@ant-design/icons';
import "./quoteCard.css";

interface QuoteCardProps {
  title : string;
  shortDescription : string;
  averageRating?: number;
  openManagementModal : (id: string) => void;
  quoteId : string;
}

export default function QuoteCard ({ title, shortDescription, averageRating, quoteId, openManagementModal} : QuoteCardProps) {

  const navigate = useNavigate();

  function handleQuoteVisit(){
    navigate(`/quote/${quoteId}`);
  }

  return (
    <div className="card" onClick={handleQuoteVisit}>
      <div className="card-body">
        <div className="card-details">
          <EllipsisOutlined onClick={(event) => {
              event.stopPropagation();
              openManagementModal(quoteId);
            }} />
        </div>
        <h5 className="card-title">{title}</h5>
        <p className="card-text">{shortDescription}</p>
            
        <div className="card-rating">
            {averageRating ? 
              (
                <span>{averageRating}</span>
              ) :
              (
                <span>No rating</span>
              )
            }
            <StarFilled />
        </div>
      </div>
    </div>
  )
}

