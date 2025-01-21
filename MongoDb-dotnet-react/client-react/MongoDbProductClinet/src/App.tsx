import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Navbar from "./Components/Navbar"

import ProductDetail from "./Components/ProductDetail"
import { CreateProduct } from "./Components/CreateProduct"
import { EditProduct } from "./Components/EditProduct"
import { ProductList } from './Components/ProductList';



function App() {
  return (
    <Router>
    <div className="min-h-screen bg-gray-100">
      <Navbar />
      <Routes>
        <Route path="/" element={<ProductList />} />
        <Route path="/product/:id" element={<ProductDetail />} />
        <Route path="/create-product" element={<CreateProduct />} />
        <Route path="/edit-product/:id" element={<EditProduct />} />
      </Routes>
    </div>
  </Router>
  );
}

export default App;
