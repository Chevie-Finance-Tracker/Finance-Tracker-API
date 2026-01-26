import LoginForm from "../components/LoginForm"
import { useNavigate } from "react-router-dom";

export default function LoginPage() {
    const navigate = useNavigate();

    function goToRegister() {
        navigate("/register");
    }
    
    return (
        <>
        <div ></div>
            <div className="flex flex-col items-center justify-center">
                <h1 className="mb-10">Lorem Ipsum!</h1>

                <div className="w-full max-w-md">
                    <LoginForm /> 
                    <div className="mt-2">
                        <span className="mr-1">
                            Don't have an account? 
                        </span>
                        <button onClick={goToRegister} className="cursor-pointer underline">
                            Sign Up
                        </button>
                    </div>
                </div>

            </div>
        </>
    )
}