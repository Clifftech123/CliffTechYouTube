import  { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom';
import { Product } from '../Interface/baseInterface';
import API from '../API/api';


export const ProductList = () => {
    const navigate = useNavigate();
    const [products, setProducts] = useState<Product[]>([]);
    const [loading, setLoading] = useState(true);



    const fetchProducts = async () => {
        try {
          const { data } = await API.get('/Product');
          setProducts(data);
          setLoading(false);
        } catch (error) {
          console.error('Error fetching products:', error);
          setLoading(false);
        }
      };


   
      const handleDelete = async (id: string) => {
        if (window.confirm('Are you sure you want to delete this product?')) {
          try {
            await API.delete(`/Product/${id}`);
            // Refresh the product list after deletion
            fetchProducts();
          } catch (error) {
            console.error('Error deleting product:', error);
          }
        }
      };
    


      useEffect(() => {
        fetchProducts();
      }, []);
    
      if (loading) {
        return (
          <div className="flex justify-center items-center min-h-screen">
            <div className="animate-spin rounded-full h-12 w-12 border-t-2 border-b-2 border-blue-500"></div>
          </div>
        );
      }



  return (
    <div className="container mx-auto px-4 py-8">
    <h1 className="text-3xl font-bold text-gray-800 mb-8">Our Products</h1>
    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
      {products.map((product) => (
        <div
          key={product.id}
          className="bg-white rounded-lg shadow-md overflow-hidden hover:shadow-lg transition-shadow duration-300"
        >
          <div className="p-6">
            <h2 className="text-xl font-semibold text-gray-800 mb-2">
              {product.name || 'Unnamed Product'}
            </h2>
            <p className="text-gray-600 mb-4">
              {product.description || 'No description available'}
            </p>
            <div className="flex justify-between items-center">
              <span className="text-2xl font-bold text-blue-600">
                ${product.price?.toFixed(2) || 'N/A'}
              </span>
               <button
                    onClick={() => navigate(`/product/${product.id}`)}
                    className="bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded-md"
                  >
                    View Details
                  </button>

                  

                  <button
                    onClick={() => handleDelete(product.id)}
                    className="bg-red-500 hover:bg-red-600 text-white px-4 py-2 rounded-md"
                  >
                    Delete
                  </button>
            </div>
          </div>
        </div>
      ))}
    </div>
  </div>
  )
}


 