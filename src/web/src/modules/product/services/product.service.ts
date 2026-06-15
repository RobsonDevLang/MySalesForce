import axios from "axios";
import type { Product } from "../types/product.types";
const VITE_API_URL_PRODUCT = import.meta.env.VITE_API_URL_PRODUCT;

export async function getProducts(): Promise<Product[]> {
  const response = await axios.get<Product[]>(
    VITE_API_URL_PRODUCT + "/product/active",
  );
  return response.data;
}
