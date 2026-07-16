import { useEffect, useRef, useState } from "react";

import { getProducts } from "../services/product.service";
import type { Product } from "../types/product.types";

export function useProducts(categoryId: number) {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);
  const cache = useRef<Record<number, Product[]>>({});

  useEffect(() => {
    loadProducts(categoryId);
  }, [categoryId]);

  async function loadProducts(id: number) {
    if (cache.current[id]) {
      setProducts(cache.current[id]);
      setLoading(false);
      return;
    }

    try {
      setLoading(true);

      const data = await getProducts(id);

      cache.current[id] = data;
      setProducts(data);
    } catch (error) {
      console.error("Erro ao buscar produtos:", error);
    } finally {
      setLoading(false);
    }
  }

  return {
    products,
    loading,
  };
}
