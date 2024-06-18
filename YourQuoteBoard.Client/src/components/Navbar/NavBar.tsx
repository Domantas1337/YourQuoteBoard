import { useContext } from 'react';
import './Navbar.css'
import { UserContext } from '../account/AuthorizeView';

function Navbar(){
    const user = useContext(UserContext);
  
    console.log(user?.email);

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
                <img src="MyQuotes.svg" className="menu-icon" alt="My Quotes Icon" />
                <span>My quotes</span>
            </a>
          </li>
          <li>
            <a href="/add-book" className="menu-item">
                <span>Add book</span>
            </a>            
          </li>
          <li>
            <a href="/register" className="menu-item">
                <span>Register</span>
            </a>            
          </li>
          <li>
            <a href="/login" className="menu-item">
                <span>Login</span>
            </a>            
          </li>
          </ul>
        </nav>
      );
}

export default Navbar;