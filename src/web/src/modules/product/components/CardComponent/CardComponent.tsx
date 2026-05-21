import { useEffect, useState } from "react";
import axios from "axios";
import "./CardComponent.css";
import { IconButton } from "@mui/material";
import FavoriteIcon from "@mui/icons-material/Favorite";
import ShareIcon from "@mui/icons-material/Share";

interface Product {
  id: string;
  name: string;
  oldPrice?: string;
  price: string;
  image: string;
  description: string;
}

export default function CardComponent() {
  const [products, setProducts] = useState<Product[]>([]);
  const [favorites, setFavorites] = useState<string[]>([]);

  useEffect(() => {
    loadProducts();
  }, []);

  async function loadProducts() {
    try {
      const response = await axios.get<Product[]>(
        "http://localhost:5173/src/assets/product.json",
      );

      setProducts(response.data);
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
        {products.map((product) => {
          const isFavorite = favorites.includes(product.id);

          return (
            <div className="card" key={product.id}>
              <div className="card-name">
                <IconButton
                  aria-label="favoritar"
                  onClick={() => toggleFavorite(product.id)}
                >
                  <FavoriteIcon className={isFavorite ? "active" : ""} />
                </IconButton>

                <h2 className="name">{product.name}</h2>

                <IconButton
                  aria-label="compartilhar"
                  onClick={() => handleShare(product)}
                >
                  <ShareIcon />
                </IconButton>
              </div>

              <img className="image" src={product.image} alt={product.name} />

              <div className="info">
                <p className="description">{product.description}</p>

                <span className="price">{product.price}</span>
              </div>
            </div>
          );
        })}
      </div>
    </div>
  );
}
