import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Product } from "../Interface/baseInterface";
import API from "../API/api";


const ProductDetail = () => {

    const {id} = useParams();


    const navigate = useNavigate();

    const [product, setProduct] = useState<Product | null>(null);
    const [loading, setLoading] = useState(true);
  

    useEffect(() => {
        fetchProduct();
      }, [id]);

    
      const fetchProduct = async () => {
        try {
          const { data } = await API.get(`/Product/${id}`);
          setProduct(data);
          setLoading(false);
        } catch (error) {
          console.error('Error fetching product:', error);
          setLoading(false);
        }
      };
   
      const handleDelete = async () => {
        if (window.confirm('Are you sure you want to delete this product?')) {
          try {
            await API.delete(`/Product/${id}`);
            navigate('/');
          } catch (error) {
            console.error('Error deleting product:', error);
          }
        }
      };
    
      if (loading) {
        return (
          <div className="flex justify-center items-center min-h-screen">
            <div className="animate-spin rounded-full h-12 w-12 border-t-2 border-b-2 border-blue-500"></div>
          </div>
        );
      }
    



  return (
    <div className="max-w-4xl mx-auto px-4 py-8">
    <div className="bg-white rounded-lg shadow-lg p-6">
      <h1 className="text-3xl font-bold text-gray-800 mb-4">{product?.name}</h1>
      <p className="text-gray-600 mb-4">{product?.description}</p>
      <div className="text-2xl font-bold text-blue-600 mb-6">
        ${product?.price?.toFixed(2)}
      </div>
      <div className="flex space-x-4">
        <button
          onClick={() => navigate('/')}
          className="bg-gray-500 hover:bg-gray-600 text-white px-4 py-2 rounded-md"
        >
          Back to List
        </button>
        <button
          onClick={() => navigate(`/edit-product/${id}`)}
        className="bg-green-500 hover:bg-green-600 text-white px-4 py-2 rounded-md"
             >
           Edit Product
           </button>
        <button
          onClick={handleDelete}
          className="bg-red-500 hover:bg-red-600 text-white px-4 py-2 rounded-md"
        >
          Delete Product
        </button>
      </div>
    </div>
  </div>
  )
}

export default ProductDetail