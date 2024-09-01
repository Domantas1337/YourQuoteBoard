import { StarFilled } from '@ant-design/icons';
import { Col } from 'antd';
import "./favorite.css";

interface FavoritesFolderProps{
    onClick: () => void;
}

export default function FavoritesFolder({onClick} : FavoritesFolderProps){
    return  <Col className="gutter-row" xs={24} sm={12} md={8} lg={6} onClick={onClick}>
                    <div className="folder-container">
                        <StarFilled className="favorite-folder-icon" name='Name' />
                        <button type="submit" className="favorite-button" >Favorites</button>
                    </div>
            </Col>  
}