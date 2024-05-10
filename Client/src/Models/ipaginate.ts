import { IProduct } from "./iproduct";

export interface IPaginate<T> {
  "pageIndex": number,
  "pageSize": number,
  "count": number,
  "data": T[]

}
