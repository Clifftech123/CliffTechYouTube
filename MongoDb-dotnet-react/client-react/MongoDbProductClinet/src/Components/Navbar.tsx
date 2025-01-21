
import { Link } from 'react-router-dom'

const Navbar = () => {
  return (
    <nav className="bg-white shadow-lg">
      <div className="max-w-7xl mx-auto px-4">
        <div className="flex justify-between h-16">
          <div className="flex items-center">
            <Link to="/" className="text-xl font-bold text-gray-800">
              Product Store
            </Link>
          </div>
          <div className="flex items-center">
            <Link
              to="/create-product"
              className="bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded-md"
            >
              Add New Product
            </Link>
          </div>
        </div>
      </div>
    </nav>
  )
}

export default Navbar