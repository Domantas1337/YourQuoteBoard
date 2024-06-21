import { useEffect, useState } from 'react';
import './BookPage.css';
import { getAllBooks } from '../../api/book';
import { useNavigate } from 'react-router-dom';
import BookDisplayDTO from '../../models/books/BookDisplayDTO';


function BrowseBooks() {
  
  const [books, setBooks] = useState<BookDisplayDTO[]>([]);

  const navigate = useNavigate();

  const handleBookClick = (id: string) => {
    navigate(`/book/${id}`)
  };

  const featuredBook = {
    id: "10000",
    title: "Featured Book Title",
    author: "Featured Author",
    coverImageBase64: "none"
  };

  useEffect(
    () => {
      const fetchBooks = async () => {
        try {
          const fetchedBooks = await getAllBooks();
          
          setBooks(fetchedBooks)
        }catch(error){
          console.log("error fetching books: ", error)
        }
      }
      fetchBooks();
    }, []
  )

  return (
    <div className="book-container">
      <div className="featured-book-card" onClick={() => handleBookClick(featuredBook.id)}>
        <img src="none" alt={`${featuredBook.title} cover`} className="book-cover" />
        <div className="book-info">
          <h2>{featuredBook.title}</h2>
          <p>{featuredBook.author}</p>
        </div>
      </div>
      <div className="regular-books">
        {books.map((book) => (
          <div key={book.bookId} className="book-card" onClick={() => handleBookClick(book.bookId)}>
            <img src={book.coverImagePath} alt={`${book.title} cover`} className="book-cover" />
            <div className="book-info">
              <h2>{book.title}</h2>
              <p>{book.author}</p>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}

export default BrowseBooks;
