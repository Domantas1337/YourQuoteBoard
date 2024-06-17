import { useState } from "react";
import { QuoteCreateDTO } from "../models/quotes/QuoteCreateDTO";
import { createQuote } from '../api/quote';

function AddQuoteForm(){

    const [quote, setQuote] = useState<QuoteCreateDTO>({title: '', description: '', author: ''});

    function handleNewInput(e : React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>){
        setQuote(prevQuote => ({
            ...prevQuote,
            [e.target.name]: e.target.value
        }));
    }

    async function handleSubmit(e: React.FormEvent<HTMLFormElement>){
        e.preventDefault();
        try{
            const response = createQuote(quote);
            
            console.log('Quote submitted:', response);
            setQuote({ title: '', description: '', author: '' });
        } catch (error) {
            console.error('Failed to submit quote:', error);
        }
    }

    return <form className="default-form" onSubmit={handleSubmit}>
                <div className="form-group">
                    <label 
                        htmlFor="titleInput"
                        className="default-label"
                        >Quote title</label>
                    <input 
                        type="text" 
                        className="form-control" 
                        id="titleInput" 
                        name="title"
                        value={quote.title}
                        onChange={handleNewInput}
                        />
                </div>
                <div className="form-group">
                    <label 
                        htmlFor="authorInput"
                        className="default-label"
                        >Quote author</label>
                    <input 
                        type="text" 
                        className="form-control" 
                        id="authorInput" 
                        name="author"
                        value={quote.author}
                        onChange={handleNewInput}
                        />
                </div>
                <div className="form-group">
                    <label 
                        htmlFor="descriptionInput"
                        className="default-label"
                        >Quote description</label>
                    <textarea 
                        className="form-control" 
                        id="descriptionInput"
                        name="description"
                        value={quote.description}
                        onChange={handleNewInput}
                        ></textarea>
                </div>
                <button type="submit" className="btn btn-default submit-button">Submit quote</button>
            </form>
}



export default AddQuoteForm;