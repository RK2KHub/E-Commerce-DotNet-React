//import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import ProductGrid from './ProductGrid';
import ProductDetails from './ProductDetails';
import Navbar from './Navbar';
import AboutUs from './AboutUs'; // Ensure to create this component
import ContactUs from './ContactUs'; // Ensure to create this component
import Cart from './Cart';
import CheckoutSuccess from './CheckoutSuccess';

const App = () => {
    return (
        <Router>
            <Navbar />
            <Routes>
                <Route path="/" element={<ProductGrid />} />
                <Route path="/products/:id" element={<ProductDetails />} />
                <Route path="/about" element={<AboutUs />} />
                <Route path="/contact" element={<ContactUs />} />
                <Route path="/cart" element={<Cart />} />
                <Route path="/checkout-success" element={<CheckoutSuccess />} />
            </Routes>
        </Router>
    );
};

export default App;
