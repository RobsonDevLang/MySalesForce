import "./CardComponent.css";

import CardItemComponent from "@/modules/product/components/CardItemComponent/CardItemComponent";
import { useProducts } from "@/modules/product/hooks/useProduct";
import { useFavorite } from "@/modules/product/hooks/useFavorite";
import CircularProgress from "@mui/material/CircularProgress";

interface CardComponentProps {
  categoriaAtiva: string;
  categoriaId: number;
}

export default function CardComponent({ categoriaId }: CardComponentProps) {
  const { products, loading } = useProducts(categoriaId);
  const { favorites, toggleFavorite, handleShare } = useFavorite();

  if (loading) {
    return (
      <div className="box">
        <div className="container-card">
          <div className="card loading-card">
            <CircularProgress color="secondary" aria-label="Loading…" />
          </div>
        </div>
      </div>
    );
  }

  return (
    <div className="box">
      <div className="container-card">
        {products.length > 0 ? (
          products.map((product) => (
            <CardItemComponent
              key={product.id}
              product={product}
              isFavorite={favorites.includes(product.id)}
              onToggleFavorite={toggleFavorite}
              onShare={handleShare}
            />
          ))
        ) : (
          <p>Nenhum produto encontrado nessa categoria.</p>
        )}
      </div>
    </div>
  );
}
