
interface NumberOfItemsProps{
    itemName: string;
    listLength: number;
}

export default function NumberOfItems({itemName, listLength} : NumberOfItemsProps){
    return <div className="number-of-items-container">
            {
                listLength === 1 ? (
                    <span>There is 1 {itemName} in this folder.</span>
                ) :
                (
                    <span>There are {itemName}s  in this folder.</span>
                )
            }
            </div>
}