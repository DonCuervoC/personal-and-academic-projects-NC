
Composant : FormInscript
URL - Routing : http://localhost:3000/FormInscript ou host/FormInscript  

Technologies utilisées : Next.Js, React.

Bibliothèques : Semantic Ui. 
  		- installation :  $  npm install semantic-ui-react semantic-ui-css
			
		      >	Après l'installation, importez le fichier CSS minifié dans le fichier d'entrée de votre application :
			- import 'semantic-ui-css/semantic.min.css'

structure logique du composant :

	Nous utilisons le concept de Hooks pour changer les états de nos composants ainsi que leur cycle de vie,
	types de Hooks :
		1. les chaînes de caractères qui sont les données que l'utilisateur choisit ou saisit à travers différentes entrées.
		2. des booléens qui indiquent quand je dois passer d'une page à l'autre, ils sont utilisés pour indiquer le cycle de vie de chaque section du formulaire.
		3. numériques : on les utilise pour contrôler les conditions données par le formulaire, exemple : Forces de travail en équipe, nombre maximum de sélections = 3.


**********************************************************************************************************************************************************************************
	brève explication du code:
**********************************************************************************************************************************************************************************
		
******************** 1. les états  ********************

	/* état de départ du formulaire  */
 	const [quest01, setQuest01] = useState(true);

	/*deuxième état du formulaire (vrai lorsque l'état précédent est faux)*/
	const [quest02, setQuest02] = useState(false);

	/*statut de type string qui est rempli par la lecture des informations de l'utilisateur. */
	const [prenom, setPrenom] = useState("");

	/*contrôle du remplissage correct de l'information, vrai lorsque l'état a été correctement rempli   */
	const [prenomOK, setPrenomOK] = useState(false);

	/*statut de type string qui est rempli par la lecture des informations de l'utilisateur. */
	const [pronom, setPronom] = useState("");

	/*contrôle du remplissage correct de l'information, vrai lorsque l'état a été correctement rempli   */
	const [pronomOK, setPronomOK] = useState(false);

	/*si l'utilisateur choisit d'entrer ses propres données, on active cet état pour faire le contrôle et activer ou désactiver une entrée de texte selon son choix.*/
	const [inputPronom, setInputPronom] = useState(false);


******************** 2. Premier et deuxième champ du formulaire ********************

            {!quest01 ? undefined :
                <Form.Field>
                    <div class="ui divider">
                        <div>
                            <h2>{q1}</h2>
                            <Label pointing='below'>{q1_desc}</Label>
                        </div>

                        <div class="ui focus input" >
                   /* ***>>>>>On affecte le statut "prenom" avec les informations données par l'utilisateur***<<<<< */
                            <input type="text" onChange={(e) => { setPrenom(e.target.value), console.log(e.target.value) }} />
                        </div>
                        <br></br>
                        <br></br>
                        <div>
		/* >>>>>****En cliquant sur le bouton nous vérifions que le statut "prenom" a bien été affecté,
		 	    puis nous terminons le cycle de vie de la question 1 et activons le statut
 		            de la question numéro 2, dans le cas où notre statut "prenom" n'est pas encore défini,
		            une alerte est affichée demandant de bien remplir le champ. ***** <<<<<<<<<<< */

                            <Button onClick={(e) => prenom ? (setPrenomOK(true), setQuest01(false), setQuest02(true)) : alert("Prenom requis !")}
                            >Suivant</Button>
                            <br></br>
                            <br></br>
                            <Button color="Teal">Précedént</Button>
                        </div>
                    </div>
                    <br></br>
                </Form.Field>
            }

        /* *********Vérifier que le statut de la question deux a été activé et afficher notre deuxième partie du formulaire.
		    On reprend la structure logique du formulaire précédent, dans ce cas on utilise une entrée de type bouton radio,
		    quand on clique sur l'option "Descrption personnelle", une entrée de type texte s'affiche.  ********* */

            {quest02 ?
                <Form.Field>
                    <div className="multiChoix">
                        <h2>{q2}</h2>
                        <div>
                            <div className="champ">
                                <input type="radio" checked={pronom === 'Elle'} name="pronom" id="Elle" onChange={() => { setPronom('Elle'), setInputPronom(false) }} />
                                <label> Elle </label>
                            </div>
                            <div className="champ">
                                <input type="radio" checked={pronom === 'il'} name="pronom" id="il" onChange={() => { setPronom('il'), setInputPronom(false) }} />
                                <label> il </label>
                            </div>
                            <div className="champ">
                                <input type="radio" checked={pronom === 'Iel'} name="pronom" id="Iel" onChange={() => { setPronom('Iel'), setInputPronom(false) }} />
                                <label> Iel </label>
                            </div>
                            <div className="champ">
                                <input type="radio" checked={inputPronom} name="pronom" id="perso" onChange={() => { setInputPronom(true) }} />
                                <label> Description personnelle </label>
                                {inputPronom ?
                                    <div class="ui focus input" >
                                        <input className="inputIn" type="text" onChange={(e) => { setPronom(e.target.value) }} />
                                    </div>
                                    : undefined}
                            </div>
                            <br></br>
                        </div>

                        <Button color="Teal">Précedént</Button>
                        <Button color="#43BF95" onClick={() => pronom ? (setPronomOK(true), setQuest02(false), setQuest03(true), setInputPronom(false)) : alert("Pronom requis !")}>
                            Suivant</Button>

                    </div>
                </Form.Field>
                : undefined}

***********************************************************************************************************************************************************
**************************************** Conclusion :******************************************************************************************************
Comme on peut le remarquer la structure logique du formulaire est basée sur le principe du cycle de vie de nos composants en utilisant des états booléens
 qui sont chargés d'activer ou de désactiver chaque énoncé de ce même, en sauvegardant en parallèle les valeurs saisies par l'utilisateur. 
***********************************************************************************************************************************************************










































