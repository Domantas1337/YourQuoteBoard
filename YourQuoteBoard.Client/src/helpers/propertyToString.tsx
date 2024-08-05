export function getLabelOfProperty(propertyName: string){

    const propertyLabel : string[] = [];

    for (let i = 0; i < propertyName.length; ++i){
        if (i == 0){
            propertyLabel.push(propertyName.charAt(i).toUpperCase());
        }else if (propertyName.charAt(i) === propertyName.charAt(i).toUpperCase()){
            propertyLabel.push(" ");
            propertyLabel.push(propertyName.charAt(i));
        }else {
            propertyLabel.push(propertyName.charAt(i));
        }
    }

    return propertyLabel.join('');
}