import { useEffect, useState } from "react";
import { QuoteCreateDTO } from "../../../models/quotes/QuoteCreateDTO";
import { createQuote } from '../../../api/quote';
import { useNavigate } from 'react-router-dom';
import { getAllBooks } from "../../../api/book";
import BookDisplayDTO from "../../../models/books/BookDisplayDTO";
 
function AddQuoteForm(){

    const [quote, setQuote] = useState<QuoteCreateDTO>({title: '', description: '', author: '', bookId: null});
    const [books, setBooks] = useState<BookDisplayDTO[]>([]);
    const navigate = useNavigate()

    useEffect(   () => {
        
        const fetchBooks = async () => {
            try{
                const fethedBooks = await getAllBooks();
                console.log(fethedBooks);
                setBooks(fethedBooks);
                console.log(books.length);
            }catch(error){
                console.log("Error while fetching books: ", error);
            }
        }
            
        fetchBooks();
    }, [] )

    function handleNewInput(e : React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>){
        setQuote(prevQuote => ({
            ...prevQuote,
            [e.target.name]: e.target.value
        }));
    }

    const handleDatalistInput = (e : React.ChangeEvent<HTMLInputElement>) => {
        const input = e.target.value;
        const datalist = document.getElementById("bookDatalist") as HTMLDataListElement;

        if (datalist){
            const selectedOption = Array.from(datalist.options).find(
                (option) => option.value === input
            );
            
            
            if (selectedOption){            
                setQuote(prevQuote => ({
                    ...prevQuote,
                    bookId: selectedOption.getAttribute("data-value")
                }));
            }
        }
    }

    async function handleSubmit(e: React.FormEvent<HTMLFormElement>){
        e.preventDefault();
        try{
            console.log(quote);
            if (quote.bookId != null){
                console.log(quote);
                const response = createQuote(quote);
                console.log('Quote submitted:', response);
                setQuote({ title: '', description: '', author: '', bookId: null});
                navigate('/browse-quotes')
            } 
        } catch (error) {
            console.error('Failed to submit quote:', error);
        }
    }

    return(
        <div className="default-form-container">
            <form className="default-form" onSubmit={handleSubmit}>
                <h1 className="default-header">Add a quote</h1>
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
                <label 
                        htmlFor="titleInput"
                        className="default-label"
                        >Book</label>
                
                <input list="bookDatalist"  className="form-control" onChange={handleDatalistInput}/>
                <datalist id="bookDatalist" >
                {
                    books.map( (book, index) => (
                        <option key={index} data-value={book.bookId}>{book.title}</option>
                    ) )
                    
                }
                </datalist>  
                <button type="submit" className="btn btn-default submit-button">Submit quote</button>
            </form>
        </div>
        );
}



export default AddQuoteForm;