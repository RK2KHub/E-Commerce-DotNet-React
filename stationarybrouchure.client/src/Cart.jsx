import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import './Cart.css';

const Cart = () => {
    const [cartItems, setCartItems] = useState([]);
    const navigate = useNavigate();
    const userId = 1; // Replace with the actual user ID from your authentication system

    useEffect(() => {
        const fetchCartItems = async () => {
            try {
                const response = await fetch(`https://localhost:5001/api/cart?userId=${userId}`);
                if (!response.ok) {
                    throw new Error('Error fetching cart items');
                }
                const data = await response.json();
                setCartItems(data);
            } catch (error) {
                console.error('Error:', error);
            }
        };

        fetchCartItems();
    }, []);

    const handleRemoveFromCart = async (productId) => {
        try {
            const response = await fetch(`https://localhost:5001/api/cart/remove/${productId}?userId=${userId}`, {
                method: 'POST',
            });
            if (!response.ok) throw new Error('Error removing item from cart');
            await fetchCartItems(); // Re-fetch cart items
        } catch (error) {
            console.error('Error removing item from cart:', error);
        }
    };

    const handleProceedToCheckout = async () => {
        try {
            const response = await fetch(`https://localhost:5001/api/cart/proceedToCheckout?userId=${userId}`, {
                method: 'POST',
            });
            if (response.ok) {
                navigate('/checkout-success');
            } else {
                throw new Error('Error during checkout');
            }
        } catch (error) {
            console.error('Error:', error);
        }
    };

    if (cartItems.length === 0) {
        return <p>Your cart is empty.</p>;
    }

    return (
        <div className="cart-container">
            <h2>Your Cart</h2>
            <table className="cart-table">
                <thead>
                    <tr>
                        <th>Product</th>
                        <th>Price</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {cartItems.map(item => (
                        <tr key={item.product.id}>
                            <td>{item.product.name}</td>
                            <td>${item.product.price.toFixed(2)}</td>
                            <td>
                                <button onClick={() => handleRemoveFromCart(item.product.id)} className="btn btn-danger">
                                    Remove
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <button onClick={handleProceedToCheckout} className="btn btn-primary checkout-button">
                Proceed to Checkout
            </button>
        </div>
    );
};

export default Cart;
