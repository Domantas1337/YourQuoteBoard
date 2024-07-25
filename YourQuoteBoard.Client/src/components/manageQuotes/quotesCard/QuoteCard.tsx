import { useNavigate } from "react-router-dom";

interface QuoteCardProps {
  title : string;
  shortDescription : string;
  quoteId : string;
}

export default function QuoteCard ({ title, shortDescription, quoteId } : QuoteCardProps) {

  const navigate = useNavigate();

  function handleQuoteVisit(){
    navigate(`/quote/${quoteId}`);
  }

  return (
    <div className="card" onClick={handleQuoteVisit}>
      <div className="card-body">
        <h5 className="card-title">{title}</h5>
        <p className="card-text">{shortDescription}</p>
      </div>
    </div>
  )
}

