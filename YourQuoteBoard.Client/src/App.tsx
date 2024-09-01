import AddQuoteForm from "./components/manageQuotes/manageQuotes/AddQuoteForm";
import Navbar from "./components/Navbar/NavBar"
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import BrowseBooks from "./components/manageBooks/BrowseBooks";
import AddBookForm from "./components/manageBooks/AddBookForm";
import Register from "./components/account/Register";
import Login from "./components/account/Login";
import AuthorizeView from "./components/account/AuthorizeView";
import Book from "./pages/bookPages/Book";
import FolderDisplayPage from "./pages/folderPages/FoldersDisplayPage";
import UserProvider from "./components/account/UserProvider";
import Quote from "./pages/quotePages/Quote";
import BrowseQuotes from "./components/manageQuotes/mainQuotes/BrowseQuotes";
import AddedQuotesPage from "./pages/quotePages/AddedQuotesPage";
import FolderContentPage from "./pages/folderPages/FolderContentPage";
import QuotesByBookPage from "./pages/quotePages/quotesByBook/QuotesByBookPage";
import "./helpers/button/buttonRegistrations";
import FavoriteQuotePage from "./pages/quotePages/FavoriteQuotePage";

function App() {
  return (
    <UserProvider>
      <Router>
        <Navbar />
        <div className="main-content">
          <Routes>
            <Route path="my-created-quotes" element={
                          <AuthorizeView>
                              <AddedQuotesPage />
                          </AuthorizeView>
                      } />          
            <Route path="browse-quotes" element={<BrowseQuotes />} />
            <Route path="add-quote" element={<AddQuoteForm />} />
            <Route path="my-quotes" element={<FolderDisplayPage/>} />
            <Route path="browse-books" element={<BrowseBooks />} />
            <Route path="add-book" element={<AddBookForm />} />
            <Route path="favorite-quotes" element={<FavoriteQuotePage />} />
            <Route path="book/:id" element={<Book />} />
            <Route path="quote/:id" element={<Quote />} />
            <Route path="book-quotes/:id" element={<QuotesByBookPage />} />
            <Route path="quote-folder/:id" element={<FolderContentPage />} />
            <Route path="register" element={<Register />} />
            <Route path="login" element={<Login />} />
          </Routes>

        </div>
      </Router>
    </UserProvider>
  );
}

export default App
