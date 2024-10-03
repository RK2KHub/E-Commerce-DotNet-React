import { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import './ProductDetails.css';

const ProductDetails = () => {
    const { id } = useParams();
    const [product, setProduct] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        const fetchProduct = async () => {
            try {
                const response = await fetch(`https://localhost:5001/api/products/${id}`);
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                const data = await response.json();
                setProduct(data);
            } catch (error) {
                console.error('Error fetching product details:', error);
            }
        };

        fetchProduct();
    }, [id]);

    const handleAddToCart = async () => {
        try {
            const response = await fetch(`https://localhost:5001/api/cart/add/${product.id}`, {
                method: 'POST',
            });
            if (!response.ok) {
                throw new Error('Failed to add product to cart');
            }
            alert(`${product.name} has been added to your cart.`);
        } catch (error) {
            console.error('Error adding to cart:', error);
        }
    };

    const handleGoToCart = () => {
        navigate('/cart');
    };

    if (!product) {
        return <p>Loading...</p>;
    }

    return (
        <div className="product-details">
            <img
                src={product.imageUrl}
                alt={product.name}
                onError={(e) => { e.target.onerror = null; e.target.src = "https://via.placeholder.com/150"; }}
            />
            <h2>{product.name}</h2>
            <p>{product.description}</p>
            <p>Price: ${product.price}</p>
            <p>Color: {product.color}</p>

            <button onClick={handleAddToCart} className="btn btn-primary">
                Add to Cart
            </button>

            <button onClick={handleGoToCart} className="btn btn-secondary">
                Go to Cart
            </button>
        </div>
    );
};

export default ProductDetails;
