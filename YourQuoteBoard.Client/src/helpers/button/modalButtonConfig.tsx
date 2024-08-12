import { pingQuoteOwner } from "../../api/quote";
import { ButtonConfig } from "../../types/ButtonConfig";
import { ButtonRegistry } from "./ButtonFactory";



export async function getQuoteManagementButtons(buttonNames: string[], quoteId: string | undefined){

    if (quoteId == undefined){
        return [];
    }

    const buttonArray: ButtonConfig[] = [];

    for (const buttonName of buttonNames){
        if(buttonName == 'delete' && !(await checkQuoteOwnership(quoteId))){
            continue;
        }

        const btn = ButtonRegistry.getButtonConfig(buttonName, quoteId);

        if (btn){
            buttonArray.push(btn);
        }
    }

    return buttonArray;
}


async function checkQuoteOwnership(id: string){
    const isQuoteUsers: boolean = await pingQuoteOwner(id);
    return isQuoteUsers;
}

