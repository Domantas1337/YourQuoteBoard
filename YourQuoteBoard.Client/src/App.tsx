import AddQuoteForm from "./components/AddQuoteForm";
import Card from "./components/Card"
import Navbar from "./components/Navbar/NavBar"
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

function App() {
  return (
    <Router>
      <Navbar />
      <div className="main-content">
        <Routes>
          <Route path="/" element={<Card />} />
          <Route path="add-quote" element={<AddQuoteForm />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App
