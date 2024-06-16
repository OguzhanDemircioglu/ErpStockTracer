export class ProductModel{
  id!: string;
  name!: string;
  type: ProductTypeEnum = new ProductTypeEnum();
  typeValue: number= 1;
  quantity!:number;
}

export class ProductTypeEnum{
  name!: string;
  value!: number;
}

export const productTypes: ProductTypeEnum[] = [
  {
    name: "Mamül",
    value: 1
  },{
    name: "Yarı Mamül",
    value: 2
  },
]
