import AddQuoteForm from "./components/AddQuoteForm";
import Navbar from "./components/Navbar/NavBar"
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import BrowseQuotes from "./components/manageQuotes/BrowseQuotes";
import BrowseBooks from "./components/manageBooks/BrowseBooks";
import AddBookForm from "./components/manageBooks/AddBookForm";
import Register from "./components/account/Register";
import Login from "./components/account/Login";
import PersonalQuotes from "./components/manageQuotes/PersonalQuotes";
import AuthorizeView from "./components/account/AuthorizeView";
import UserProvider from "./components/UserProvider";

function App() {
  return (
    <UserProvider>
      <Router>
        <Navbar />
        <div className="main-content">
          <Routes>
            <Route path="browse-books" element={<BrowseBooks />} />
            <Route path="my-quotes" element={
                          <AuthorizeView>
                              <PersonalQuotes />
                          </AuthorizeView>
                      } />          
            <Route path="browse-quotes" element={<BrowseQuotes />} />
            <Route path="add-quote" element={<AddQuoteForm />} />
            <Route path="add-book" element={<AddBookForm />} />
            <Route path="register" element={<Register />} />
            <Route path="login" element={<Login />} />
          </Routes>

        </div>
      </Router>
    </UserProvider>
  );
}

export default App
