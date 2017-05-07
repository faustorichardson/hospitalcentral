/*
Navicat MySQL Data Transfer

Source Server         : LOCALSERVER
Source Server Version : 50715
Source Host           : localhost:3306
Source Database       : hospitalcentral

Target Server Type    : MYSQL
Target Server Version : 50715
File Encoding         : 65001

Date: 2017-05-06 20:13:01
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `citasmedicas`
-- ----------------------------
DROP TABLE IF EXISTS `citasmedicas`;
CREATE TABLE `citasmedicas` (
  `idcitasmedicas` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` date NOT NULL,
  `record` varchar(45) NOT NULL,
  `doctor` int(11) NOT NULL,
  PRIMARY KEY (`idcitasmedicas`),
  KEY `doctor_idx` (`doctor`),
  CONSTRAINT `doctor_citasmedicas` FOREIGN KEY (`doctor`) REFERENCES `doctores` (`iddoctores`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of citasmedicas
-- ----------------------------

-- ----------------------------
-- Table structure for `doctores`
-- ----------------------------
DROP TABLE IF EXISTS `doctores`;
CREATE TABLE `doctores` (
  `iddoctores` int(11) NOT NULL AUTO_INCREMENT,
  `cedula` varchar(13) NOT NULL,
  `nombre` varchar(150) NOT NULL,
  `rango` int(11) NOT NULL,
  `especialidad` int(11) NOT NULL,
  `exequatur` varchar(15) NOT NULL DEFAULT '0',
  PRIMARY KEY (`iddoctores`),
  KEY `rango_idx` (`rango`),
  KEY `especialidad_idx` (`especialidad`),
  CONSTRAINT `especialidad` FOREIGN KEY (`especialidad`) REFERENCES `especialidad` (`idespecialidad`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `rango` FOREIGN KEY (`rango`) REFERENCES `rango` (`idrango`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of doctores
-- ----------------------------

-- ----------------------------
-- Table structure for `especialidad`
-- ----------------------------
DROP TABLE IF EXISTS `especialidad`;
CREATE TABLE `especialidad` (
  `idespecialidad` int(11) NOT NULL AUTO_INCREMENT,
  `especialidad` varchar(50) NOT NULL,
  PRIMARY KEY (`idespecialidad`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of especialidad
-- ----------------------------

-- ----------------------------
-- Table structure for `pacientes`
-- ----------------------------
DROP TABLE IF EXISTS `pacientes`;
CREATE TABLE `pacientes` (
  `idpacientes` int(11) NOT NULL AUTO_INCREMENT,
  `record` varchar(45) NOT NULL,
  `cedula` varchar(13) NOT NULL DEFAULT '999-9999999-9',
  `nombre` varchar(150) NOT NULL,
  `rango` int(11) NOT NULL,
  PRIMARY KEY (`idpacientes`),
  KEY `rango_idx` (`rango`),
  CONSTRAINT `rango_pacientes` FOREIGN KEY (`rango`) REFERENCES `rango` (`idrango`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of pacientes
-- ----------------------------

-- ----------------------------
-- Table structure for `rango`
-- ----------------------------
DROP TABLE IF EXISTS `rango`;
CREATE TABLE `rango` (
  `idrango` int(11) NOT NULL AUTO_INCREMENT,
  `rango` varchar(50) NOT NULL,
  `abreviatura` varchar(15) NOT NULL,
  PRIMARY KEY (`idrango`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of rango
-- ----------------------------

-- ----------------------------
-- Table structure for `usuarios`
-- ----------------------------
DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE `usuarios` (
  `idusuarios` int(11) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(25) NOT NULL,
  `clave` varchar(25) NOT NULL,
  `status` bit(1) NOT NULL DEFAULT b'0',
  `permiso_mantenimiento` varchar(1) NOT NULL DEFAULT '0',
  `permiso_mantenimiento_doctores` varchar(1) NOT NULL DEFAULT '0',
  `permiso_mantenimiento_especialidades` varchar(1) NOT NULL DEFAULT '0',
  `permiso_mantenimiento_usuario` varchar(1) NOT NULL DEFAULT '0',
  `permiso_proceso` varchar(1) NOT NULL DEFAULT '0',
  `permiso_proceso_citasmedicas` varchar(1) NOT NULL DEFAULT '0',
  `permiso_reporte` varchar(1) NOT NULL DEFAULT '0',
  `permiso_reporte_citasmedicas` varchar(1) NOT NULL DEFAULT '0',
  `permiso_estadistica` varchar(1) NOT NULL DEFAULT '0',
  `permiso_estadistica_citasmedicas` varchar(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idusuarios`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of usuarios
-- ----------------------------
INSERT INTO `usuarios` VALUES ('1', 'frichardson', 'frrh0414', '', '1', '0', '0', '0', '1', '0', '1', '0', '1', '0');
