import { useEffect } from "react";
import { useLocation } from "react-router-dom";

type RouteBg = "home" | "about" | "login" | "register" | "default";

function getRouteBg(pathname: string): RouteBg {
  if (pathname === "/" || pathname === "") return "home";
  if (pathname.startsWith("/about")) return "about";
  if (pathname.startsWith("/login")) return "login";
  if (pathname.startsWith("/register")) return "register";
  return "default";
}

export default function RouteBackground() {
  const location = useLocation();

  useEffect(() => {
    const body = document.body;

    body.classList.remove(
      "bg-home",
      "bg-about",
      "bg-login",
      "bg-register",
      "bg-default",
    );

    const bg = getRouteBg(location.pathname);
    body.classList.add(`bg-${bg}`);
  }, [location.pathname]);

  return null;
}
