import { FormGroup, Validator } from "@angular/forms";
import { Injectable } from "@angular/core";

@Injectable({providedIn:'root'})
export class MatchPassword implements Validator {
    validate(formGroup:FormGroup){
        const{ password,passwordConfirmation}=formGroup.value;
        return  password===passwordConfirmation?{passwordsDontMatch:false}:{passwordsDontMatch:true};
    }
}
