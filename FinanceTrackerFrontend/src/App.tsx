import './App.css'
import LoginPage from './pages/Login';
import RegisterPage from './pages/Register';
import DashboardPage from './pages/Dashboard';
import { Routes, Route } from "react-router-dom";

function App() {
  return (
    <>
      <Routes>
      {/* default route = entry page */}
      <Route path="/" element={<LoginPage />} />

      <Route path="/register" element={<RegisterPage />} />

      <Route path="/dashboard" element={<DashboardPage />} />
      
      </Routes>
    </>
  )
}

export default App


