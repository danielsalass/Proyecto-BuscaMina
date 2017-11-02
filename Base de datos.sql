-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema buscaminas
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema buscaminas
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `buscaminas` DEFAULT CHARACTER SET utf8 ;
USE `buscaminas` ;

-- -----------------------------------------------------
-- Table `buscaminas`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `buscaminas`.`Usuario` (
  `idUsuario` INT NOT NULL AUTO_INCREMENT,
  `usuario` VARCHAR(45) NOT NULL,
  `contraseña` VARBINARY(8) NOT NULL,
  PRIMARY KEY (`idUsuario`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `buscaminas`.`Puntuacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `buscaminas`.`Puntuacion` (
  `idPuntuacion` INT NOT NULL AUTO_INCREMENT,
  `tiempo` INT NOT NULL,
  `fecha` DATE NOT NULL,
  `Usuario_idUsuario` INT NOT NULL,
  PRIMARY KEY (`idPuntuacion`, `Usuario_idUsuario`),
  INDEX `fk_Puntuacion_Usuario_idx` (`Usuario_idUsuario` ASC),
  CONSTRAINT `fk_Puntuacion_Usuario`
    FOREIGN KEY (`Usuario_idUsuario`)
    REFERENCES `buscaminas`.`Usuario` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
