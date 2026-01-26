import { useRef } from "react";
import Button from '@mui/material/Button';
import { TextField } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { ThemeProvider, createTheme } from '@mui/material/styles';
import { login } from "../api/auth";

const darkTheme = createTheme({
  palette: {
    mode: 'dark',
  },
});

export default function LoginForm() {
    const navigate = useNavigate();

    const emailRef = useRef(null);
    const passwordRef = useRef(null);

    async function handleLogin() {
        setTimeout(() => {
            navigate("/dashboard");
        }, 500); // matches animation duration

        // const res = await login(emailRef.current.value, passwordRef.current.value)
        // console.log(res);
    }

    return (
        <div className="
            flex flex-col gap-4
            w-md
            container
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
                    type="password"
                />
                <div className="text-right">
                    <Button 
                        size="small"
                        sx={{
                            color: "white"
                        }}
                    >
                        Forgot Password
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
    );
}