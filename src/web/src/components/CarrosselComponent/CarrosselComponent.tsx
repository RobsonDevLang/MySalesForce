const produtos = [
  {
    id: 1,
    name: "Produto 1",
    imagem: "https://via.placeholder.com/150",
    preco: 100,
  },
  {
    id: 2,
    name: "Produto 2",
    imagem: "https://via.placeholder.com/150",
    preco: 200,
  },
];
export default function CarrosselComponent() {
  return (
    <>
      {produtos.map((produto) => {
        return (
          <div key={produto.id} className="produto-card">
            <img src={produto.imagem} alt={produto.name} />
            <h3>{produto.name}</h3>
            <p>R$ {produto.preco}</p>
          </div>
        );
      })}
    </>
  );
}
