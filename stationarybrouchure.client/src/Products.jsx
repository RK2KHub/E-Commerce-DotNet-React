import { useEffect, useState } from 'react';
import ProductTile from './ProductTile';

const Products = () => {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    // Fetch products from the backend API
    fetch('https://localhost:5001/api/products')
      .then(response => response.json())
      .then(data => setProducts(data))
      .catch(error => console.error('Error fetching products:', error));
  }, []);

  return (
    <div className="products-container">
      {products.map((product) => (
        <ProductTile key={product.id} product={product} />
      ))}
    </div>
  );
};

export default Products;
