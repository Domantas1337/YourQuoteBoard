import AddQuoteForm from "./components/manageQuotes/manageQuotes/AddQuoteForm";
import Navbar from "./components/Navbar/NavBar"
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import BrowseBooks from "./components/manageBooks/BrowseBooks";
import AddBookForm from "./components/manageBooks/AddBookForm";
import Register from "./components/account/Register";
import Login from "./components/account/Login";
import AuthorizeView from "./components/account/AuthorizeView";
import Book from "./pages/bookPages/Book";
import QuotesByBookPage from "./pages/quotePages/QuotesByBookPage";
import MyQuotes from "./pages/quotePages/MyQuotes";
import QuoteFolder from "./pages/quotePages/QuoteFolderPage";
import PersonalQuotes from "./components/manageQuotes/mainQuotes/PersonalQuotes";
import UserProvider from "./components/account/UserProvider";
import Quote from "./pages/quotePages/Quote";
import BrowseQuotes from "./components/manageQuotes/mainQuotes/BrowseQuotes";

function App() {
  return (
    <UserProvider>
      <Router>
        <Navbar />
        <div className="main-content">
          <Routes>
            <Route path="my-created-quotes" element={
                          <AuthorizeView>
                              <PersonalQuotes />
                          </AuthorizeView>
                      } />          
            <Route path="browse-quotes" element={<BrowseQuotes />} />
            <Route path="add-quote" element={<AddQuoteForm />} />
            <Route path="my-quotes" element={<MyQuotes />} />
            <Route path="browse-books" element={<BrowseBooks />} />
            <Route path="add-book" element={<AddBookForm />} />
            <Route path="book/:id" element={<Book />} />
            <Route path="quote/:id" element={<Quote />} />
            <Route path="bookQuotes/:id" element={<QuotesByBookPage />} />
            <Route path="quote-folder/:id" element={<QuoteFolder />} />
            <Route path="register" element={<Register />} />
            <Route path="login" element={<Login />} />
          </Routes>

        </div>
      </Router>
    </UserProvider>
  );
}

export default App
