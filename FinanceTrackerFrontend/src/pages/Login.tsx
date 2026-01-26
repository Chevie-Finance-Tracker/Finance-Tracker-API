import LoginForm from "../components/LoginForm"
import { useNavigate } from "react-router-dom";
import { motion } from "framer-motion";

export default function LoginPage() {
    const navigate = useNavigate();

    function goToRegister() {
        navigate("/register");
    }
    
    return (
        <>
            <motion.div 
                className="flex flex-col items-center justify-center"
                initial={{ opacity: 0, y: 20 }}   // start hidden and slightly down
                animate={{ opacity: 1, y: 0 }}    // animate to fully visible and original position
                exit={{ opacity: 0, y: -20 }}     // when leaving, fade out and move up
                transition={{ duration: 0.3 }}    // how long the animation takes
            >
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

            </motion.div>
        </>
    )
}