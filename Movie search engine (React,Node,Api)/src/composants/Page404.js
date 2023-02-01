import { Redirect } from "react-router-dom";

// si aucun résultat n'est trouvé, nous sommes redirigés vers la page principale. 
const Page404 = () => {
    return (<Redirect to="/" />)
};
export default Page404;