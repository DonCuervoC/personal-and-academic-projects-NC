import {  useEffect, useState } from "react";
import { Link } from "react-router-dom";
import {  CardContent, Card, Image,  Icon } from "semantic-ui-react";


const CategoModules = (props) => {
    // stocker l'ID du film que nous avons passé dans les props. 
    var catCode = props.filmid;
    // stocke les éléments de la recherche dans un tableau .
    const [films, setFilms] = useState({}); 
    // sauvegarde l'URL de base utilisée par l'API pour l'interrogation des images 
    var urlPhoto = "https://image.tmdb.org/t/p/w500";
    // fait appel à l'API
    useEffect(() => {
        fetch(
            `https://api.themoviedb.org/3/discover/movie?sorty_by=popularity,desc&api_key=a314ab9ca59b6e5102484b318ab3cf1e&with_genres=${catCode}`
        )
        // résultat de la valeur de l'appel fetch (JS promise). 
            .then((response) => response.json())
            .then((data) => setFilms(data))
            .catch((e) => console.log(e));
        // chaque fois que nous avons un changement dans l'alphacode, nous allons avoir un appel API
    }, [catCode]);

    console.log(films.results);

    return (

        <div>
            <div className="flex-container">
                <div className="content">
                {/* S'il trouve des données dans notre tableau, avec fetch nous allons chercher toutes les données stockées dans le tableau.  */}
                    {films.results ? films.results.map((i) =>
                        <div className="divCard" >
                        {/* nous utilisons des composants Semantic UI pour exprimer les valeurs trouvées dans notre recherche dans différents formats. */}
                            <Card raised key={i.id} className="divCard" >
                                <Image src={urlPhoto + i.poster_path} fluid label={{ as: 'a', corner: 'left', icon: 'heart', color: "red" }} wrapped ui={true} />
                                <CardContent style={{ justifyContent: "center", alignItems: "center" }}  >
                                    <Card.Header content={i.title} />
                                </CardContent>
                                <Card.Content extra >
                                    <a>                                       
                                        <Icon name='heart' color="red" />{i.vote_average}
                                    </a>
                                </Card.Content>
                                <CardContent extra >
                                    <Card.Meta style={{ justifyContent: "center", alignItems: "center" }}>
                                        <Link to={`/film/${i.id}`} style={{ backgroundColor: "snow", alignItems: "center", textJustify: "center" }}>Plus info </Link>
                                    </Card.Meta>
                                </CardContent>

                            </Card>
                            <br />

                        </div>) : undefined}

                </div>
            </div>
        </div >
    );
};

export default CategoModules;
