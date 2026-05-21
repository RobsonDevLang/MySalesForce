import { IconButton } from "@mui/material";
import FavoriteIcon from "@mui/icons-material/Favorite";
import ShareIcon from "@mui/icons-material/Share";
import type { Product } from "./types";

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
        <span className="price">{product.price}</span>
      </div>
    </div>
  );
}
