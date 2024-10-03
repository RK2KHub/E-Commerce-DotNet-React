import React from 'react';
import ReactDOM from 'react-dom/client'; // Assuming you're using React 18
import App from './App.jsx'; // Add the .jsx extension
import './index.css'; // Assuming you have a CSS file to import

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <React.StrictMode>
        <App />
    </React.StrictMode>
);
