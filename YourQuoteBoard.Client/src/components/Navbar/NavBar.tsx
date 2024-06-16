import './Navbar.css'

function Navbar(){
    return (
        <nav>
          <ul>
          <li>
            <a href="/browse-quotes" className="menu-item">
                <span>Browse quotes</span>
            </a>            
          </li>
          <li>
            <a href="/my-quotes" className="menu-item">
                <span>My quotes</span>
            </a>            
          </li>
          </ul>
        </nav>
      );
}

export default Navbar;