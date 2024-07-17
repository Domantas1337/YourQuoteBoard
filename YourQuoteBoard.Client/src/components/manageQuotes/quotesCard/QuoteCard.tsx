import React from 'react';

interface QuoteCardProps {
  title: string;
  shortDescription: string;
}

const QuoteCard: React.FC<QuoteCardProps> = ({ title, shortDescription }) => {
  return (
    <div className="card">
      <div className="card-body">
        <h5 className="card-title">{title}</h5>
        <p className="card-text">{shortDescription}</p>
      </div>
    </div>
  );
};

export default QuoteCard;
