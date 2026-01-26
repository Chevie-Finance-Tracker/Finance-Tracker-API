import './App.css'
import LoginPage from './pages/Login';
import RegisterPage from './pages/Register';
import { Routes, Route } from "react-router-dom";

function App() {
  return (
    <>
      <Routes>
      {/* default route = entry page */}
      <Route path="/" element={<LoginPage />} />

      <Route path="/register" element={<RegisterPage />} />
      
      </Routes>
    </>
  )
}

export default App


