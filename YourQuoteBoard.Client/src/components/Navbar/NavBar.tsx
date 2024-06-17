import './Navbar.css'

function Navbar(){
    return (
        <nav>
          <ul>
          <li>
            <a href="/browse-books" className="menu-item">
                <img src="books.svg" className="menu-icon" alt="Browse Books Icon" />
                <span>Browse books</span>
            </a>          
          </li>
          <li>
            <a href="/browse-quotes" className="menu-item">
                <img src="searchQuotes.svg" className="menu-icon" alt="Browse Quotes Icon" />
                <span>Browse quotes</span>
            </a>          
          </li>
          <li>
            <a href="/my-quotes" className="menu-item">
                <img src="MyQuotes.svg" className="menu-icon" alt="Browse Quotes Icon" />
                <span>My quotes</span>
            </a>            
          </li>
          <li>
            <a href="/add-book" className="menu-item">
                <span>Add book</span>
            </a>            
          </li>
          </ul>
        </nav>
      );
}

export default Navbar;