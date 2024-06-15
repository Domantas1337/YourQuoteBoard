import getAllQuotes from '../api/quote'
import { useState, useEffect } from 'react';
import { QuoteDisplayDTO } from '../models/QuoteDisplayDTO';

function Card(){
    
    const [quotes, setQuotes] = useState<QuoteDisplayDTO[]>([])

    useEffect(
        () => {
            const fetchQuotes = async () => {
                try{
                    const fetchedQuotes = await getAllQuotes();
                    setQuotes(fetchedQuotes)
                }catch(error){
                    console.log("error fetching quotes: ", error)
                }
            };

            fetchQuotes();
        }, []
    );

    return (
        <div> 
            <div className='card-container'>
                {
                    quotes.map( (quote, index) => (
                        <div key={index} className='card'>
                            <div className='card-body'>
                                <h5 className='card-title'>{quote.title}</h5>
                                <p className="card-text">Some text</p>
                                <button className="btn btn-primary">Go to quote</button>
                            </div>
                        </div>
                    )

                    )
                }

                <div className="add-new-card">
                    <a href="/open-modal" className="add-new-card-logo">
                        <img src="/plus.png" alt="Add new" className="img-fluid" />
                    </a>
                </div>
            </div>
        </div>
    );
}

export default Card;