class Product {
    //id: number;
    //name: string;
    //publish: Date;
    //image: string; 
    //price: number;


    //description: string;
    //productLocation: string;
    //sellerPhone: string;

    constructor(public id:number = 0, public name:string = "", public publish:Date = new Date, public image:string = "", 
    public price:number = 0, public description:string = "", public productLocation:string = "", public sellerPhone:string = ""){} 
}

export default Product;