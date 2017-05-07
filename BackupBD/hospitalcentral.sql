/*
Navicat MySQL Data Transfer

Source Server         : LOCALSERVER
Source Server Version : 50715
Source Host           : localhost:3306
Source Database       : hospitalcentral

Target Server Type    : MYSQL
Target Server Version : 50715
File Encoding         : 65001

Date: 2017-05-06 17:03:20
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `citamedica`
-- ----------------------------
DROP TABLE IF EXISTS `citamedica`;
CREATE TABLE `citamedica` (
  `idcita` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `paciente` int(11) NOT NULL,
  `doctor` int(11) NOT NULL,
  PRIMARY KEY (`idcita`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of citamedica
-- ----------------------------

-- ----------------------------
-- Table structure for `doctores`
-- ----------------------------
DROP TABLE IF EXISTS `doctores`;
CREATE TABLE `doctores` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cedula` varchar(13) NOT NULL,
  `nombre` varchar(150) NOT NULL,
  `rango` int(11) NOT NULL,
  `especialidad` int(11) NOT NULL,
  `exequatur` varchar(25) DEFAULT '""',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of doctores
-- ----------------------------

-- ----------------------------
-- Table structure for `pacientes`
-- ----------------------------
DROP TABLE IF EXISTS `pacientes`;
CREATE TABLE `pacientes` (
  `id` int(11) NOT NULL,
  `record` int(11) NOT NULL,
  `cedula` varchar(13) NOT NULL DEFAULT '999-9999999-9',
  `nombre` varchar(150) NOT NULL,
  `rango` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of pacientes
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
  `permiso_proceso` varchar(1) NOT NULL DEFAULT '0',
  `permiso_reporte` varchar(1) NOT NULL DEFAULT '0',
  `permiso_estadistica` varchar(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idusuarios`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of usuarios
-- ----------------------------
INSERT INTO `usuarios` VALUES ('1', 'frichardson', 'frrh0414', '', '0', '1', '0', '0');
