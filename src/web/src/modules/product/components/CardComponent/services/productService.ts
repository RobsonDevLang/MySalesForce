import axios from "axios";
import type { Product } from "../types";

export async function getProducts(): Promise<Product[]> {
  const response = await axios.get<Product[]>("/product.json");

  return response.data;
}
