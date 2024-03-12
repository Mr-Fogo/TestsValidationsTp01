# I. Obstacles à la Validation

Voici une liste des éléments du logiciel actuel qui rendent la validation difficile :

## Problèmes de Code

- **Blocages importants dans les instructions conditionnelles** : Les fonctions `tourJoueur()` et `tourJoueur2()` présentent une complexité accrue due à une multitude de conditions imbriquées, ce qui rend leur compréhension difficile et nuit à la lisibilité du code en plus d'être très similaire.

- **Exposition inappropriée des variables** : Les variables `quiterJeu` et `tourDuJoueur` sont déclarées comme publiques, violant ainsi le principe d'encapsulation, ce qui peut entraîner des problèmes de maintenabilité et de sécurité.

- **Surcharge de la logique de jeu dans la boucle principale** : La réinitialisation répétée de la grille à chaque itération de la boucle principale (`BoucleJeu`) est une pratique à éviter, car elle entraîne un gaspillage de ressources et complexifie le code.

- **Complexité excessive dans le contrôle du flux d'exécution** : L'utilisation du mot-clé `goto` pour gérer les entrées utilisateur dans `BoucleJeu` est une approche peu recommandée, car elle complique la traçabilité et la compréhension du flux d'exécution du programme.

- **Incohérence dans l'affichage de la grille** : Une erreur est présente dans la méthode `affichePlateau`, où la disposition des éléments de la grille n'est pas conforme aux attentes, ce qui peut entraîner une confusion lors de l'affichage du plateau de jeu.

- **Manque de modularité dans les vérifications de victoire et d'égalité** : Les méthodes de vérification de la victoire (`verifVictoire`) et d'égalité (`verifEgalite`) sont implémentées de manière monolithique, rendant ainsi le code moins flexible et difficile à maintenir.

- **Utilisation de noms de méthodes et de variables non uniformes** : Bien que l'utilisation du français pour nommer les méthodes et les variables soit acceptable, elle peut entraîner des problèmes de cohérence et de compréhension pour les autres développeurs travaillant sur le projet.

- **Redondance dans l'initialisation de la grille** : La grille est initialisée à deux endroits différents, ce qui entraîne une redondance de code et une inefficacité dans la gestion des ressources.

- **Manque d'abstraction entre la logique métier et l'interface utilisateur** : La classe actuelle mélange la logique métier du jeu avec les interactions utilisateur, ce qui rend difficile la réutilisation du code dans d'autres contextes ou interfaces.

- **Utilisation de valeurs numériques arbitraires** : Le code utilise des valeurs numériques directement, sans les encapsuler dans des constantes ou des énumérations, ce qui rend le code moins lisible et moins flexible.

- **Présence de commentaires en bloc inactifs** : Certains blocs de commentaires dans le code sont désactivés, ce qui peut induire en erreur les développeurs qui les consultent pour comprendre le fonctionnement du programme.

#### S : Principe de Responsabilité Unique (SRP)

- Non Respecté : Toutes les classes comportent plusieurs responsabilités. Par exemple, dans la classe `Morpion`, la gestion du jeu, des entrées du joueur et de la grille sont mélangées.

#### O : Principe Ouvert/Fermé

- Non Respecté : Pour ajouter une nouvelle fonctionnalité, il est nécessaire de modifier le fichier `Program` et d'ajouter des cases dans des blocs switch pour prendre en compte un nouveau jeu.

Autres Problèmes :

- Utilisation de Goto : Pratique déconseillée, rend le débogage difficile.
- Appel direct des classes Morpion et PuissanceQuatre dans le main.
- Les fonctions `verifVictoire` et `verifEgalite` : N'utilisent pas de boucles, les possibilités sont écrites en dur, il est possible que certaines conditions de victoire soient manquantes.

# II. Approches pour Résoudre ces Problèmes 

## Objectifs

Il est nécessaire de réorganiser une portion du code afin de le rendre adaptable à des tests automatisés. Intégrer des tests au projet pour s'assurer qu'une modification n'a pas altéré le fonctionnement habituel du projet. Les premiers tests effectués sur le code initial révèlent les erreurs détectées lors de l'utilisation.

## Tests unitaires

La mise en place de tests unitaires est limitée en raison du faible nombre de fonctions renvoyant des données. Il est possible de créer des tests pour les fonctions de vérification de victoire et d'égalité, mais cela reste peu efficace car chaque fonction nécessite un grand nombre de cas de test différents.

## Refactoring du Code

Il serait judicieux de créer une classe abstraite `Game` et de la faire hériter par `Morpion` et `PuissanceQuatre` afin de partager la logique commune et de simplement réécrire certaines conditions de victoire.

Pour simplifier davantage, il est nécessaire d'enregistrer les données des joueurs dans une classe `Player`. De même, la création d'une classe `Board` permettrait de regrouper toutes les actions liées à la grille.

Pour faciliter les tests, il est également nécessaire de diviser les fonctions trop longues en plus petites fonctions avec une responsabilité spécifique, permettant ainsi de préciser les tests sur des sections plus précises et d'identifier plus facilement les erreurs.

# III - Extension des fonctionnalités manquantes

## Intelligence Artificielle 

Pour implémenter une intelligence artificielle basique, il faudrait rajouter l'attribut `isBot` au Joueur afin de pouvoir, au moment des tours du Joueur, déterminer s'il est un bot afin de lancer une fonction permettant de placer aléatoirement dans une des cases disponibles.

## Sauvegarde

Pour la sauvegarde, il faudrait à chaque fois qu'un tour est joué, écrire dans un fichier JSON représentant le board afin de pouvoir le recharger au besoin.
