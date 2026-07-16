// useCategories.ts
import { useEffect, useState } from "react";
import { getCategorias } from "../services/product.service";
import type { Categoria } from "@/shared/components/CategoryComponent/CategoryComponent";

export function useCategories() {
  const [categorias, setCategorias] = useState<Categoria[]>([]);
  const [categoriaAtiva, setCategoriaAtiva] = useState<Categoria | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    loadCategorias();
  }, []);

  async function loadCategorias() {
    try {
      setLoading(true);
      const response = await getCategorias();
      setCategorias(response);
      if (response.length > 0) {
        setCategoriaAtiva(response[0].id === 0 ? response[1] : response[0]);
      }
    } catch (error) {
      console.error(error);
    } finally {
      setLoading(false);
    }
  }

  return {
    categorias,
    categoriaAtiva,
    setCategoriaAtiva,
    loading,
    reload: loadCategorias,
  };
}
