//import React, { useEffect, useState } from 'react';
//import { Link } from 'react-router-dom';
//import './ProductGrid.css';

//const ProductGrid = () => {
//    const [products, setProducts] = useState([]);

//    useEffect(() => {
//        const fetchProducts = async () => {
//            const response = await fetch('https://localhost:5001/api/products');
//            const data = await response.json();
//            setProducts(data);
//        };

//        fetchProducts();
//    }, []);

//    return (
//        <div className="product-grid">
//            {products.map(product => (
//                <div key={product.id} className="product-card">
//                    <Link to={`/products/${product.id}`}>
//                        <img src={product.imageUrl} alt={product.name} />
//                        <h3>{product.name}</h3>
//                        <p>{product.color}</p>
//                    </Link>
//                </div>
//            ))}
//        </div>
//    );
//};

//export default ProductGrid;


import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import './ProductGrid.css';

const ProductGrid = () => {
    const [products, setProducts] = useState([]);

    useEffect(() => {
        const fetchProducts = async () => {
            const response = await fetch('https://localhost:5001/api/products');
            const data = await response.json();
            console.log(data); // Log the data to see the structure
            setProducts(data);
        };

        fetchProducts();
    }, []);

    return (
        <div className="product-grid">
            {products.map(product => (
                <div key={product.id} className="product-card">
                    <Link to={`/products/${product.id}`}>
                        <img
                            src={product.imageUrl}
                            alt={product.name}
                            onError={(e) => { e.target.onerror = null; e.target.src = "https://via.placeholder.com/150"; }} // Fallback image
                        />
                        <h3>{product.name}</h3>
                        <p>{product.color}</p>
                    </Link>
                </div>
            ))}
        </div>
    );
};

export default ProductGrid;
