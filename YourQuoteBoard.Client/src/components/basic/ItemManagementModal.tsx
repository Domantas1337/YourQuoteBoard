import { Modal } from "antd";
import "./styleForBasicComponents.css";
import { ButtonConfig } from "../../types/ButtonConfig";

interface ItemManagementModalProps{
    buttons: ButtonConfig[];
    title: string;
    isOpen: boolean;
    handleClose: () => void;
}

export default function ItemManagementModal({buttons, title, isOpen, handleClose} : ItemManagementModalProps){

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