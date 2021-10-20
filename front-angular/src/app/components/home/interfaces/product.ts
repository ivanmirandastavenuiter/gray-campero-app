export interface Product {
    productId: number;
    name: string;
    description: string;
    price: number;
    stock: number;
    urlPath: string;
    currentQuantity: number;
    disabled: boolean;
}