import "./styleForBasicComponents.css"

interface TitleProps{
    title: string | null | undefined;
}

export default function Title({title} : TitleProps){
    return  <div className="title-container">
                <h2>{title}</h2>
            </div>
}