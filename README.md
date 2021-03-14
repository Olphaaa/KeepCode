## CONTEXTE (StatCode)

**StatCode** est une application qui permet la gestion des sessions de code de la route afin de garder les notes pour pouvoir ensuite faire des statistiques sur l'avancée de l’utilisateur.

**Public visé :** Personnes voulant passer l’examen du code de la route, Une session se présente sous la forme d’une note sur 40, qu’une date inférieure à celle d’aujourd’hui, d’un niveau de difficulté ressenti par l’utilisateur (noté sur 5 pts) sur la globalité des questions faite pendant la session, une note/description si l’utilisateur veut se rappeler d’une information importante ou savoir comment s’est passé la session et finalement une couleur dédiée en fonction de la note ( `rouge:0-24` orange:25-34 vert:35-40) 

Il y a bien sûr la possibilité d’ajouter une nouvelle session dans le menu principal pour un ajout rapide et une page consacrée à la gestion des sessions qui permettra dès le supprimer ou les modifier si une erreur s'est présenté. Une page historique est consacrée à la partie master-detail en affichant toutes les informations des sessions dans sa liste de sessions Une page Statistiques permet d’avoir plus d’informations sur les sessions passées: 
- Diagramme en bâton pour chaque session faite pour voir le rapport de nombre de fautes sur le total de 40 points 
- Barre de progression (si elle est remplie, l’utilisateur sera fin prêt pour passer le code) 
- Moyenne Générale de toutes les sessions enregistrées 
- Moyenne sur les 5 dernières notes des sessions pour ne pas prendre en compte les sessions ratées auparavant 
- Nombres de jours restants avant l'examen final (l’utilisateur peut ajouter cette date en cours de période de code)

