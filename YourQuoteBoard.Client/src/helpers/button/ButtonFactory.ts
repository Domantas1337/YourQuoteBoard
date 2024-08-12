import { ButtonConfig } from "../../types/ButtonConfig";

type ButtonFactory<Type> = (data: Type) => ButtonConfig<Type>;

export class ButtonRegistry{

    private static registry: Map<string, ButtonFactory<unknown>> = new Map();

    public static registerButton<Type>(key: string, factory: ButtonFactory<Type>) : void{
        this.registry.set(key, factory as ButtonFactory<unknown>);
    }

    public static getButtonConfig<Type>(key: string, data: Type): ButtonConfig<Type> | undefined{
        const factory = this.registry.get(key) as ButtonFactory<Type>;
        return factory ? factory(data) : undefined;
    }
}