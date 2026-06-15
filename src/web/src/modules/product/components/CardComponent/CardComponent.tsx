import "./CardComponent.css";

import CardItemComponent from "@/modules/product/components/CardItemComponent/CardItemComponent";
import { useProducts } from "@/modules/product/hooks/useProduct";
import { useFavorite } from "@/modules/product/hooks/useFavorite";

interface CardComponentProps {
  categoriaAtiva: string;
}

export default function CardComponent({ categoriaAtiva }: CardComponentProps) {
  const { products } = useProducts();
  const { favorites, toggleFavorite, handleShare } = useFavorite();
  if (!products.length) {
    return <div>Loading...</div>;
  }

  const produtosFiltrados =
    categoriaAtiva === "Todos"
      ? products
      : products.filter(
          (p) => p.category?.toLowerCase() === categoriaAtiva.toLowerCase(),
        );

  return (
    <div className="box">
      <div className="container-card">
        {produtosFiltrados.length > 0 ? (
          produtosFiltrados.map((product) => (
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
