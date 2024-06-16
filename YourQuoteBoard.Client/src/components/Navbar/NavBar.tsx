import './Navbar.css'

function Navbar(){
    return (
        <nav>
          <ul>
          <li>
            <a href="/find-quote" className="menu-item">
                <span>Browse quotes</span>
            </a>            
          </li>
          <li>
            <a href="/" className="menu-item">
                <span>Quotes</span>
            </a>            
          </li>
          </ul>
        </nav>
      );
}

export default Navbar;