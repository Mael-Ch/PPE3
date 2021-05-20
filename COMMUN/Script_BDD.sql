-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema PPE_3_MMD
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema PPE_3_MMD
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `PPE_3_MMD` DEFAULT CHARACTER SET utf8 ;
USE `PPE_3_MMD` ;

-- -----------------------------------------------------
-- Table `PPE_3_MMD`.`Site`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE_3_MMD`.`Site` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `ville` VARCHAR(50) NOT NULL,
  `adresse` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE_3_MMD`.`Theme`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE_3_MMD`.`Theme` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE_3_MMD`.`Salle`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE_3_MMD`.`Salle` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Site` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `ID_SITE_idx` (`Site` ASC) VISIBLE,
    FOREIGN KEY (`Site`)
    REFERENCES `PPE_3_MMD`.`Site` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE_3_MMD`.`Horraire`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE_3_MMD`.`Horraire` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `debut` DATETIME NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE_3_MMD`.`Partie`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE_3_MMD`.`Partie` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `win` TINYINT NOT NULL,
  `salle` INT NOT NULL,
  `horraire` INT NOT NULL,
  `temps` TIME NULL,
  PRIMARY KEY (`id`),
  INDEX `ID_SALLE_idx` (`salle` ASC) VISIBLE,
  INDEX `ID_HORRAIRE_idx` (`horraire` ASC) VISIBLE,
    FOREIGN KEY (`salle`)
    REFERENCES `PPE_3_MMD`.`Salle` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
    FOREIGN KEY (`horraire`)
    REFERENCES `PPE_3_MMD`.`Horraire` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE_3_MMD`.`Obstacle`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE_3_MMD`.`Obstacle` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `type` VARCHAR(50) NOT NULL,
  `nom` VARCHAR(50) NOT NULL,
  `description` TEXT NOT NULL,
  `photo` BLOB NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE_3_MMD`.`Client`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE_3_MMD`.`Client` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(50) NOT NULL,
  `prenom` VARCHAR(50) NOT NULL,
  `email` VARCHAR(100) NOT NULL,
  `date_naissance` DATE NOT NULL,
  `telephone` CHAR(10) NOT NULL,
  `crédit` INT NOT NULL,
  `adresse` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE_3_MMD`.`Joueur`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE_3_MMD`.`Joueur` (
  `pseudo` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`pseudo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE_3_MMD`.`Partie/Joueur`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE_3_MMD`.`Partie/Joueur` (
  `id_partie` INT NOT NULL,
  `pseudo_joueur` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`id_partie`, `pseudo_joueur`),
  INDEX `pseudo_joueur_idx` (`pseudo_joueur` ASC) VISIBLE,
    FOREIGN KEY (`id_partie`)
    REFERENCES `PPE_3_MMD`.`Partie` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`pseudo_joueur`)
    REFERENCES `PPE_3_MMD`.`Joueur` (`pseudo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE_3_MMD`.`Obstacle/Partie`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE_3_MMD`.`Obstacle/Partie` (
  `id_obstacle` INT NOT NULL,
  `id_partie` INT NOT NULL,
  `position` INT NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id_obstacle`, `id_partie`),
  INDEX `ID_PARTIE_idx` (`id_partie` ASC) VISIBLE,
  UNIQUE INDEX `position_UNIQUE` (`position` ASC) VISIBLE,
    FOREIGN KEY (`id_obstacle`)
    REFERENCES `PPE_3_MMD`.`Obstacle` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`id_partie`)
    REFERENCES `PPE_3_MMD`.`Partie` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE_3_MMD`.`Facture`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE_3_MMD`.`Facture` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `id_client` INT NOT NULL,
  `date_heure` DATETIME NOT NULL,
  `montant` INT NOT NULL,
  PRIMARY KEY (`id`, `date_heure`, `id_client`),
  INDEX `ID_CLIENT_idx` (`id_client` ASC) VISIBLE,
    FOREIGN KEY (`id_client`)
    REFERENCES `PPE_3_MMD`.`Client` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE_3_MMD`.`Reservation`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE_3_MMD`.`Reservation` (
  `id_partie` INT NOT NULL,
  `id_client` INT NOT NULL,
  `montant` INT NOT NULL,
  `date` DATETIME NOT NULL,
  PRIMARY KEY (`id_partie`, `id_client`, `date`),
  INDEX `ID_CLIENT_idx` (`id_client` ASC) VISIBLE,
    FOREIGN KEY (`id_partie`)
    REFERENCES `PPE_3_MMD`.`Partie` (`id`)
    ON DELETE NO ACTION
    ON UPDATE CASCADE,
    FOREIGN KEY (`id_client`)
    REFERENCES `PPE_3_MMD`.`Client` (`id`)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE_3_MMD`.`avis`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE_3_MMD`.`avis` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `joueur` VARCHAR(20) NOT NULL,
  `partie` INT NOT NULL,
  `commentaire` TEXT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `JOUEUR_idx` (`joueur` ASC) VISIBLE,
  INDEX `PARTIE_idx` (`partie` ASC) VISIBLE,
    FOREIGN KEY (`joueur`)
    REFERENCES `PPE_3_MMD`.`Joueur` (`pseudo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`partie`)
    REFERENCES `PPE_3_MMD`.`Partie` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE_3_MMD`.`ThemeParSalle`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE_3_MMD`.`ThemeParSalle` (
  `idSalle` INT NOT NULL,
  `idTheme` INT NOT NULL,
  `Debut` DATE NOT NULL,
  `fin` DATE NULL,
  PRIMARY KEY (`idSalle`, `idTheme`, `Debut`),
  INDEX `ID_THEME_idx` (`idTheme` ASC) VISIBLE,
    FOREIGN KEY (`idSalle`)
    REFERENCES `PPE_3_MMD`.`Salle` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`idTheme`)
    REFERENCES `PPE_3_MMD`.`Theme` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
