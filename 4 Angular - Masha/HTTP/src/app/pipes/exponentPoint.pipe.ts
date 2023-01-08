import { Pipe, PipeTransform } from "@angular/core";

@Pipe({name: 'exponent'})
class ExponentPointPipe implements PipeTransform {
    transform(number: number, stength?: number) {
        if(stength){
            return Math.pow(number, stength);
        }
        else {
            return Math.pow(number, 2);
        }
    }

}

export default ExponentPointPipe;