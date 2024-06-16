import AddQuoteForm from "./components/AddQuoteForm";
import Navbar from "./components/Navbar/NavBar"
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import BrowseQuotes from "./components/manageQuotes/BrowseQuotes";

function App() {
  return (
    <Router>
      <Navbar />
      <div className="main-content">
        <Routes>
          <Route path="browse-quotes" element={<BrowseQuotes />} />
          <Route path="add-quote" element={<AddQuoteForm />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App
