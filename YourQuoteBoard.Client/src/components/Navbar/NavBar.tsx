import './Navbar.css'
import React from 'react';
import { apiClient } from '../../apiClient';

function Navbar(){
    const user = sessionStorage.getItem('user');

    const handleLogout = async (event: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => {
      event.preventDefault();
      try {
          await apiClient.post('/logout');
          sessionStorage.setItem('user', '');
          window.location.href = "/";
      } catch (error) {
          console.log('Logout failed', error);
      }
    };

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
          
          {user &&
            <> 
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
                <a href="/logout" className="menu-item" onClick={handleLogout}>
                    <img src="MyQuotes.svg" className="menu-icon" alt="My Quotes Icon" />
                    <span>Logout</span>
                </a>
              </li> 
            </>
          }
          
          
          

          {!user &&
            <>
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
            </>
          }

          </ul>
        </nav>
      );
}

export default Navbar;