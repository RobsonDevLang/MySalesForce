import { useState, useRef } from "react";
import "./CarouselComponent.css";
import { useEffect } from "react";
import ButtonComponent from "../../../../shared/components/ButtonComponent/ButtonComponent";

export default function CarrosselComponent() {
  // useEffect(() => {
  //   const carousel = document.querySelector(".carousel");
  //   let isDown = false;
  //   let startX: number;
  //   let scrollLeft: number;
  //   carousel?.addEventListener("mousedown", (e) => {
  //     isDown = true;
  //     startX = e.pageX - carousel.offsetLeft;
  //     scrollLeft = carousel.scrollLeft;
  //   });
  //   carousel?.addEventListener("mouseleave", () => {
  //     isDown = false;
  //   });
  //   carousel?.addEventListener("mouseup", () => {
  //     isDown = false;
  //   });
  //   carousel?.addEventListener("mousemove", (e) => {
  //     if (!isDown) return;
  //     e.preventDefault();
  //     const x = e.pageX - carousel.offsetLeft;
  //     const walk = (x - startX) * 3; //scroll-fast
  //     carousel.scrollLeft = scrollLeft - walk;
  //   });
  // }, []);

  const [product, setproduct] = useState([]);
  const carrouselRef = useRef(null as unknown as HTMLDivElement);

  useEffect(() => {
    fetch("http://localhost:5173/src/assets/product.json").then((response) => {
      response.json().then(setproduct);
    });
  }, []);

  const handleLeftClick = () => {
    if (carrouselRef.current) {
      carrouselRef.current.scrollLeft -= carrouselRef.current.offsetWidth;
    }
  };

  const handleRightClick = () => {
    if (carrouselRef.current) {
      carrouselRef.current.scrollLeft += carrouselRef.current.offsetWidth;
    }
  };

  if (!product || !product.length) return <div>Loading...</div>;

  return (
    <>
      <div className="container">
        <div className="carousel" ref={carrouselRef}>
          {product.map((item) => {
            const { id, name, oldPrice, price, image } = item;

            return (
              <div className="item" key={id}>
                <div className="image">
                  <img src={image} alt={name} />

                  <div className="info">
                    <span className="name">{name}</span>
                    <span className="oldPrice">R$ {oldPrice}</span>
                    <span className="price">R$ {price}</span>
                  </div>
                </div>
              </div>
            );
          })}
        </div>

        <div className="buttons">
          <ButtonComponent className="scroll-left" onClick={handleLeftClick}>
            <img src="./src/assets/flecha.png" alt="Scroll left" />
          </ButtonComponent>

          <ButtonComponent className="scroll-right" onClick={handleRightClick}>
            <img src="./src/assets/flecha.png" alt="Scroll right" />
          </ButtonComponent>
        </div>
      </div>
    </>
  );
}
