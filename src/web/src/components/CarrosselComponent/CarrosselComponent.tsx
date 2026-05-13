const produtos = [
  {
    id: 1,
    nome: "Produto 1",
    imagem: "https://via.placeholder.com/150",
    preco: 100,
  },
  {
    id: 2,
    nome: "Produto 2",
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
            <img src={produto.imagem} alt={produto.nome} />
            <h3>{produto.nome}</h3>
            <p>R$ {produto.preco}</p>
          </div>
        );
      })}
    </>
  );
}
