## Séance 2: Analyse d'un Projet Hérité

### I. Obstacles à la Validation

Voici une liste des éléments du logiciel actuel qui rendent la validation difficile :

## Problèmes de Code


### Bloaters:
- **Méthodes Volumineuses**: Les fonctions `tourJoueur()` et `tourJoueur2()` dépassent chacune la limite de 30 lignes.

- **Classes Trop Imposantes**: Les classes `PuissanceQuatre` et `Morpion` sont trop longues, dépassant largement les 250 lignes. De plus, elles contiennent des méthodes qui pourraient être externalisées dans une nouvelle classe dédiée au jeu.

- **Duplication de Code**: Redondance dans le code principal pour valider les jeux avec l'entrée au clavier. Les classes `Morpion` et `PuissanceQuatre` présentent des similitudes importantes. De plus, les fonctions `tourJoueur()` et `tourJoueur2()` sont presque identiques, à l'exception d'une seule ligne.

### Obstacles au Changement:
- **Grands Blocs de Switch**: Des structures If/Else contenant un nombre excessif de conditions. Les fonctions `tourJoueur()` et `tourJoueur2()` contiennent plusieurs blocs switch et conditions.

### Inutilisés:
- **Code Mort Abondant**: Des lignes de code mises en commentaire mais jamais exécutées.

### Violations des Principes SOLID

#### S : Principe de Responsabilité Unique (SRP)
--------------------------------
- Non Respecté : Toutes les classes comportent plusieurs responsabilités. Par exemple, dans la classe `Morpion`, la gestion du jeu, des entrées du joueur et de la grille sont mélangées.

#### O : Principe Ouvert/Fermé
--------------------------------
- Non Respecté : Pour ajouter une nouvelle fonctionnalité, il est nécessaire de modifier le fichier `Program` et d'ajouter des cases dans des blocs switch pour prendre en compte un nouveau jeu.

Autres Problèmes :

- Utilisation de Goto : Pratique déconseillée, rend le débogage difficile.

- Appel direct des classes Morpion et PuissanceQuatre dans le main.

- Les fonctions `verifVictoire` et `verifEgalite` : Ne utilisent pas de boucles, les possibilités sont écrites en dur, il est possible que certaines conditions de victoire soient manquantes.

## II. Approches pour Résoudre ces Problèmes 

### Tests unitaires
La mise en place de tests unitaires est limitée en raison du faible nombre de fonctions renvoyant des données. Il est possible de créer des tests pour les fonctions de vérification de victoire et d'égalité, mais cela reste peu efficace car chaque fonction nécessite un grand nombre de cas de test différents.

### Refactoring du Code
Il serait judicieux de créer une classe abstraite `Game` et de la faire hériter par `Morpion` et `PuissanceQuatre` afin de partager la logique commune et de simplement réécrire certaines conditions de victoire.

Pour simplifier davantage, il est nécessaire d'enregistrer les données des joueurs dans une classe `Player`. De même, la création d'une classe `Board` permettrait de regrouper toutes les actions liées à la grille.

Pour faciliter les tests, il est également nécessaire de diviser les fonctions trop longues en plus petites fonctions avec une responsabilité spécifique, permettant ainsi de préciser les tests sur des sections plus précises et d'identifier plus facilement les erreurs.