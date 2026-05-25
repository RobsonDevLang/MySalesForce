import { IconButton } from "@mui/material";
import FavoriteIcon from "@mui/icons-material/Favorite";
import ShareIcon from "@mui/icons-material/Share";
import type { Product } from "./types";
import "./CardItem.css";
import { useState } from "react";
import ButtonComponent from "@/shared/components/ButtonComponent/ButtonComponent";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";

interface CardItemProps {
  product: Product;
  isFavorite: boolean;
  onToggleFavorite: (id: string) => void;
  onShare: (product: Product) => void;
}

export default function CardItem({
  product,
  isFavorite,
  onToggleFavorite,
  onShare,
}: CardItemProps) {
  const [value, setValue] = useState<number>(0);

  const decrease = () => {
    if (value > 0) {
      setValue(value - 1);
    }
  };

  const increase = () => {
    setValue(value + 1);
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
        <h2 className="name">{product.name}</h2>
        <IconButton aria-label="compartilhar" onClick={() => onShare(product)}>
          <ShareIcon />
        </IconButton>
      </div>
      <img className="image" src={product.image} alt={product.name} />
      <div className="info">
        <p className="description">{product.description}</p>
        <div className="price-container">
          <span className="price">R$ {product.price}</span>

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
