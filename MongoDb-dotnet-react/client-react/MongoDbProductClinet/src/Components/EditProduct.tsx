import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import API from "../API/api";
import { Product } from "../Interface/baseInterface";

export const EditProduct = () => {

    const { id } = useParams();
   
    const navigate = useNavigate();

   
    
  const [formData, setFormData] = useState<Product>({
    id: '',
    name: '',
    description: '',
    price: 0
  });
  const [loading, setLoading] = useState(true);

 

    useEffect(() => {
        fetchProduct();
      }, [id]);

    
      const fetchProduct = async () => {
        try {
          const { data } = await API.get(`/Product/${id}`);
          setFormData(data);
          setLoading(false);
        } catch (error) {
          console.error('Error fetching product:', error);
          setLoading(false);
        }
      };
   

      const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
          await API.put(`/Product/${id}`, formData);
          navigate(`/product/${id}`);
        } catch (error) {
          console.error('Error updating product:', error);
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
    <div className="max-w-2xl mx-auto px-4 py-8">
    <div className="bg-white rounded-lg shadow-lg p-6">
      <h2 className="text-2xl font-bold text-gray-800 mb-6">Edit Product</h2>
      <form onSubmit={handleSubmit} className="space-y-4">
        <div>
          <label className="block text-gray-700 mb-2">Name</label>
          <input
            type="text"
            value={formData.name}
            onChange={(e) => setFormData({...formData, name: e.target.value})}
            className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
            required
          />
        </div>
        <div>
          <label className="block text-gray-700 mb-2">Description</label>
          <textarea
            value={formData.description}
            onChange={(e) => setFormData({...formData, description: e.target.value})}
            className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
            rows={4}
            required
          />
        </div>
        <div>
          <label className="block text-gray-700 mb-2">Price</label>
          <input
            type="number"
            value={formData.price}
            onChange={(e) => setFormData({...formData, price: Number(e.target.value)})}
            className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
            required
          />
        </div>
        <div className="flex space-x-4">
          <button
            type="submit"
            className="bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded-md"
          >
            Update Product
          </button>
          <button
            type="button"
            onClick={() => navigate(`/product/${id}`)}
            className="bg-gray-500 hover:bg-gray-600 text-white px-4 py-2 rounded-md"
          >
            Cancel
          </button>
        </div>
      </form>
    </div>
  </div>
  )
}
