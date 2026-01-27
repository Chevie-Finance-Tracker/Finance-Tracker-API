import { useNavigate } from "react-router-dom";
import { motion } from "framer-motion";
import { ThemeProvider, createTheme } from '@mui/material/styles';
import { TextField } from "@mui/material";
import { useRef } from "react";
import Button from '@mui/material/Button';
import { useState } from "react";
import { login } from "../api/auth";
import InputAdornment from "@mui/material/InputAdornment";
import IconButton from '@mui/material/IconButton';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';

const darkTheme = createTheme({
  palette: {
    mode: 'dark',
  },
});

export default function LoginPage() {
    const navigate = useNavigate();

    const [showPassword, setShowPassword] = useState(false);
    
    const emailRef = useRef(null);
    const passwordRef = useRef(null);

    function handleClickShowPassword() {
        setShowPassword(!showPassword);
    }

    async function handleLogin() {
        // navigate("/dashboard");

        const res = await login(emailRef.current.value, passwordRef.current.value)
        console.log(res);
    }

    function goToRegister() {
        navigate("/register");
    }
    
    return (
        <>
            <motion.div 
                className="flex flex-col items-center justify-center min-h-screen -mt-10"
                initial={{ opacity: 0, y: 20 }}   // start hidden and slightly down
                animate={{ opacity: 1, y: 0 }}    // animate to fully visible and original position
                exit={{ opacity: 0, y: -20 }}     // when leaving, fade out and move up
                transition={{ duration: 0.3 }}    // how long the animation takes
            >
                <h1 className="mb-10">Lorem Ipsum!</h1>

                <div className="">
                    <div className="
                        flex flex-col gap-4
                        w-md
                        containercolor
                        containerround
                        "
                    >
                        <ThemeProvider theme={darkTheme}>
                            <TextField 
                                inputRef={emailRef}
                                id="standard-basic" 
                                label="Email" 
                                variant="outlined" 
                                color="info"
                            />

                            <TextField 
                                inputRef={passwordRef}
                                fullWidth
                                id="standard-basic" 
                                label="Password" 
                                variant="outlined" 
                                color="info"
                                type={showPassword ? "text" : "password"}
                                slotProps={{
                                    input: {
                                        endAdornment: (
                                            <InputAdornment position="end">
                                                <IconButton
                                                    aria-label={
                                                        showPassword ? 'hide the password' : 'display the password'
                                                    }
                                                    onClick={handleClickShowPassword}
                                                    edge="end"
                                                >
                                                    {showPassword ? <VisibilityOff /> : <Visibility />}
                                                </IconButton>
                                            </InputAdornment>
                                        )
                                    }
                                }}
                            />
                            <div className="text-right -mt-2">
                                <Button 
                                    size="small"
                                    sx={{
                                        color: "white",
                                        backgroundColor: "transparent",
                                    }}
                                >
                                    <p className="underline">Forgot Password</p>
                                </Button>
                            </div>
                        </ThemeProvider>
                        
                        <div className="mt-2">
                            <Button 
                                fullWidth
                                variant="contained" 
                                onClick={handleLogin}
                                sx= {{ height: 45 }}
                            >
                                Login
                            </Button>
                        </div>

                    </div>

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