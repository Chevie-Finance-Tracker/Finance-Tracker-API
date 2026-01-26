import RegisterForm from "../components/RegisterForm";
import { motion } from "framer-motion";

export default function RegisterPage() {
    return (
        <motion.div
            initial={{ opacity: 0, y: 20 }}   // start hidden and slightly down
            animate={{ opacity: 1, y: 0 }}    // animate to fully visible and original position
            exit={{ opacity: 0, y: -20 }}     // when leaving, fade out and move up
            transition={{ duration: 0.3 }}    // how long the animation takes
        >
            <RegisterForm />
        </motion.div>
    );
}