
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { Container, Label, Embed, Icon, Image } from "semantic-ui-react";

const Film = (props) => {

    // sauvegarde l'URL de base utilisée par l'API pour l'interrogation des images 
    var urlPhoto = "https://image.tmdb.org/t/p/w500";

    var txtGenres = "Genres : ";
    // stocker l'ID du film que nous avons passé dans les props.
    const alphacode = props.match.params.abc;
    /* stocke les éléments de recherche dans un tableau. Dans ce cas, nous utilisons deux tableaux
     pour rechercher et stocker les informations sur les films et un pour les bandes-annonces. */ 
    const [films, setFilms] = useState({});
    const [trailer, setTrailer] = useState({});


    useEffect(() => {

        fetch(`https://api.themoviedb.org/3/movie/${alphacode}?api_key=a314ab9ca59b6e5102484b318ab3cf1e`)
        // résultat de la valeur de l'appel movie fetch (JS promise).  
            .then((response) => response.json())
            .then((data) => setFilms(data))
            .catch((e) => console.log(e));

        fetch(`https://api.themoviedb.org/3/movie/${alphacode}/videos?api_key=a314ab9ca59b6e5102484b318ab3cf1e&language=en-US`)
        // résultat de la valeur de l'appel movie/videos fetch (JS promise). 
            .then((response) => response.json())
            .then((data) => setTrailer(data))
            .catch((e) => console.log(e));

        // chaque fois que nous avons un changement dans l'alphacode, nous allons avoir un appel API
    }, [alphacode]);
  
    //console.log(trailer);
    //Object.values  w3school   //  bitcoin  

    return (
        
        <Container>
            {/* nous utilisons des composants Semantic UI pour exprimer les valeurs trouvées et stockees dans notre recherche Films dans différents formats. */}
            <Container textAlign='center' >
                <h1>{films.title}</h1>
                <Image alt="film" src={urlPhoto + films.poster_path} size='medium' bordered spaced='center' />
            </Container>
            <br></br>
            <Container textAlign='justified'><b>Ouverview :</b>{films.overview}</Container>

            {/* Si notre film contient des genres, renvoyer les informations sur les genres en utilisant les composants de Semantic UI. */}
            <h2>{txtGenres}</h2> {films.genres ? films.genres.map((i) => <div> <Icon name='film' color="red" /><Label>{i.name}</Label>    </div>) : undefined}

            <br></br>
            {/* si notre tableau Trailer contient des informations, nous utilisons Semantic UI pour afficher les informations trouvées au format vidéo.  */}
            {trailer.results?
                <div>
                    <Label as='a' color='red' ribbon>
                        Bande-annonce
                    </Label>
                    <Embed
                        autoplay={false}
                        color='white'
                        hd={false}
                        id={trailer.results[0].key}
                        iframe={{
                            allowFullScreen: true,
                            style: {
                                padding: 10,
                            },
                        }}
                        source='youtube'
                    />
                </div>
                : undefined}

            <div>
            {/* s'il trouve des informations sur les sociétés de production, il renvoie les résultats trouvés au format html.  */}
                <br />  <h2> Entreprises de production: </h2>  {films.production_companies ? films.production_companies.map((i) =>

                    <div>
                        <div>
                            <p>  Nom :  {i.name}   </p>
                        </div>
                        <div>
                            <p> Pays d'origine : {i.origin_country} </p> <br />
                        </div>

                    </div>
                ) : undefined}
            </div>
        </Container>
    )
};

export default Film;

