import { useEffect, useState } from "react";
import { QuoteCreateDTO } from "../../../models/quotes/QuoteCreateDTO";
import { createQuote } from '../../../api/quote';
import { useNavigate } from 'react-router-dom';
import { Select } from "antd";
import { getAllBooks } from "../../../api/book";
import BookDisplayDTO from "../../../models/books/BookDisplayDTO";
 
function AddQuoteForm(){

    const [quote, setQuote] = useState<QuoteCreateDTO>({title: '', description: '', author: ''});
    const [books, setBooks] = useState<BookDisplayDTO[]>([]);
    const navigate = useNavigate()

    useEffect(   () => {
        
        const fetchBooks = async () => {
            try{
                const fethedBooks = await getAllBooks();
                setBooks(fethedBooks);
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

    async function handleSubmit(e: React.FormEvent<HTMLFormElement>){
        e.preventDefault();
        try{
            const response = createQuote(quote);
            
            console.log('Quote submitted:', response);
            setQuote({ title: '', description: '', author: '' });
            navigate('/my-quotes')
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
                <Select showSearch 
                        options={books.map((book) => ({
                            value: book.title,
                            label: book.title,
                        }))}
                        
                        className="quote-book-select"
                        
                    > 
                    {
                        books.map( (book, index) => (
                            <Select.Option key={index} value={book.bookId}>{book.title}</Select.Option>
                        ) )
                    }
                </Select>
                <button type="submit" className="btn btn-default submit-button">Submit quote</button>
            </form>
        </div>
        );
}



export default AddQuoteForm;