import { useState } from "react";
import { BookCreateDTO } from "../../models/books/BookCreateDTO";
import { createBook } from '../../api/book';

export default function AddBookForm(){

    const [book, setBook] = useState<BookCreateDTO>({title: '', description: '', author: '', pages: 0, coverImage: ''});

    function handleNewInput(e : React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>){
        setBook(prevBook => ({
            ...prevBook,
            [e.target.name]: e.target.value
        }));
    }

    async function handleSubmit(e: React.FormEvent<HTMLFormElement>){
        e.preventDefault();
        try{
            const response = createBook(book);
            
            console.log('Book submitted:', response);
            setBook({title: '', description: '', author: '', pages: 0, coverImage: ''});
        } catch (error) {
            console.error('Failed to submit book:', error);
        }
    }

    return <form className="default-form" onSubmit={handleSubmit}>
                <div className="form-group">
                    <label 
                        htmlFor="titleInput"
                        className="default-label"
                        >Book title</label>
                    <input 
                        type="text" 
                        className="form-control" 
                        id="titleInput" 
                        name="title"
                        value={book.title}
                        onChange={handleNewInput}
                        />
                </div>
                <div className="form-group">
                    <label 
                        htmlFor="authorInput"
                        className="default-label"
                        >Book author</label>
                    <input 
                        type="text" 
                        className="form-control" 
                        id="authorInput" 
                        name="author"
                        value={book.author}
                        onChange={handleNewInput}
                        />
                </div>
                <div className="form-group">
                    <label 
                        htmlFor="pageInput"
                        className="default-label"
                        >Number of pages</label>
                    <input 
                        type="number" 
                        className="form-control" 
                        id="pageInput" 
                        name="pages"
                        value={book.pages}
                        onChange={handleNewInput}
                        />
                </div>
                <div className="form-group">
                    <label 
                        htmlFor="descriptionInput"
                        className="default-label"
                        >Book description</label>
                    <textarea 
                        className="form-control" 
                        id="descriptionInput"
                        name="description"
                        value={book.description}
                        onChange={handleNewInput}
                        ></textarea>
                </div>
                <div className="form-group">
                    <label 
                        htmlFor="coverImageInput"
                        className="default-label"
                        >Cover image of the book</label>
                    <input 
                        type="text" 
                        className="form-control" 
                        id="coverImageInput" 
                        name="coverImage"
                        value={book.coverImage}
                        onChange={handleNewInput}
                        />
                </div>
                <button type="submit" className="btn btn-default submit-button">Submit book</button>
            </form>
}
