import { useEffect, useState } from "react";
import "./CardComponent.css";

import CardItem from "./CardItem";
import type { Product } from "./types";
import { getProducts } from "./services/productService";

export default function CardComponent() {
  const [products, setProducts] = useState<Product[]>([]);
  const [favorites, setFavorites] = useState<string[]>([]);

  useEffect(() => {
    loadProducts();
  }, []);

  async function loadProducts() {
    try {
      const data = await getProducts();
      setProducts(data);
    } catch (error) {
      console.error("Erro ao buscar produtos:", error);
    }
  }

  function toggleFavorite(id: string) {
    setFavorites((prev) =>
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

  if (!products.length) {
    return <div>Loading...</div>;
  }

  return (
    <div className="box">
      <div className="container-card">
        {products.map((product) => (
          <CardItem
            key={product.id}
            product={product}
            isFavorite={favorites.includes(product.id)}
            onToggleFavorite={toggleFavorite}
            onShare={handleShare}
          />
        ))}
      </div>
    </div>
  );
}
