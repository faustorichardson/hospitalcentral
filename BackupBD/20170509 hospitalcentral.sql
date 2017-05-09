/*
Navicat MySQL Data Transfer

Source Server         : LOCALSERVER
Source Server Version : 50715
Source Host           : localhost:3306
Source Database       : hospitalcentral

Target Server Type    : MYSQL
Target Server Version : 50715
File Encoding         : 65001

Date: 2017-05-09 18:09:18
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
  KEY `doctor_idx` (`doctor`)
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
  KEY `especialidad_idx` (`especialidad`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of doctores
-- ----------------------------
INSERT INTO `doctores` VALUES ('2', '123-1234567-1', 'FAUSTO RAFAEL RICHARDSON HERNANDEZ', '8', '3', '3333333333-7');
INSERT INTO `doctores` VALUES ('3', '123-1234567-1', 'EUSTAQUIO CONTRERAS', '4', '3', '232324-98');
INSERT INTO `doctores` VALUES ('4', '456-7898741-0', 'JOHN DOE', '7', '5', '988752224');
INSERT INTO `doctores` VALUES ('5', '889-7744221-1', 'JANE DOE', '17', '7', '23232223');

-- ----------------------------
-- Table structure for `especialidad`
-- ----------------------------
DROP TABLE IF EXISTS `especialidad`;
CREATE TABLE `especialidad` (
  `idespecialidad` int(11) NOT NULL AUTO_INCREMENT,
  `especialidad` varchar(50) NOT NULL,
  PRIMARY KEY (`idespecialidad`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of especialidad
-- ----------------------------
INSERT INTO `especialidad` VALUES ('1', 'ALERGOLOGIA');
INSERT INTO `especialidad` VALUES ('2', 'ANESTESIOLOGIA Y REANIMACION');
INSERT INTO `especialidad` VALUES ('3', 'CARDIOLOGIA');
INSERT INTO `especialidad` VALUES ('4', 'DERMATOLOGIA');
INSERT INTO `especialidad` VALUES ('5', 'ENDOCRINOLOGIA');
INSERT INTO `especialidad` VALUES ('6', 'GASTROENTEROLOGIA');
INSERT INTO `especialidad` VALUES ('7', 'GERIATRIA');
INSERT INTO `especialidad` VALUES ('8', 'HEMATOLOGIA Y HEMOTERAPIA');
INSERT INTO `especialidad` VALUES ('9', 'HIDROLOGIA MEDICA');
INSERT INTO `especialidad` VALUES ('10', 'INFECTOLOGIA');

-- ----------------------------
-- Table structure for `pacientes`
-- ----------------------------
DROP TABLE IF EXISTS `pacientes`;
CREATE TABLE `pacientes` (
  `idpacientes` int(11) NOT NULL AUTO_INCREMENT,
  `record` varchar(11) NOT NULL,
  `cedula` varchar(13) NOT NULL DEFAULT '999-9999999-9',
  `nombre` varchar(150) NOT NULL,
  `rango` int(11) NOT NULL,
  PRIMARY KEY (`idpacientes`),
  KEY `rango_idx` (`rango`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of pacientes
-- ----------------------------
INSERT INTO `pacientes` VALUES ('1', '99863366', '001-1136078-9', 'FAUSTO RAFAEL RICHARDSON HERNANDEZ', '2');
INSERT INTO `pacientes` VALUES ('2', '224949', '999-9999999-9', 'FARRAH NAHIRA RICHARDSON PENA', '7');

-- ----------------------------
-- Table structure for `rango`
-- ----------------------------
DROP TABLE IF EXISTS `rango`;
CREATE TABLE `rango` (
  `idrango` int(11) NOT NULL AUTO_INCREMENT,
  `rango` varchar(50) NOT NULL,
  PRIMARY KEY (`idrango`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of rango
-- ----------------------------
INSERT INTO `rango` VALUES ('1', 'OFICIAL GENERAL');
INSERT INTO `rango` VALUES ('2', 'OFICIAL SUPERIOR');
INSERT INTO `rango` VALUES ('3', 'OFICIAL SUBALTERNO');
INSERT INTO `rango` VALUES ('4', 'ALISTADO');
INSERT INTO `rango` VALUES ('5', 'ASIMILADO');
INSERT INTO `rango` VALUES ('6', 'CIVIL');
INSERT INTO `rango` VALUES ('7', 'FAMILIAR DE MILITAR');

-- ----------------------------
-- Table structure for `rangosmilitares`
-- ----------------------------
DROP TABLE IF EXISTS `rangosmilitares`;
CREATE TABLE `rangosmilitares` (
  `idrango` int(11) NOT NULL AUTO_INCREMENT,
  `rango` varchar(50) NOT NULL,
  `abreviatura` varchar(15) NOT NULL,
  `orden` varchar(2) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idrango`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of rangosmilitares
-- ----------------------------
INSERT INTO `rangosmilitares` VALUES ('1', 'TENIENTE GENERAL', 'TTE GRAL', '1');
INSERT INTO `rangosmilitares` VALUES ('2', 'MAYOR GENERAL', 'MAY GRAL', '2');
INSERT INTO `rangosmilitares` VALUES ('3', 'GENERAL DE BRIGADA', 'GRAL DE BRIG', '3');
INSERT INTO `rangosmilitares` VALUES ('4', 'CORONEL', 'COR', '4');
INSERT INTO `rangosmilitares` VALUES ('5', 'TENIENTE CORONEL', 'TTE COR', '5');
INSERT INTO `rangosmilitares` VALUES ('6', 'MAYOR', 'MAY', '6');
INSERT INTO `rangosmilitares` VALUES ('7', 'CAPITAN', 'CAP', '7');
INSERT INTO `rangosmilitares` VALUES ('8', '1ER TENIENTE', '1ER TTE', '8');
INSERT INTO `rangosmilitares` VALUES ('9', '2DO TENIENTE', '2DO TTE', '9');
INSERT INTO `rangosmilitares` VALUES ('10', 'SARGENTO MAYOR', 'SGTO MAY', '10');
INSERT INTO `rangosmilitares` VALUES ('11', 'SARGENTO', 'SGTO', '11');
INSERT INTO `rangosmilitares` VALUES ('12', 'CABO', 'CABO', '12');
INSERT INTO `rangosmilitares` VALUES ('13', 'RASO', 'RASO', '13');
INSERT INTO `rangosmilitares` VALUES ('14', 'ALMIRANTE', 'ALM', '1');
INSERT INTO `rangosmilitares` VALUES ('15', 'VICEALMIRANTE', 'VICEALM', '2');
INSERT INTO `rangosmilitares` VALUES ('16', 'CONTRALMIRANTE', 'CONTRALM', '3');
INSERT INTO `rangosmilitares` VALUES ('17', 'CAPITAN DE NAVIO', 'CAP DE NAV', '4');
INSERT INTO `rangosmilitares` VALUES ('18', 'CAPITAN DE FRAGATA', 'CAP DE FRAG', '5');
INSERT INTO `rangosmilitares` VALUES ('19', 'CAPITAN DE CORBETA', 'CAP DE CORB', '6');
INSERT INTO `rangosmilitares` VALUES ('20', 'TENIENTE DE NAVIO', 'TTE DE NAV', '7');
INSERT INTO `rangosmilitares` VALUES ('21', 'TENIENTE DE FRAGATA', 'TTE DE FRAG', '8');
INSERT INTO `rangosmilitares` VALUES ('22', 'TENIENTE DE CORBETA', 'TTE DE CORB', '9');
INSERT INTO `rangosmilitares` VALUES ('23', 'MARINERO', 'MRO', '13');
INSERT INTO `rangosmilitares` VALUES ('24', 'ASIMILADO', 'ASM', '14');
INSERT INTO `rangosmilitares` VALUES ('25', 'CIVIL', 'CIVIL', '15');

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
  `permiso_mantenimiento_pacientes` varchar(1) NOT NULL DEFAULT '0',
  `permiso_mantenimiento_usuario` varchar(1) NOT NULL DEFAULT '0',
  `permiso_proceso` varchar(1) NOT NULL DEFAULT '0',
  `permiso_proceso_citasmedicas` varchar(1) NOT NULL DEFAULT '0',
  `permiso_reporte` varchar(1) NOT NULL DEFAULT '0',
  `permiso_reporte_citasmedicas` varchar(1) NOT NULL DEFAULT '0',
  `permiso_estadistica` varchar(1) NOT NULL DEFAULT '0',
  `permiso_estadistica_citasmedicas` varchar(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idusuarios`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of usuarios
-- ----------------------------
INSERT INTO `usuarios` VALUES ('1', 'frichardson', 'frrh0414', '', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1');
INSERT INTO `usuarios` VALUES ('2', 'citasmedicas', 'citas1234', '', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1');
