# Projet7---FinalFantasy


## Programmation orienté objet : C#

> Date : du 23/01/2023 au 03/02/2023

### Nom de l’intervenant

> Kévin ROUSSEL

### Modalités d’apprentissage

> *Travail et projet par groupe de 3 étudiants ; évaluation en groupe sur le projet.
Pour la communication écrite et les coachings en présentiel , utilisation de Discord.*

### Intitulé, contexte et descriptif du projet

> *Le but de ce projet est de découvrir et mettre en place les différents principes de la programmation orienté objet (POO) en produisant un jeu en console avec C#.*
>
> *Ce jeu devra comporter des combats en tour par tour à la manière des jeux Pokémon ou les premiers Final Fantasy (attaque, utilisation d’objet, magie)*
> *Pas de graphisme à intégrer, le jeu se jouera avec le terminal et comportera donc une vue TopDown avec une carte en ASCII.*
>
> *Ce jeu devra comporter :*
> - *Une carte où le joueur pourra se déplacer librement à l’aide des touches fléchés*
> - *Des combats aléatoires sur certaines cases spécifiques (équivalent à l’herbe haute de Pokémon)*
> - *Un menu où l’on peut voir notre équipe, consulter leur statistiques et attaques possibles.*
> - *Un menu où l’on peut consulter notre inventaire (potion, clés, objet de boost de statistiques)*
> - *Un menu permettant la sauvegarde et le chargement de notre partie (sérialisation).*
>
> *Les combats doivent :*
>
> - *Proposer un affrontement en 1v1 au tour par tour*
> - *L’ennemis sera piloté par une IA avec plusieurs niveaux d’intelligence possible (exploitant ou pas les faiblesses de l’adversaire par exemple)*
> - *Si notre personnage tombe au combat on peut le remplacer par un autre membre de notre équipe, si tous nos personnages sont KO c’est GameOver*
> - *À chaque tour nous devons choisir notre mouvement (attaque, magie, objet), chaque menu présente un ensemble de mouvement possible et le joueur doit choisir le mouvement précis à utiliser. La magie consomme une barre de mana qui se recharge progressivement.*
> - *Chaque personnage comporte un type, des statistiques (attaque, défense, vitesse, PV, PM, précision etc) et un set d’attaque et de magie qui lui appartient. Les personnages évoluent grâce à de l’expérience acquise en combat et peuvent monter de niveau (meilleures statistiques et potentiellement nouvelle attaque).*
> - *Chaque mouvement comporte un type, des statistiques d’attaque, de précisions, taux coup critique etc. Les types sont efficaces face à d’autres types ou au contraire faible face à d'autres (voir le tableau des types de Pokémon).*
> - *En cas de victoire nos personnages gagnent de l’expérience.*
>
> *Le jeu évolue en 2 phases :*
> *La carte du jeu, où notre personnage se déplace sur une carte à l’aide des touches fléchés. Sur cette carte on peut parler à des personnages, ouvrir des coffres, enclencher des combats avec des ennemis.*
> *Les combats, phase stratégique du jeu exploitant l’ensemble des mécaniques d’affrontement comme décrit plus haut.*
> 
> *Il sera important de réfléchir à l'avance de la structure du jeu et de ses différents composants. Pour cela on produira un ensemble de diagramme de classes afin d’avoir une meilleure vision du projet. On pourra exploiter l’héritage et tout ce qui vient avec au travers des différents personnages, les attaques, les objets etc.*
> 
> *Les combats étant majoritairement une application mathématique on mettra en place un ensemble de tests unitaires pour valider la cohérence et la solidité du système.*
>
> ## Problématiques
> *Plusieurs problématiques devront être résolues par les étudiants, à savoir :*
> - *Mise en place d’une architecture à l’aide de diagramme de classe*
> - *Création des mécaniques de jeux en exploitant la programmation orienté objet*
> - *Mise en place d’un système d’écran dans la console pour évoluer dans le jeu*
> - *Création de tests unitaires prouvant la solidité et l’efficacité du système de combat.*
