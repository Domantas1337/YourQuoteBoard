import styles from './Navbar.module.css'
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
      <div className={styles.NavBarContainer}>
        <nav>
          <ul className={styles.ul}>
          <li className={styles.li}>
            <a href="/browse-books" className={styles.menuItem}>
                <img src="books.svg" className={styles.menuIcon} alt="Browse Books Icon" />
                <span className={styles.span}>Browse books</span>
            </a>          
          </li>
          <li className={styles.li}>
            <a href="/browse-quotes" className={styles.menuItem}>
                <img src="searchQuotes.svg" className={styles.menuIcon} alt="Browse Quotes Icon" />
                <span className={styles.span}>Browse quotes</span>
            </a>          
          </li>
          
          {user &&
            <> 
              <li className={styles.li}>
                <a href="/my-created-quotes" className={styles.menuItem}>
                    <img src="MyQuotes.svg" className={styles.menuIcon} alt="My Quotes Icon" />
                    <span className={styles.span}>My added quotes</span>
                </a>
              </li> 
              <li className={styles.li}>
                <a href="/my-quotes" className={styles.menuItem}>
                    <img src="MyQuotes.svg" className={styles.menuIcon} alt="My Quotes Icon" />
                    <span className={styles.span}>My saved quotes</span>
                </a>
              </li> 
              <li className={styles.li}>
                <a href="/add-book" className={styles.menuItem}>
                    <span className={styles.span}>Add book</span>
                </a>            
              </li>
              
              <li className={styles.li}>
                <a href="/logout" className={styles.menuItem} onClick={handleLogout}>
                    <img src="MyQuotes.svg" className={styles.menuIcon} alt="My Quotes Icon" />
                    <span className={styles.span}>Logout</span>
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
      </div>
      );
}

export default Navbar;