import AddQuoteForm from "./components/AddQuoteForm";
import Navbar from "./components/Navbar/NavBar"
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import BrowseQuotes from "./components/manageQuotes/BrowseQuotes";
import BrowseBooks from "./components/manageBooks/BrowseBooks";
import AddBookForm from "./components/manageBooks/AddBookForm";

function App() {
  return (
    <Router>
      <Navbar />
      <div className="main-content">
        <Routes>
          <Route path="browse-books" element={<BrowseBooks />} />
          <Route path="browse-quotes" element={<BrowseQuotes />} />
          <Route path="add-quote" element={<AddQuoteForm />} />
          <Route path="add-book" element={<AddBookForm />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App
