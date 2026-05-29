import "./CardComponent.css";

import CardItemComponent from "@/modules/product/components/CardItemComponent/CardItemComponent";
import { useProducts } from "@/modules/product/hooks/useProduct";
import { useFavorite } from "@/modules/product/hooks/useFavorite";

export default function CardComponent() {
  const { products, loading } = useProducts();

  const { favorites, toggleFavorite, handleShare } = useFavorite();
  if (!products.length) {
    return <div>Loading...</div>;
  }

  return (
    <div className="box">
      <div className="container-card">
        {products.map((product) => (
          <CardItemComponent
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
