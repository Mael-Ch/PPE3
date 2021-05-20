-- Script hydration de la bdd

-- horraire
INSERT INTO `ppe_3_mmd`.`horraire` (`id`, `debut`) VALUES ('1', '2020-11-21 09:00:00');
INSERT INTO `ppe_3_mmd`.`horraire` (`id`, `debut`) VALUES ('2', '2020-11-21 10:00:00');
INSERT INTO `ppe_3_mmd`.`horraire` (`id`, `debut`) VALUES ('3', '2020-11-21 13:00:00');
INSERT INTO `ppe_3_mmd`.`horraire` (`id`, `debut`) VALUES ('4', '2020-11-21 15:00:00');

-- site --
INSERT INTO `ppe_3_mmd`.`site` (`id`, `ville`, `adresse`) VALUES ('1', 'Annecy', '27 fbg des balmettes');
INSERT INTO `ppe_3_mmd`.`site` (`id`, `ville`, `adresse`) VALUES ('2', 'chamonix', '1 avenue des tests');

-- Obstacle --
INSERT INTO `ppe_3_mmd`.`obstacle` (`id`, `type`, `nom`, `description`) VALUES ('1', 'coffre', 'coffre fou', 'ce coffre vous rend fou');
INSERT INTO `ppe_3_mmd`.`obstacle` (`id`, `type`, `nom`, `description`) VALUES ('2', 'boite', 'boite mystère', 'cette boite renferme un mystère mais quoi ? ');

-- client -- 
INSERT INTO `ppe_3_mmd`.`client` (`id`, `nom`, `prenom`, `email`, `date_naissance`, `telephone`, `crédit`, `adresse`) VALUES ('1', 'dupont', 'pierre', 'dupontpierre@gmail.com', '1975-11-24', '0605095607', '0', 'la ou jhabite1');
INSERT INTO `ppe_3_mmd`.`client` (`id`, `nom`, `prenom`, `email`, `date_naissance`, `telephone`, `crédit`, `adresse`) VALUES ('2', 'lepeau', 'veronique', 'lepeaudominique@gmail.com', '1974-01-12', '0685012106', '20', 'Dans ta classe');


-- theme --
INSERT INTO `ppe_3_mmd`.`theme` (`id`, `nom`) VALUES ('1', 'pirate');
INSERT INTO `ppe_3_mmd`.`theme` (`id`, `nom`) VALUES ('2', 'sherlock');

-- Joueur --
INSERT INTO `ppe_3_mmd`.`joueur` (`pseudo`) VALUES ('xxdarksazukexx');
INSERT INTO `ppe_3_mmd`.`joueur` (`pseudo`) VALUES ('e-girl');


-- Salle --
INSERT INTO `ppe_3_mmd`.`salle` (`id`, `Site`) VALUES ('1', '1');
INSERT INTO `ppe_3_mmd`.`salle` (`id`, `Site`) VALUES ('2', '1');


-- Partie --
INSERT INTO `ppe_3_mmd`.`partie` (`id`, `win`, `salle`, `horraire`, `temps`) VALUES ('1', '0', '1', '2', '01:00:00');
INSERT INTO `ppe_3_mmd`.`partie` (`id`, `win`, `salle`, `horraire`, `temps`) VALUES ('2', '1', '1', '1', '00:46:00');



-- facture --
INSERT INTO `ppe_3_mmd`.`reservation` (`id_partie`, `id_client`, `montant`, `date`) VALUES ('1', '1', '20', '2020-11-21 08:00:00');
INSERT INTO `ppe_3_mmd`.`reservation` (`id_partie`, `id_client`, `montant`, `date`) VALUES ('2', '1', '20', '2020-11-21 09:00:00');


-- avis --
INSERT INTO `ppe_3_mmd`.`avis` (`id`, `joueur`, `partie`, `commentaire`) VALUES ('1', 'e-girl', '2', 'c t bi1');
INSERT INTO `ppe_3_mmd`.`avis` (`id`, `joueur`, `partie`, `commentaire`) VALUES ('2', 'xxdarksazukexx', '1', 'nul');

-- transaction --
INSERT INTO `ppe_3_mmd`.`transaction` (`id_partie`, `id_client`, `montant`, `date`) VALUES ('1', '2', '5', '2020-10-16 13:00:00');
INSERT INTO `ppe_3_mmd`.`transaction` (`id_partie`, `id_client`, `montant`, `date`) VALUES ('2', '2', '5', '2020-10-16 13:30:00');

-- Obstacle/partie --
INSERT INTO `ppe_3_mmd`.`obstacle/partie` (`id_obstacle`, `id_partie`, `position`) VALUES ('1', '1', '1');
INSERT INTO `ppe_3_mmd`.`obstacle/partie` (`id_obstacle`, `id_partie`, `position`) VALUES ('2', '1', '2');

-- partie/Joueur
INSERT INTO `ppe_3_mmd`.`partie/joueur` (`id_partie`, `pseudo_joueur`) VALUES ('1', 'xxdarksazukexx');
INSERT INTO `ppe_3_mmd`.`partie/joueur` (`id_partie`, `pseudo_joueur`) VALUES ('1', 'e-girl');
