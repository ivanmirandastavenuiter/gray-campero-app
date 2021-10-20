import { CartStatus } from "../enums/cart-status";

export interface Cart {
    cartId: number;
    userId: number;
    productId: number;
    quantity: number;
    status: CartStatus;
}