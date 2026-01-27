import { apiFetch } from "."

export function getSpendings() {
  return apiFetch("/api/Spendings", {
    method: "GET",
  });
}