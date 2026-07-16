import { IconButton } from "@mui/material";
import FavoriteIcon from "@mui/icons-material/Favorite";
import ShareIcon from "@mui/icons-material/Share";
import type { Product } from "../../types/product.types";
import "./CardItemComponent.css";
import { useState } from "react";
import ButtonComponent from "@/shared/components/ButtonComponent/ButtonComponent";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";

interface CardItemProps {
  product: Product;
  isFavorite: boolean;
  onToggleFavorite: (id: string) => void;
  onShare: (product: Product) => void;
}

export default function CardItemComponent({
  product,
  isFavorite,
  onToggleFavorite,
  onShare,
}: CardItemProps) {
  const [value, setValue] = useState<number>(0);

  const decrease = () => {
    if (value > 0) {
      setValue((prev) => Math.max(0, prev - 1));
    }
  };

  const increase = () => {
    setValue((prev) => prev + 1);
  };

  return (
    <div className="card">
      <div className="card-name">
        <IconButton
          aria-label="favoritar"
          onClick={() => onToggleFavorite(product.id)}
        >
          <FavoriteIcon className={isFavorite ? "active" : ""} />
        </IconButton>
        <h2 className="name">{product.shortName ?? product.name}</h2>
        <IconButton aria-label="compartilhar" onClick={() => onShare(product)}>
          <ShareIcon />
        </IconButton>
      </div>
      <div className="image-section">
        <div className="mini-image-container">
          {product.images.slice(1, 5).map((image, index) => (
            <div key={index} className="mini-image">
              <img src={image.url} alt={image.altText} />
            </div>
          ))}
        </div>

        <img
          className="image"
          src={product.images[0]?.url}
          alt={product.images[0]?.altText}
        />
      </div>
      <div className="info">
        <p
          className="description"
          dangerouslySetInnerHTML={{ __html: product.description }}
        />
        <div className="price-container">
          <span className="price">
            R$ {product.historicalPrices?.[0]?.price?.toFixed(2)}
          </span>

          <div className="actions-container">
            <div className="counter-container">
              <button onClick={decrease} className="counter-button">
                −
              </button>

              <span className="counter-value">{value}</span>

              <button onClick={increase} className="counter-button">
                +
              </button>
            </div>
            <ButtonComponent onClick={() => {}} className="AddCar">
              <AddShoppingCartIcon />
            </ButtonComponent>
          </div>
        </div>
      </div>
    </div>
  );
}
