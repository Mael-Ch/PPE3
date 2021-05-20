-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema PPE3_MMD
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema PPE3_MMD
-- -----------------------------------------------------
DROP DATABASE IF EXISTS `PPE3_MMD`;
CREATE SCHEMA IF NOT EXISTS `PPE3_MMD` DEFAULT CHARACTER SET utf8 ;
USE `PPE3_MMD` ;

-- -----------------------------------------------------
-- Table `PPE3_MMD`.`Joueur`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE3_MMD`.`Joueur` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `pseudo` VARCHAR(255) NOT NULL UNIQUE,
  `email` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE3_MMD`.`Avis`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE3_MMD`.`Avis` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `commentaire` TEXT NOT NULL,
  `note` INT NOT NULL,
  `date` DATETIME NULL,
  `joueur` INT NULL,
  PRIMARY KEY (`id`),
  INDEX `idJOUEUR_idx` (`joueur` ASC) ,
    FOREIGN KEY (`joueur`)
    REFERENCES `PPE3_MMD`.`Joueur` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE3_MMD`.`Client`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE3_MMD`.`Client` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(50) NOT NULL,
  `prenom` VARCHAR(50) NOT NULL,
  `photo` VARCHAR(255) NULL,
  `email` VARCHAR(255) NOT NULL,
  `tel` VARCHAR(20) NOT NULL,
  `naissance` DATE NOT NULL,
  `credit` INT NULL,
  `adresse` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE3_MMD`.`Facture`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE3_MMD`.`Facture` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `date` DATETIME NOT NULL,
  `montant` DOUBLE NOT NULL,
  `nbCredit` INT NULL,
  `client` INT NULL,
  PRIMARY KEY (`id`),
  INDEX `idCLIENT_idx` (`client` ASC) ,
    FOREIGN KEY (`client`)
    REFERENCES `PPE3_MMD`.`Client` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE3_MMD`.`Horaire`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE3_MMD`.`Horaire` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `heure` TIME NOT NULL UNIQUE,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE3_MMD`.`Obstacle`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE3_MMD`.`Obstacle` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(50) NOT NULL,
  `type` VARCHAR(50) NOT NULL,
  `description` TEXT NULL,
  `photo` VARCHAR(255) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE3_MMD`.`site`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE3_MMD`.`site` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `ville` VARCHAR(255) NOT NULL,
  `adresse` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE3_MMD`.`salle`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE3_MMD`.`salle` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `site` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `idSITE_idx` (`site` ASC) ,
    FOREIGN KEY (`site`)
    REFERENCES `PPE3_MMD`.`site` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE3_MMD`.`Partie`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE3_MMD`.`Partie` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `date` DATE NOT NULL,
  `horaire` INT NOT NULL,
  `temps` TIME NULL,
  `win` BOOLEAN NULL DEFAULT 0,
  `salle` INT NOT NULL,
  PRIMARY KEY (`id`,`date`,`horaire`,`salle`),
  INDEX `idHORAIRE_idx` (`horaire` ASC) ,
  INDEX `idSALLE_idx` (`salle` ASC) ,
    FOREIGN KEY (`horaire`)
    REFERENCES `PPE3_MMD`.`Horaire` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`salle`)
    REFERENCES `PPE3_MMD`.`salle` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE3_MMD`.`Reservation`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE3_MMD`.`Reservation` (
  `id` INT NOT NULL,
  `montant` INT NOT NULL,
  `date` DATETIME NOT NULL,
  `client` INT NOT NULL,
  `partie` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `idCLIENT_idx` (`client` ASC) ,
  INDEX `idPARTIE_idx` (`partie` ASC) ,
    FOREIGN KEY (`client`)
    REFERENCES `PPE3_MMD`.`Client` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
    FOREIGN KEY (`partie`)
    REFERENCES `PPE3_MMD`.`Partie` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE3_MMD`.`theme`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE3_MMD`.`theme` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE3_MMD`.`obstacle_partie`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE3_MMD`.`obstacle_partie` (
  `obstacle` INT NOT NULL,
  `partie` INT NOT NULL,
  `position` INT NOT NULL,
  PRIMARY KEY (`obstacle`, `partie`),
  INDEX `idPARTIE_idx` (`partie` ASC) ,
    FOREIGN KEY (`partie`)
    REFERENCES `PPE3_MMD`.`Partie` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`obstacle`)
    REFERENCES `PPE3_MMD`.`Obstacle` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE3_MMD`.`theme_salle`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE3_MMD`.`theme_salle` (
  `salle` INT NOT NULL,
  `theme` INT NOT NULL,
  `dateDebut` DATE NOT NULL,
  `dateFin` DATE NULL DEFAULT '9999-12-31',
  PRIMARY KEY (`salle`, `theme`, `dateDebut`),
  INDEX `idTHEME_idx` (`theme` ASC) ,
    FOREIGN KEY (`salle`)
    REFERENCES `PPE3_MMD`.`salle` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`theme`)
    REFERENCES `PPE3_MMD`.`theme` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE3_MMD`.`joueur_partie`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE3_MMD`.`joueur_partie` (
  `joueur` INT NOT NULL,
  `partie` INT NOT NULL,
  PRIMARY KEY (`joueur`, `partie`),
  INDEX `idPARTIE_idx` (`partie` ASC) ,
    FOREIGN KEY (`joueur`)
    REFERENCES `PPE3_MMD`.`Joueur` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`partie`)
    REFERENCES `PPE3_MMD`.`Partie` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PPE3_MMD`.`site_horaire`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PPE3_MMD`.`site_horaire` (
  `site` INT NOT NULL,
  `horaire` INT NOT NULL,
  PRIMARY KEY (`site`, `horaire`),
  INDEX `idHORAIRE_idx` (`horaire` ASC) ,
    FOREIGN KEY (`site`)
    REFERENCES `PPE3_MMD`.`site` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    FOREIGN KEY (`horaire`)
    REFERENCES `PPE3_MMD`.`Horaire` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
