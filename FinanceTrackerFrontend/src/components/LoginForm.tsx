import { useRef } from "react";
import Button from '@mui/material/Button';
import { TextField } from "@mui/material";
import { ThemeProvider, createTheme } from '@mui/material/styles';
import { login } from "../api/auth";

const darkTheme = createTheme({
  palette: {
    mode: 'dark',
  },
});

export default function LoginForm() {
    const emailRef = useRef(null);
    const passwordRef = useRef(null);

    async function handleLogin() {
        const res = await login(emailRef.current.value, passwordRef.current.value)
        console.log(res);
    }

    return (
        <div className="
            p-4
            flex flex-col gap-4
            border-1 border-solid border-[#313131]
            bg-[#0f1214] rounded-xl
            w-full
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
            </ThemeProvider>

            <Button 
                variant="contained" 
                onClick={handleLogin}
                sx= {{ height: 45 }}
            >
                Login
            </Button>
        </div>
    );
}