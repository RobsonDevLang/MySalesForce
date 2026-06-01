export interface Product {
  id: string;
  name: string;
  shortName?: string;
  conditionalId: string;
  category: string;
  description: string;
  height: number;
  width: number;
  length: number;
  weight: number;
  observations: string;
  sizes: string[];
  images: Images[];
  alt_text: string;
  price: number;
  historicalPrices: HistoricalPrice[];
}

export interface Images {
 url: string; 
 mainImage: boolean
 altText: string;
 }

export interface HistoricalPrice {
  price: number;
  startDate: string;
  endDate: string;
}