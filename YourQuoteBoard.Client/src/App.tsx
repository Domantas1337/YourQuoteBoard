import AddQuoteForm from "./components/AddQuoteForm";
import Card from "./components/Card"
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Card />} />
        <Route path="add-quote" element={<AddQuoteForm />} />
      </Routes>
    </Router>
  );
}

export default App
