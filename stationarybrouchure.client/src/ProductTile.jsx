//import React from 'react';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';

const ProductTile = ({ product }) => {
    return (
        <div className="product-tile">
            <div className="product-info">
                <Link to={`/product/${product.Id}`} className="product-title">
                    {product.Title}
                </Link>
                <p className="product-description">{product.Description}</p>
                <p className="product-specs">{product.Specs}</p>
            </div>
        </div>
    );
};

ProductTile.propTypes = {
    product: PropTypes.shape({
        Id: PropTypes.number.isRequired,
        Title: PropTypes.string.isRequired,
        Description: PropTypes.string.isRequired,
        Specs: PropTypes.string.isRequired,
    }).isRequired,
};

export default ProductTile;
