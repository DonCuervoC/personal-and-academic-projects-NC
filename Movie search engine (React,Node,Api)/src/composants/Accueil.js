import { Container } from "semantic-ui-react";
import CategoModules from "./CategoModule";


const Accueil =()=>{

    return(
        
        <Container>
             <h1>Accueil</h1>
            <p>Bienvenue sur notre guide des films </p>
            <h2>Films d'action</h2>

            {/* nous utilisons des composants qui envoient comme props l'Id du genre de chaque film pour rechercher dans l'API et renvoyer tous les films liés à ce genre. */}
            <CategoModules filmid="28"/>  
            <h2>Comédie </h2>
            <CategoModules filmid="35"/>  
            <h2>Animation</h2>
            <CategoModules filmid="16"/>  
            <h2>Fantaisie </h2>
            <CategoModules filmid="14"/> 
            <br/><br/><br/>

            <h3 class="CopyRight">Copyright @Serrano&Cuervo CORP</h3>

        </Container>
    )
};
export default Accueil;