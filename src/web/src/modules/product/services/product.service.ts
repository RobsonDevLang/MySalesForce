import axios from "axios";
import type { Product } from "../types/product.types";
const VITE_API_URL_PRODUCT = import.meta.env.VITE_API_URL_PRODUCT;

export async function getProducts(id: number): Promise<Product[]> {
  const response = await axios.get<Product[]>(
    VITE_API_URL_PRODUCT + "/product/active/" + id,
  );
  return response.data;
}

export async function getCategorias(): Promise<{ id: number; name: string }[]> {
  const response = await axios.get<{ id: number; name: string }[]>(
    VITE_API_URL_PRODUCT + "/product/category",
  );
  return response.data;
}
