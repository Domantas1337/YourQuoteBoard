import { Modal } from "antd";
import "./styleForBasicComponents.css";

// eslint-disable-next-line @typescript-eslint/no-explicit-any
export interface ButtonConfig<T = any>{
    label: string;
    onClick: (data: T) => void;
    data?: T;
    className: string;
}

interface ItemManagementModalProps{
    buttons: ButtonConfig[];
    title: string;
    isOpen: boolean;
    handleClose: () => void;
}

export default function ItemManagementModal({buttons, title, isOpen, handleClose} : ItemManagementModalProps){

    console.log("Buttons");
    console.log(buttons);
    return <div>
                <Modal className="button-modal" title={title} open={isOpen} onOk={handleClose} onCancel={handleClose}>
                    {
                        buttons.map( (button, index) =>
                            <button key={index} className={button.className} onClick={() => button.onClick(button?.data)}>
                                {button.label}
                            </button>
                        )
                    }
                </Modal>
            </div>
}