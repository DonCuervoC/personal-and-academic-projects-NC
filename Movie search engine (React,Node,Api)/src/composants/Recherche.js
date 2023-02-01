import { useState } from "react";
import { Link } from "react-router-dom";
import { Button, Card, CardContent, CardHeader, Container, Image, Input, Label } from "semantic-ui-react";



const Recherche = (props) => {
    //représente la partie dynamique saisie par l'utilisateur
    const [nom, setNom] = useState("");
    // stocke les éléments de la recherche dans un tableau .
    const [films, setFilms] = useState([]);
    const [remp, setRemplir] = useState(false);

    // enregistre la CLÉ qui nous a été donnée par l'API afin que nous puissions l'utiliser. 
    var APIkey = "a314ab9ca59b6e5102484b318ab3cf1e";
    var filmPopu, urlPhoto,  filmNom;
    var sizeFilms = 0;

    const appelApi = () => {

        fetch(`https://api.themoviedb.org/3/search/movie?query=${nom}&api_key=${APIkey}`)
            // résultat de la valeur de l'appel fetch (JS promise). 
            .then((response) => response.json())
            .then((data) => setFilms(data))
            .then(() => setRemplir(true))
            .catch((erreur) => console.log(erreur));
    }

  /*Méthode qui utilise un Fetch pour renvoyer tous les enregistrements trouvés dans notre recherche et les renvoyer dans les composants de Semantic UI.  */
    const consoleResults = () => {
        return films.results.map((i) => {

            urlPhoto = "https://image.tmdb.org/t/p/w500" + i.poster_path;
            filmPopu = i.popularity;
            filmNom = i.original_title;
             sizeFilms ++;

            return (
                <Card key={i.id}>
                    <Image src={urlPhoto} fluid label={{ as: 'a', corner: 'left', icon: 'thumbs up', color: "red" }} />
                    <CardContent>
                        <CardHeader content={filmNom}/>
                    </CardContent>                    
                        <Card.Description content={"date de sortie  : " + i.release_date} />
                        <Card.Description content={"Popularité : " + filmPopu} />
                        <CardContent extra >
                        <Link to={`/film/${i.id}`}> Plus info </Link>
                        </CardContent>
                </Card>
            )
        })


    }


    return (
        <Container>
            <h1>Rechercher</h1>
            <Label pointing="right">Film</Label>
            <Input type="text" value={nom} onChange={(e) => setNom(e.target.value)}></Input>
            <Button onClick={appelApi}> Rechercher les films </Button>
            {/* <Button onClick={consoleResults}> Console Log </Button> */}

            <h2>Résultats de recherche</h2>
            {/* s'il trouve des résultats à notre recherche, nous utilisons la méthode consoleResults pour retourner l'information.  */}
            {remp ? `Il y a ${sizeFilms} résultat(s)` : undefined}
            <div style={{ display: "flex", alignItems: "center", justifyContent: "space-between", flexWrap: "wrap", width: "100%" }}>
                {remp ? consoleResults() : undefined}
                
            </div>
        </Container>

    )


};

export default Recherche;
