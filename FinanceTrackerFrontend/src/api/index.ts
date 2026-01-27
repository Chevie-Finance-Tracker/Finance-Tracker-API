export const BASE_URL = import.meta.env.VITE_API_URL;

export async function apiFetch(endpoint: string, options: RequestInit = {}) {
  const stored = localStorage.getItem("authData")
  const authData = stored ? JSON.parse(stored) : null;

  const headers = {
        ...(options.headers || {}),
        ...(authData
            ? { Authorization: `${authData.tokenType} ${authData.accessToken}` }
            : {}),
        "Content-Type": "application/json",
  };

  const res = await fetch(`${BASE_URL}${endpoint}`, {
    ...options,
    headers
  });

  if (!res.ok) {
    throw new Error("API request failed");
  }

  return res.json();
}
