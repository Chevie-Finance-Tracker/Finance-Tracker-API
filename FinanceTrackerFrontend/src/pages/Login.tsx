import LoginForm from "../components/LoginForm"
import { useNavigate } from "react-router-dom";

export default function LoginPage() {
    const navigate = useNavigate();

    function goToRegister() {
        navigate("/register");
    }
    
    return (
        <>
            <LoginForm /> 
            <div className="mt-2">
                <button onClick={goToRegister} className="cursor-pointer underline">
                    Sign Up
                </button>
            </div>
            
        </>
    )
}