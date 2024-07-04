import AddQuoteForm from "./components/AddQuoteForm";
import Navbar from "./components/Navbar/NavBar"
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import BrowseBooks from "./components/manageBooks/BrowseBooks";
import AddBookForm from "./components/manageBooks/AddBookForm";
import Register from "./components/account/Register";
import Login from "./components/account/Login";
import PersonalQuotes from "./components/manageQuotes/PersonalQuotes";
import AuthorizeView from "./components/account/AuthorizeView";
import UserProvider from "./components/UserProvider";
import Book from "./pages/Book";
import RecommendedQuotesPage from "./pages/RecommendedQuotesPage";
import QuotesByBookPage from "./pages/QuotesByBookPage";
import MyQuotes from "./pages/MyQuotes";

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
            <Route path="browse-quotes" element={<RecommendedQuotesPage />} />
            <Route path="add-quote" element={<AddQuoteForm />} />
            <Route path="my-quotes" element={<MyQuotes />} />
            <Route path="browse-books" element={<BrowseBooks />} />
            <Route path="add-book" element={<AddBookForm />} />
            <Route path="book/:id" element={<Book />} />
            <Route path="bookQuotes/:id" element={<QuotesByBookPage />} />

            <Route path="register" element={<Register />} />
            <Route path="login" element={<Login />} />
          </Routes>

        </div>
      </Router>
    </UserProvider>
  );
}

export default App
