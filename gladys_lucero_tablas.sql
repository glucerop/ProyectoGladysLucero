
USE bitacoras;
CREATE TABLE `bitacoras`.`gladys_lucero_control_cargas_diarias` (
  `FechaCarga` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  `Descripcion` VARCHAR(45) NULL)
COMMENT = 'Para tener control de las cargas diarias';

CREATE TABLE `bitacoras`.`gladys_lucero_control_log_ejecucion` (
  `FechaCarga` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  `Error` VARCHAR(45) NULL,
  `Descripcion` VARCHAR(45) NULL)
COMMENT = 'Para tener control de ejecuciones y errores en las cargas';

USE catalogos;
CREATE TABLE `gladys_lucero_cat_agencias` (
  `FechaCarga` timestamp NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Fecha de carga del sistema',
  `codigo_agencia` varchar(45) NOT NULL COMMENT 'ID de la agencia',
  `nombre_agencia` varchar(45) DEFAULT NULL COMMENT 'Nombre de la agencia',
  `tipo_canal` varchar(45) DEFAULT NULL COMMENT 'Tipo canal',
  `distrito` varchar(45) DEFAULT NULL COMMENT 'Distrito de la agencia',
  `Municipio` varchar(45) DEFAULT NULL COMMENT 'Municipio ubicacion agencia',
  `Departamento` varchar(45) DEFAULT NULL COMMENT 'Departamento ubicacion agencia',
  `fecha_proceso` timestamp NULL DEFAULT NULL COMMENT 'Fecha proceso de los datos',
  `Efectivo` double DEFAULT NULL COMMENT 'Efectivo en agencia',
  PRIMARY KEY (`codigo_agencia`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Para guardar la información de catalogo de agencias'
;
 Dim cadena_agencia As String = "Insert into gladys_lucero_cat_agencias(codigo_agencia,  nombre_agencia, 
 tipo_canal,distrito,Municipio,Departamento,fecha_proceso, Efectivo) values(@codigo_agencia, @nombre_agencia, @tipo_canal,@distrito,
 @Municipio,@Departamento,@fecha_proceso,@Efectivo)"
        


USE catalogos;
CREATE TABLE `gladys_lucero_cat_atms` (
  `FechaCarga` timestamp NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Fecha de carga del sistema',
  `ID`  varchar(45)  NOT NULL COMMENT 'ID del ATM',
  `Nombre` varchar(45) DEFAULT NULL COMMENT 'Nombre del ATM',
  `Estado` varchar(45) DEFAULT NULL COMMENT 'Estado del ATM',
  `Municipio` varchar(45) DEFAULT NULL COMMENT 'Municipio ubicacion AMT',
  `Departamento` varchar(45) DEFAULT NULL COMMENT 'Departamento ubicacion ATM',
  `Dirección` varchar(500) DEFAULT NULL COMMENT 'Direccion del ATM',
  `Saldo` double DEFAULT NULL COMMENT 'Saldo del ATM',
  `Fecha_corte` varchar(45) DEFAULT NULL COMMENT 'Fecha de corte del ATM',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Para guardar la información de catalogo de ATM'
;


USE catalogos;
CREATE TABLE `gladys_lucero_cat_corresponsales` (
  `FechaCarga` timestamp NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Fecha de carga del sistema',
  `NO_CF` int(11) NOT NULL COMMENT 'ID del corresponsal',
  `NO_TIENDA` BIGINT NOT NULL COMMENT 'Numero de la tienda',
  `Nombre_CF` varchar(100) DEFAULT NULL COMMENT 'Nombre del corresponsal',
  `Nombre_Tienda` varchar(100) DEFAULT NULL COMMENT 'Nombre de la tienda donde está el corresponsal',
  `FechaInstalacion` datetime DEFAULT NULL COMMENT 'Fecha proceso de los datos',
  `Distrito` varchar(45) DEFAULT NULL COMMENT 'Distrito ubicacion corresponsal',
  `Departamento` varchar(45) DEFAULT NULL COMMENT 'Departamento ubicacion corresponsal',
  `Direccion_Tienda` varchar(500) DEFAULT NULL COMMENT 'Direccion ubicacion de la tienda',
  `Saldo` varchar(45) DEFAULT NULL COMMENT 'Saldo del corresponsal',
   PRIMARY KEY (`NO_CF`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Para guardar la información de catalogo de corresponsales'
;

USE catalogos;
CREATE TABLE `gladys_lucero_cat_kioskos` (
  `FechaCarga` timestamp NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Fecha de carga del sistema',
  `ID` varchar(45) NOT NULL COMMENT 'ID del kiosko',
  `Ubicacion` varchar(45) DEFAULT NULL COMMENT 'Ubicación del kiosko',
  `Tipo` varchar(45) DEFAULT NULL COMMENT 'Tipo de kiosko',
  `Categoria_interna` varchar(45) DEFAULT NULL COMMENT 'Categoria del kiosko',
  `Municipio` varchar(100) DEFAULT NULL COMMENT 'Municipio ubicacion kiosko',
  `Departamento` varchar(100) DEFAULT NULL COMMENT 'Departamento ubicacion kiosko',
  `Dirección` varchar(500) DEFAULT NULL COMMENT 'Direccion ubicacion kiosko',

  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Para guardar la información de catalogo de kioskos'
;


