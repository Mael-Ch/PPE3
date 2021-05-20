-- Site
INSERT INTO `ppe3_mmd`.`site` (`id`, `ville`, `adresse`) VALUES ('1', 'Annecy', '1 rue Annecy');
INSERT INTO `ppe3_mmd`.`site` (`id`, `ville`, `adresse`) VALUES ('2', 'Thonon les bains', '1 rue Thonon les bains');
INSERT INTO `ppe3_mmd`.`site` (`id`, `ville`, `adresse`) VALUES ('3', 'Bonneville', '1 rue Bonneville');
INSERT INTO `ppe3_mmd`.`site` (`id`, `ville`, `adresse`) VALUES ('4', 'Chamonix Mont Blanc', '1 rue Chamonix Mont Blanc');

-- horaire
INSERT INTO Horaire(heure) VALUES 
    ('09:00:00'),
    ('10:00:00'),
    ('11:00:00'),
    ('13:00:00'),
    ('14:00:00'),
    ('15:00:00'),
    ('16:00:00'),
    ('17:00:00');
    
-- theme
INSERT INTO `ppe3_mmd`.`theme` (`id`, `nom`) VALUES ('1', 'pirate');
INSERT INTO `ppe3_mmd`.`theme` (`id`, `nom`) VALUES ('2', 'chevalier');

INSERT INTO obstacle(nom, type, description, photo) VALUES 
    ('piège','piège','cest un piège','tt'),
    ('avalanche','dangeureux','une avalanche','tt'),
    ('coffre','code','Un coffre à code','tt'),
    ('puzzle','jeu','Un puzzle','tt'),
    ('rubik s zlcube','casse-tête','Un rubik s cube','tt'),
    ('Question','énigme','Une question','tt');
    
-- salle
INSERT INTO `ppe3_mmd`.`salle` (`id`, `site`) VALUES ('1', '1');
INSERT INTO `ppe3_mmd`.`salle` (`id`, `site`) VALUES ('2', '1');
INSERT INTO `ppe3_mmd`.`salle` (`id`, `site`) VALUES ('3', '1');
INSERT INTO `ppe3_mmd`.`salle` (`id`, `site`) VALUES ('4', '1');
INSERT INTO `ppe3_mmd`.`salle` (`id`, `site`) VALUES ('5', '2');
INSERT INTO `ppe3_mmd`.`salle` (`id`, `site`) VALUES ('6', '2');
INSERT INTO `ppe3_mmd`.`salle` (`id`, `site`) VALUES ('7', '3');
INSERT INTO `ppe3_mmd`.`salle` (`id`, `site`) VALUES ('8', '4');

INSERT INTO site_horaire(site, horaire) VALUES 
    (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),
    (2,1),(2,2),(2,3),(2,4),(2,5),(2,6),(2,7),(2,8),
    (3,1),(3,2),(3,3),(3,4),(3,5),(3,6),(3,7),(3,8),
    (4,1),(4,2),(4,3),(4,4),(4,5),(4,6),(4,7),(4,8);

-- theme salle
INSERT INTO `ppe3_mmd`.`theme_salle` (`salle`, `theme`, `dateDebut`) VALUES ('1', '1', '2019-12-30');
INSERT INTO `ppe3_mmd`.`theme_salle` (`salle`, `theme`, `dateDebut`) VALUES ('2', '2', '2019-12-30');
INSERT INTO `ppe3_mmd`.`theme_salle` (`salle`, `theme`, `dateDebut`) VALUES ('3', '1', '2019-12-30');
INSERT INTO `ppe3_mmd`.`theme_salle` (`salle`, `theme`, `dateDebut`) VALUES ('4', '2', '2019-12-30');
INSERT INTO `ppe3_mmd`.`theme_salle` (`salle`, `theme`, `dateDebut`) VALUES ('5', '1', '2019-12-30');
INSERT INTO `ppe3_mmd`.`theme_salle` (`salle`, `theme`, `dateDebut`) VALUES ('6', '2', '2019-12-30');
INSERT INTO `ppe3_mmd`.`theme_salle` (`salle`, `theme`, `dateDebut`) VALUES ('7', '1', '2019-12-30');
INSERT INTO `ppe3_mmd`.`theme_salle` (`salle`, `theme`, `dateDebut`) VALUES ('8', '2', '2019-12-30');
