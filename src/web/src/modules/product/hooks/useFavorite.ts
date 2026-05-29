import { useState } from "react";
import type { Product } from "../types/product.types";

export function useFavorite() {
  const [favorite, setFavorite] = useState<string[]>([]);

  function toggleFavorite(id: string) {
    setFavorite((prev) =>
      prev.includes(id)
        ? prev.filter((itemId) => itemId !== id)
        : [...prev, id],
    );
  }

  async function handleShare(product: Product) {
    if (!navigator.share) {
      alert("Seu navegador não suporta compartilhamento");
      return;
    }

    try {
      await navigator.share({
        title: product.name,
        text: product.description,
        url: window.location.href,
      });

      console.log("Compartilhado com sucesso");
    } catch (error) {
      console.log("Erro ao compartilhar", error);
    }
  }

  return { favorites: favorite, toggleFavorite, handleShare };
}
