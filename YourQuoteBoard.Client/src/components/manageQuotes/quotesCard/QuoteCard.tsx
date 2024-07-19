
interface QuoteCardProps {
  title: string;
  shortDescription: string;
  onClick?: () => void;
}

const QuoteCard = ({ title, shortDescription, onClick } : QuoteCardProps) => {
  return (
    <div className="card" onClick={onClick}>
      <div className="card-body">
        <h5 className="card-title">{title}</h5>
        <p className="card-text">{shortDescription}</p>
      </div>
    </div>
  );
};

export default QuoteCard;
