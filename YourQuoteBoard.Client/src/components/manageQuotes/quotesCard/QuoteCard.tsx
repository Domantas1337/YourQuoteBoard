import { useNavigate } from "react-router-dom";
import useQuoteTools from "../hooks/useQuoteTools";
import { EllipsisOutlined } from '@ant-design/icons';
import { useState } from "react";


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
        <EllipsisOutlined onClick={() => openManagementModal(quoteId)} />
        <h5 className="card-title">{title}</h5>
        <p className="card-text">{shortDescription}</p>
      </div>
    </div>
  )
}

