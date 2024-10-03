import { Link } from 'react-router-dom';
import './Navbar.css'; // Adjust the path according to your structure

const Navbar = () => {
    return (
        <nav className="navbar">
            <h1 className="navbar-title">RK TRADERS</h1>
            <div className="navbar-menu">
                <Link to="/" className="navbar-button">Home</Link>
                <Link to="/contact" className="navbar-button">Contact Us</Link>
                <Link to="/about" className="navbar-button">About</Link>
            </div>
        </nav>
    );
};

export default Navbar;
