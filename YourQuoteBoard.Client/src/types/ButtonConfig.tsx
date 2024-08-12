// eslint-disable-next-line @typescript-eslint/no-explicit-any
export interface ButtonConfig<T = any>{
    label: string;
    onClick: (data: T) => void;
    data?: T;
    className: string;
}