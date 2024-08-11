import { Modal } from "antd";

// eslint-disable-next-line @typescript-eslint/no-explicit-any
export interface ButtonConfig<T = any>{
    label: string;
    onClick: (data: T) => void;
    data?: T;
}

interface ItemManagementModalProps{
    buttons: ButtonConfig[];
    title: string;
    isOpen: boolean;
    handleClose: () => void;
}

export default function ItemManagementModal({buttons, title, isOpen, handleClose} : ItemManagementModalProps){

    return <div>
        <Modal title={title} open={isOpen} onOk={handleClose} onCancel={handleClose}></Modal>
            {
                buttons.map( (button, index) =>
                    <button key={index} onClick={() => button.onClick(button?.data)}>
                        {button.label}
                    </button>
                )
            }
        </Modal>
    </div>
}