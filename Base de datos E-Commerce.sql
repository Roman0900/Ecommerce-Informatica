CREATE DATABASE LaboratorioTIF
ON
( NAME = LaboratorioTIF_dat,
 FILENAME = 'C:\Users\Adm\Desktop\TIF PROG3\Nueva carpeta\LaboratorioTIF.mdf' )
 ---Cambiar la ruta a la carpeta donde se encuentre el repositorio---
GO 

USE LaboratorioTIF

GO

 CREATE TABLE Provincias(
 IdProvincia_pro CHAR(8) NOT NULL,
 Nombre_pro VARCHAR(50) NOT NULL,
 Estado_pro BIT DEFAULT (1) NOT NULL,
 CONSTRAINT PK_Provincias PRIMARY KEY (IdProvincia_pro),
 CONSTRAINT CK_Estado_Provincias CHECK(Estado_pro=1 or Estado_pro=0)
 )

 CREATE TABLE Ciudades(
 IdCiudad_ciu CHAR(8) NOT NULL,
 IdProvincia_ciu CHAR(8) NOT NULL,
 Nombre_ciu VARCHAR(100) NOT NULL,
 Estado_ciu BIT DEFAULT (1) NOT NULL,
 CONSTRAINT PK_Ciudades PRIMARY KEY (IdCiudad_ciu),
 CONSTRAINT FK_Ciudades_Provincia FOREIGN KEY (IdProvincia_ciu) REFERENCES Provincias (IdProvincia_pro),
 CONSTRAINT CK_Estado_Ciudades CHECK(Estado_ciu=1 or Estado_ciu=0)
 )

CREATE TABLE Proveedores(
 IdProveedor_prov CHAR(8) NOT NULL,
 RazonZocial_prov VARCHAR(200) NOT NULL,
 Direccion_prov VARCHAR(200) NULL,
 IdProvincia_prov CHAR(8) NOT NULL,
 IdCiudad_prov CHAR(8) NOT NULL,
 Telefono_prov VARCHAR(20) NULL,
 Web_prov VARCHAR(200) NULL,
 Email_prov VARCHAR(200) NULL,
 Estado_prov BIT DEFAULT(1) NOT NULL,
 CONSTRAINT PK_Proveedor PRIMARY KEY (IdProveedor_prov),
 CONSTRAINT FK_Proveedor_Provincia FOREIGN KEY (IdProvincia_prov) REFERENCES Provincias (IdProvincia_pro),
 CONSTRAINT FK_Proveedor_Ciudadad FOREIGN KEY (IdCiudad_prov) REFERENCES Ciudades (IdCiudad_ciu),
 CONSTRAINT CK_Estado_Proveedores CHECK(Estado_prov=1 or Estado_prov=0)
)

CREATE TABLE Marcas(
IdMarca_mar CHAR(8) NOT NULL,
Nombre_mar VARCHAR(50) NOT NULL,
ImagenURL_mar VARCHAR(200) NULL,
Estado_mar BIT DEFAULT(1) NOT NULL,
CONSTRAINT PK_Marca PRIMARY KEY(IdMarca_mar),
CONSTRAINT CK_Estado_Marcas CHECK(Estado_mar=1 or Estado_mar=0)
)

CREATE TABLE Categorias(
IdCategoria_cat CHAR(8) NOT NULL,
Nombre_cat VARCHAR(100) NOT NULL,
Estado_cat BIT DEFAULT (1) NOT NULL,
CONSTRAINT PK_Categoria PRIMARY KEY(IdCategoria_cat),
CONSTRAINT CK_Estado_Catergorias CHECK(Estado_cat=1 or Estado_cat=0)
)

CREATE TABLE Articulos(
IdArticulo_ar CHAR(8) NOT NULL,
IdProveedor_ar CHAR(8) NOT NULL,
IdMarca_ar CHAR(8) NOT NULL,
IdCategoria_ar CHAR(8) NOT NULL,
Descripcion_ar VARCHAR(100) NOT NULL,
Stock_ar INT NOT NULL,
ImagenURL_ar VARCHAR(200) NULL,
PrecioUnitario_ar Decimal(8,2) DEFAULT(0.00) NULL,
Estado_ar BIT DEFAULT(1) NOT NULL,
CONSTRAINT PK_Articulos PRIMARY KEY (IdArticulo_ar),
CONSTRAINT FK_Articulos_Proveedores FOREIGN KEY (IdProveedor_ar) REFERENCES Proveedores(IdProveedor_prov),
CONSTRAINT FK_Articulos_Marcas FOREIGN KEY (IdMarca_ar) REFERENCES Marcas (IdMarca_mar),
CONSTRAINT FK_Articulos_Categorias FOREIGN KEY (IdCategoria_ar) REFERENCES Categorias (IdCategoria_cat),
CONSTRAINT CK_Estado_Articulos CHECK(Estado_ar=1 or Estado_ar=0),
CONSTRAINT CK_Stock_Articulos CHECK(Stock_ar>=0),
CONSTRAINT CK_PrecioUnitario_Articulos CHECK(PrecioUnitario_ar>=0)
)

CREATE TABLE Personas(
Dni_per CHAR(8) NOT NULL,
Nombre_per VARCHAR(50) NOT NULL,
Apellido_per VARCHAR(50) NOT NULL,
Password_per VARCHAR(20) NOT NULL,
Telefono_per CHAR(12) NULL,
Email_per VARCHAR(100) NOT NULL,
Tipo_per BIT DEFAULT (0) NOT NULL,
---0 es usuario
---1 es admin
Estado_per BIT DEFAULT(1) NOT NULL,
CONSTRAINT PK_Persona PRIMARY KEY (Dni_per),
CONSTRAINT CK_Estado_Personas CHECK(Estado_per=1 or Estado_per=0)
)

CREATE TABLE FormaPago(
IdFormaPago_fp CHAR(4) NOT NULL,
Nombre_fp VARCHAR(50) NOT NULL,
Estado_fp BIT DEFAULT(1) NOT NULL,
CONSTRAINT PK_FormaPago PRIMARY KEY (IdFormaPago_fp),
CONSTRAINT CK_Estado_FormaPago CHECK(Estado_fp=1 or Estado_fp=0)
)

CREATE TABLE Facturas(
IdFactura_fa CHAR(8) NOT NULL,
Dni_fa CHAR(8) NOT NULL,
IdFormaPago_fa CHAR(4) NOT NULL,
Fecha_fa DATETIME DEFAULT(GETDATE()) NOT NULL,
TotalFactura_fa DECIMAL (10,2) DEFAULT(0.00) NULL,
Estado_fa BIT DEFAULT(1) NOT NULL,
CONSTRAINT PK_Factura PRIMARY KEY (IdFactura_fa),
CONSTRAINT FK_Factura_Personas FOREIGN KEY (Dni_fa) REFERENCES Personas (Dni_per),
CONSTRAINT FK_Factura_FormaPago FOREIGN KEY (IdFormaPago_fa) REFERENCES FormaPago (IdFormaPago_fp),
CONSTRAINT CK_TotalFactura_Facturas CHECK(TotalFactura_fa >=0),
CONSTRAINT CK_Estado_Facturas CHECK(Estado_fa=1 or Estado_fa=0)
)

CREATE TABLE DetalleFactura(
IdFactura_df CHAR(8) NOT NULL,
IdArticulo_df CHAR(8) NOT NULL,
Cantidad_df INT DEFAULT(0) NOT NULL,
PrecioUnitario_df DECIMAL(8,2) DEFAULT(0.00) NULL,
Estado_df BIT DEFAULT(1) NOT NULL,
CONSTRAINT PK_DetalleFactura PRIMARY KEY (IdFactura_df,idArticulo_df),
CONSTRAINT FK_DetalleFactura_Factura FOREIGN KEY (IdFactura_df) REFERENCES Facturas (IdFactura_fa),
CONSTRAINT FK_DetalleFactura_Articulo FOREIGN KEY (IdArticulo_df) REFERENCES Articulos (IdArticulo_ar),
CONSTRAINT CK_Estado_DetalleFactura CHECK(Estado_df=1 or Estado_df=0),
CONSTRAINT CK_Cantidad_DetalleFactura CHECK(Cantidad_Df >=0),
CONSTRAINT CK_PrecioUnitario_DetalleFactura CHECK(PrecioUnitario_df>=0)
)


---INSERTS PARA EL CODIGO---

INSERT INTO Provincias (IdProvincia_pro,Nombre_pro)
SELECT 'PRO001','Salta' UNION
SELECT 'PRO002','Tucuman' UNION
SELECT 'PRO003','Cordoba' UNION
SELECT 'PRO004','Buenos Aires' UNION
SELECT 'PRO005','Santa Cruz'
GO

INSERT INTO Ciudades (IdCiudad_ciu,IdProvincia_ciu,Nombre_ciu)
SELECT 'CIU001','PRO003','San Francisco' UNION
SELECT 'CIU002','PRO003','Arroyito' UNION
SELECT 'CIU003','PRO002','Monteros' UNION
SELECT 'CIU004','PRO002','Simoca' UNION
SELECT 'CIU005','PRO004','Pacheco' UNION
SELECT 'CIU006','PRO004','San Isidro' UNION
SELECT 'CIU007','PRO005','Pico Truncado' UNION
SELECT 'CIU008','PRO005','El Calafate' UNION
SELECT 'CIU009','PRO001','Tartagal' UNION
SELECT 'CIU010','PRO001','Jose de Metan'
GO

INSERT INTO Proveedores (IdProveedor_prov,IdCiudad_prov,IdProvincia_prov,RazonZocial_prov,Direccion_prov,Telefono_prov,Web_prov,Email_prov)
SELECT 'PROV001','CIU004','PRO002','Infotask','Alvarado 789','48561289','Infotask.com','infotask@gmail.com' UNION
SELECT 'PROV002','CIU008','PRO005','El Foco','Mendoza 453','1129634895','ElFoco.com','elfoco@gmail.com' 
GO



insert into dbo.Marcas(IdMarca_mar,Nombre_mar,ImagenURL_mar)values('MAR001','Gigabyte','');
insert into dbo.Marcas(IdMarca_mar,Nombre_mar,ImagenURL_mar)values('MAR002','Sentey','');
insert into dbo.Marcas(IdMarca_mar,Nombre_mar,ImagenURL_mar)values('MAR003','Zotac','');
insert into dbo.Marcas(IdMarca_mar,Nombre_mar,ImagenURL_mar)values('MAR004','AMD','');
insert into dbo.Marcas(IdMarca_mar,Nombre_mar,ImagenURL_mar)values('MAR005','Intel','');
insert into dbo.Marcas(IdMarca_mar,Nombre_mar,ImagenURL_mar)values('MAR006','Philips','');
insert into dbo.Marcas(IdMarca_mar,Nombre_mar,ImagenURL_mar)values('MAR007','HP','');
insert into dbo.Marcas(IdMarca_mar,Nombre_mar,ImagenURL_mar)values('MAR008','Logitech','');
insert into dbo.Marcas(IdMarca_mar,Nombre_mar,ImagenURL_mar)values('MAR009','Genius','');
insert into dbo.Marcas(IdMarca_mar,Nombre_mar,ImagenURL_mar)values('MAR010','Nisuta','');
insert into dbo.Marcas(IdMarca_mar,Nombre_mar,ImagenURL_mar)values('MAR011','Redragon','');
insert into dbo.Marcas(IdMarca_mar,Nombre_mar,ImagenURL_mar)values('MAR012','Samsung','');
--marcas

insert into dbo.Categorias(IdCategoria_cat,Nombre_cat)values('CAT001','Placas de Video');
insert into dbo.Categorias(IdCategoria_cat,Nombre_cat)values('CAT002','Monitores');
insert into dbo.Categorias(IdCategoria_cat,Nombre_cat)values('CAT003','Periféricos');
insert into dbo.Categorias(IdCategoria_cat,Nombre_cat)values('CAT004','Gabientes');
insert into dbo.Categorias(IdCategoria_cat,Nombre_cat)values('CAT005','Procesadores');

--articulos


insert into dbo.Articulos(IdArticulo_ar,idProveedor_ar,idMarca_ar,IdCategoria_ar,Descripcion_ar,Stock_ar,ImagenURL_ar,PrecioUnitario_ar)values('ART001','PROV001','MAR001','CAT002','Monitor LG 32" 32UK550-B UHD 4K Dynamic Action Sync HDR10 ',5,'~/Imagenes/monitorLG.jpg',36650.0);
insert into dbo.Articulos(IdArticulo_ar,idProveedor_ar,idMarca_ar,IdCategoria_ar,Descripcion_ar,Stock_ar,ImagenURL_ar,PrecioUnitario_ar)values('ART002','PROV002','MAR002','CAT004','Gabinete Kolink Void ARGB ATX Vidrio Templado',2,'~/Imagenes/gabinete.jpg',6450.0);
insert into dbo.Articulos(IdArticulo_ar,idProveedor_ar,idMarca_ar,IdCategoria_ar,Descripcion_ar,Stock_ar,ImagenURL_ar,PrecioUnitario_ar)values('ART003','PROV002','MAR005','CAT003','Mouse Glorious Model D Minus - Matte Black',7,'~/Imagenes/mouse.jpg',7030.0);
insert into dbo.Articulos(IdArticulo_ar,idProveedor_ar,idMarca_ar,IdCategoria_ar,Descripcion_ar,Stock_ar,ImagenURL_ar,PrecioUnitario_ar)values('ART004','PROV001','MAR005','CAT005','Procesador Intel Core i7 9700F 4.7GHz Turbo 1151 Coffee Lake',5,'~/Imagenes/intelI7.jpg',36650.0);
insert into dbo.Articulos(IdArticulo_ar,idProveedor_ar,idMarca_ar,IdCategoria_ar,Descripcion_ar,Stock_ar,ImagenURL_ar,PrecioUnitario_ar)values('ART005','PROV001','MAR001','CAT001','Placa de Video Asrock Radeon RX 6900 XT 16GB GDDR6 PCIe 4.0 ',1,'~/Imagenes/placavideoAsrock.jpg',36650.0);
insert into dbo.Articulos(IdArticulo_ar,idProveedor_ar,idMarca_ar,IdCategoria_ar,Descripcion_ar,Stock_ar,ImagenURL_ar,PrecioUnitario_ar)values('ART006','PROV001','MAR005','CAT005','Procesador i5 7400',5,'~/Imagenes/i5.jpg',50000.0);
insert into dbo.Articulos(IdArticulo_ar,idProveedor_ar,idMarca_ar,IdCategoria_ar,Descripcion_ar,Stock_ar,ImagenURL_ar,PrecioUnitario_ar)values('ART007','PROV002','MAR007','CAT002','Monitor HP 24"',5,'~/Imagenes/monitorHP.jpg',40500.0);
insert into dbo.Articulos(IdArticulo_ar,idProveedor_ar,idMarca_ar,IdCategoria_ar,Descripcion_ar,Stock_ar,ImagenURL_ar,PrecioUnitario_ar)values('ART008','PROV002','MAR006','CAT003','Mouse Philips - Black',7,'~/Imagenes/mousePhilips.jpg',5030.0);
insert into dbo.Articulos(IdArticulo_ar,idProveedor_ar,idMarca_ar,IdCategoria_ar,Descripcion_ar,Stock_ar,ImagenURL_ar,PrecioUnitario_ar)values('ART009','PROV001','MAR004','CAT001','Placa de Video Gygabite Radeon RX 570',5,'~/Imagenes/placavideoGigabyte.jpg',110500.0);
insert into dbo.Articulos(IdArticulo_ar,idProveedor_ar,idMarca_ar,IdCategoria_ar,Descripcion_ar,Stock_ar,ImagenURL_ar,PrecioUnitario_ar)values('ART010','PROV002','MAR002','CAT004','Gabinete Sentey GS-6008 Stealth II Fan Led x 2 Usb 3.0',3,'~/Imagenes/gabineteSentey.jpg',7050.0);
insert into dbo.Articulos(IdArticulo_ar,idProveedor_ar,idMarca_ar,IdCategoria_ar,Descripcion_ar,Stock_ar,ImagenURL_ar,PrecioUnitario_ar)values('ART011','PROV001','MAR008','CAT003','Teclado Logitech G413 Mechanical Carbon',5,'~/Imagenes/tecladoLogitech.jpg',7030.0);
insert into dbo.Articulos(IdArticulo_ar,idProveedor_ar,idMarca_ar,IdCategoria_ar,Descripcion_ar,Stock_ar,ImagenURL_ar,PrecioUnitario_ar)values('ART012','PROV001','MAR009','CAT003','Teclado Genius Gaming Scorpion K8 C',5,'~/Imagenes/tecladoGenius.jpg',3530.0);
insert into dbo.Articulos(IdArticulo_ar,idProveedor_ar,idMarca_ar,IdCategoria_ar,Descripcion_ar,Stock_ar,ImagenURL_ar,PrecioUnitario_ar)values('ART013','PROV002','MAR011','CAT003','Auriculares Redragon Siren 2',4,'~/Imagenes/auricularRedragon.jpg',9000.0);
insert into dbo.Articulos(IdArticulo_ar,idProveedor_ar,idMarca_ar,IdCategoria_ar,Descripcion_ar,Stock_ar,ImagenURL_ar,PrecioUnitario_ar)values('ART014','PROV001','MAR005','CAT005','Procesador I3 10100',5,'~/Imagenes/procesadorI3.jpg',25000.0);
insert into dbo.Articulos(IdArticulo_ar,idProveedor_ar,idMarca_ar,IdCategoria_ar,Descripcion_ar,Stock_ar,ImagenURL_ar,PrecioUnitario_ar)values('ART015','PROV002','MAR012','CAT002','Monitor Samsung 22"',5,'~/Imagenes/monitorSamsung.jpg',27500.0);
insert into dbo.Articulos(IdArticulo_ar,idProveedor_ar,idMarca_ar,IdCategoria_ar,Descripcion_ar,Stock_ar,ImagenURL_ar,PrecioUnitario_ar)values('ART0016','PROV001','MAR001','CAT001','Placa de Video Gigabyte Radeon RX 6800',3,'~/Imagenes/placavideoGigabyte2.jpg',250650.0);
insert into dbo.Articulos(IdArticulo_ar,idProveedor_ar,idMarca_ar,IdCategoria_ar,Descripcion_ar,Stock_ar,ImagenURL_ar,PrecioUnitario_ar)values('ART017','PROV002','MAR002','CAT004','Gabinete Sentey Vorax Gs-6003',3,'~/Imagenes/gabineteSentey2.jpg',8050.0);
--personas

insert into dbo.Personas(Dni_per,Nombre_per,Apellido_per,Password_per,Telefono_per,Email_per,Tipo_per)values('20011780','Ainara','Lucia','abc123','12345','lainara@hotmail.com',0);
insert into dbo.Personas(Dni_per,Nombre_per,Apellido_per,Password_per,Telefono_per,Email_per,Tipo_per)values('30678902','López','Walter','efg456','54321','wlopez@gmail.com',0);
insert into dbo.Personas(Dni_per,Nombre_per,Apellido_per,Password_per,Telefono_per,Email_per,Tipo_per)values('31001174','Mancilla','Lucas','jik908','0525','lainara@hotmail.com',0);
insert into dbo.Personas(Dni_per,Nombre_per,Apellido_per,Password_per,Telefono_per,Email_per,Tipo_per)values('34011780','Escobar','Santiafo','rty603','1801','wlopez@gmail.com',0);
insert into dbo.Personas(Dni_per,Nombre_per,Apellido_per,Password_per,Telefono_per,Email_per,Tipo_per)values('33011788','Gimenez','Solanage','vbn832','2021','lainara@hotmail.com',0);
insert into dbo.Personas(Dni_per,Nombre_per,Apellido_per,Password_per,Telefono_per,Email_per,Tipo_per)values('35011567','Gauna','Esteban','yui555','12345','wlopez@gmail.com',0);
insert into dbo.Personas(Dni_per,Nombre_per,Apellido_per,Password_per,Telefono_per,Email_per,Tipo_per)values('30000000','admin','admin','admin123','0555','myadmin@gmail.com',1);

--forma de pago 
insert into dbo.FormaPago(IdFormaPago_fp,Nombre_fp)values('FP01','Efectivo');
insert into dbo.FormaPago(IdFormaPago_fp,Nombre_fp)values('FP02','Tarjeta');
insert into dbo.FormaPago(IdFormaPago_fp,Nombre_fp)values('FP03','Tranferencia');

--facturas
insert into dbo.Facturas(IdFactura_fa,Dni_fa,idFormaPago_fa,Fecha_fa,TotalFactura_fa)values('FAC001','20011780','FP01',GETDATE(),0.1);
insert into dbo.Facturas(IdFactura_fa,Dni_fa,idFormaPago_fa,Fecha_fa,TotalFactura_fa)values('FAC002','35011567','FP02',GETDATE(),0.1);
insert into dbo.Facturas(IdFactura_fa,Dni_fa,idFormaPago_fa,Fecha_fa,TotalFactura_fa)values('FAC003','34011780','FP02',GETDATE(),0.1);
insert into dbo.Facturas(IdFactura_fa,Dni_fa,idFormaPago_fa,Fecha_fa,TotalFactura_fa)values('FAC004','34011780','FP03',GETDATE(),0.1);
insert into dbo.Facturas(IdFactura_fa,Dni_fa,idFormaPago_fa,Fecha_fa,TotalFactura_fa)values('FAC005','30678902','FP01',GETDATE(),0.1);

--detalle factura

insert into dbo.DetalleFactura(IdFactura_df,idArticulo_df,Cantidad_df,PrecioUnitario_df)values('FAC001','ART001',40,36650.00);
insert into dbo.DetalleFactura(idFactura_df,idArticulo_df,Cantidad_df,PrecioUnitario_df)values('FAC001','ART002',50,6450.00);
insert into dbo.DetalleFactura(idFactura_df,idArticulo_df,Cantidad_df,PrecioUnitario_df)values('FAC003','ART003',80,7030.00);
insert into dbo.DetalleFactura(idFactura_df,idArticulo_df,Cantidad_df,PrecioUnitario_df)values('FAC002','ART002',100,36650.00);


---PROCEDIMIENTOS---

---Articulos---
CREATE PROCEDURE spAgregarProducto
@IdProducto CHAR(8),@IDProveedor CHAR(8),
@IDMarca CHAR(8),@IDCategoria CHAR(8),
@NombreArticulo VARCHAR(100),@Stock INT,
@PrecioUnitario DECIMAL(8,2)
AS 
INSERT INTO Articulos (IdArticulo_ar,IdProveedor_ar,
IdMarca_ar,IdCategoria_ar,
Descripcion_ar,Stock_ar,PrecioUnitario_ar)

SELECT @IdProducto,@IDProveedor,@IDMarca,@IDCategoria,
@NombreArticulo,@Stock,@PrecioUnitario

GO

CREATE PROCEDURE spUpdateProducto
@IdProducto CHAR(8),@IDProveedor CHAR(8),
@IDMarca CHAR(8),@IDCategoria CHAR(8),
@NombreArticulo VARCHAR(100),@Stock INT,
@PrecioUnitario DECIMAL(8,2)
AS
UPDATE Articulos SET
IdProveedor_ar=@IDProveedor,
IdMarca_ar=@IDMarca,
IdCategoria_ar=@IDCategoria,
Descripcion_ar=@NombreArticulo,
PrecioUnitario_ar=@PrecioUnitario,
Stock_ar=@Stock
WHERE IdArticulo_ar=@IdProducto

GO

CREATE PROCEDURE spEliminarProducto
@IdProducto CHAR (8)
AS
UPDATE Articulos SET Estado_ar=0 WHERE IdArticulo_ar = @IdProducto

GO

---Proveedores---
CREATE PROCEDURE spAgregarProveedor
@RazonZocial VARCHAR(200), @IdProveedor CHAR(8),
@Direccion VARCHAR(200),@IdProvincia CHAR(8),
@IdCiudad CHAR (8), @Telefono VARCHAR(20),
@Web VARCHAR(200), @Mail VARCHAR(200)
AS
INSERT INTO Proveedores(IdProveedor_prov,IdProvincia_prov,
IdCiudad_prov,RazonZocial_prov,Direccion_prov,Telefono_prov,
Web_prov,Email_prov)

SELECT @IdProveedor,@IdProvincia,@IdCiudad,@RazonZocial,@Direccion,
@Telefono,@Web,@Mail

GO

CREATE PROCEDURE spUpdateProveedor
@RazonZocial VARCHAR(200), @IdProveedor CHAR(8),
@Direccion VARCHAR(200),@IdProvincia CHAR(8),
@IdCiudad CHAR (8), @Telefono VARCHAR(20),
@Web VARCHAR(200), @Mail VARCHAR(200)
AS

UPDATE Proveedores SET 
IdProvincia_prov = @IdProvincia,
IdCiudad_prov= @IdCiudad,
RazonZocial_prov = @RazonZocial,
Direccion_prov = @Direccion,
Telefono_prov = @Telefono,
Web_prov = @Web,
Email_prov = @Mail
WHERE IdProveedor_prov=@IdProveedor

GO


CREATE PROCEDURE spEliminarProveedor
@IdProveedor CHAR(8)
AS

UPDATE Proveedores SET Estado_prov=0 WHERE IdProveedor_prov=@IdProveedor

GO

---MARCAS---
CREATE PROCEDURE spAgregarMarca
@IDMarca CHAR(8), @NombreMarca VARCHAR(50)
AS
INSERT INTO Marcas (IdMarca_mar,Nombre_mar)
SELECT @IdMarca,@NombreMarca

GO


CREATE PROCEDURE spUpdateMarca
@IDMarca CHAR(8), @NombreMarca VARCHAR(50)
AS
UPDATE MARCAS SET Nombre_mar=@NombreMarca WHERE IdMarca_mar=@IDMarca
GO


CREATE PROCEDURE spEliminarMarca
@IDMarca CHAR(8)
AS
UPDATE Marcas SET Estado_mar=0 WHERE IdMarca_mar=@IDMarca
GO

---CATEGORIAS---
CREATE PROCEDURE spAgregarCategoria
@IDCategoria CHAR(8), @NombreCategoria VARCHAR(50)
AS
INSERT INTO Categorias(IdCategoria_cat,Nombre_cat)
SELECT @IDCategoria,@NombreCategoria

GO


CREATE PROCEDURE spUpdateCategoria
@IDCategoria CHAR(8), @NombreCategoria VARCHAR(50)
AS
UPDATE Categorias SET Nombre_cat=@NombreCategoria WHERE IdCategoria_cat=@IDCategoria
GO


CREATE PROCEDURE spEliminarCategoria
@IDCategoria CHAR(8)
AS
UPDATE Categorias SET Estado_cat=0 WHERE IdCategoria_cat=@IDCategoria
GO


--Personas
CREATE PROCEDURE spAgregarPersona
@DNIPersona CHAR(8),@NombrePersona VARCHAR(50),
@ApellidoPersona VARCHAR(50),@Contraseña VARCHAR(20),
@Telefono CHAR(12),@Mail VARCHAR(100)
AS 
INSERT INTO Personas(Dni_per,Nombre_per,
Apellido_per,Password_per,
Telefono_per,Email_per)

SELECT @DNIPersona,@NombrePersona,@ApellidoPersona,@Contraseña,@Telefono,
@Mail

GO

---Provincias---
CREATE PROCEDURE spAgregarProvincia
@IDProvincia CHAR(8), @NombreProvincia VARCHAR(50)
AS
INSERT INTO Provincias(IdProvincia_pro,Nombre_pro)
SELECT @IDProvincia,@NombreProvincia

GO


CREATE PROCEDURE spUpdateProvincia
@IDProvincia CHAR(8), @NombreProvincia VARCHAR(50)
AS
UPDATE Provincias SET Nombre_pro=@NombreProvincia WHERE IdProvincia_pro=@IDProvincia
GO


CREATE PROCEDURE spEliminarProvincia
@IDProvincia CHAR(8)
AS
UPDATE Provincias SET Estado_pro=0 WHERE IdProvincia_pro=@IDProvincia
GO


---Ciudades---
CREATE PROCEDURE spAgregarCiudad
@IDCiudad CHAR(8), @IDProvincia CHAR(8), @NombreCiudad VARCHAR(50)
AS
INSERT INTO Ciudades(IdCiudad_ciu,IdProvincia_ciu,Nombre_ciu)
SELECT @IDCiudad,@IDProvincia,@NombreCiudad

GO


CREATE PROCEDURE spUpdateCiudad
@IDCiudad CHAR(8), @IDProvincia CHAR(8), @NombreCiudad VARCHAR(50)
AS
UPDATE Ciudades SET Nombre_ciu=@NombreCiudad, IdProvincia_ciu=@IDProvincia WHERE IdCiudad_ciu=@IDCiudad
GO


CREATE PROCEDURE spEliminarCiudad
@IDCiudad CHAR(8)
AS
UPDATE Ciudades SET Estado_ciu=0 WHERE IdCiudad_ciu=@IDCiudad
GO	


---Facturas---
CREATE PROCEDURE spAgregarFactura
@IDFactura CHAR(8),
@DNI CHAR(8),@IDFormapago CHAR(4),@Total DECIMAL
AS 
INSERT INTO Facturas(IdFactura_fa ,Dni_fa,IdFormaPago_fa,TotalFactura_fa)

SELECT @IDFactura,@DNI,@IDFormapago,@Total

GO



CREATE PROCEDURE spEliminarFactura
@IDFactura CHAR(8)
AS
UPDATE Facturas SET Estado_fa=0 WHERE IdFactura_fa=@IDFactura
GO

---DetalleFactura---
CREATE PROCEDURE spAgregarDetalleFactura
@IDFactura CHAR(8),
@IDArticulo CHAR(8),@Cantidad int, @PrecioUnitario DECIMAL 

AS 
INSERT INTO DetalleFactura(IdFactura_df,IdArticulo_df,Cantidad_df,PrecioUnitario_df)

SELECT @IDFactura,@IDArticulo,@Cantidad,@PrecioUnitario
GO

---VISTAS---

---VISTAS---
CREATE VIEW ARTICULOSADMIN
AS
SELECT A.idarticulo_ar AS 'CodigoArticulo',P.RazonZocial_prov AS 'Proveedor',m.Nombre_mar AS 'Marca',c.nOMBRE_CAT AS 'Categoria',a.descripcion_ar AS 'Articulo',a.stock_ar AS 'Stock',CONCAT('$',a.preciounitario_ar) AS 'Precio' FROM Articulos AS A INNER JOIN 
Proveedores AS P ON P.IdProveedor_prov=A.IdProveedor_ar 
INNER JOIN Marcas AS M ON M.IdMarca_mar=A.IdMarca_ar 
INNER JOIN Categorias AS C ON C.IdCategoria_cat= A.IdCategoria_ar
WHERE A.Estado_ar=1
GO

CREATE VIEW PROVEEDORESADMIN
AS
SELECT P.IdProveedor_prov AS 'CodigoProveedor', P.RazonZocial_prov AS 'Proveedor' ,P.Direccion_prov AS 'Direccion',V.NOMBRE_PRO AS 'Provincia' ,Z.NOMBRE_CIU AS 'Ciudad',
P.Telefono_prov AS 'Telefono',P.Web_prov AS 'PaginaWeb', P.Email_prov AS 'Email' FROM Proveedores AS P
INNER JOIN Provincias AS V ON P.IdProvincia_prov=V.IdProvincia_pro
INNER JOIN Ciudades AS Z ON P.IdCiudad_prov=Z.IdCiudad_ciu
WHERE P.Estado_prov=1
GO

CREATE VIEW ARTICULOSCLIENTE2
AS
SELECT A.idarticulo_ar AS 'CodigoArticulo',a.ImagenURL_ar AS 'Imagen',m.Nombre_mar AS 'Marca',m.IdMarca_mar AS 'CodigoMarca',c.nOMBRE_CAT AS 'Categoria',c.IdCategoria_cat AS 'CodigoCategoria',a.descripcion_ar AS 'Articulo',a.stock_ar AS 'Stock',CONCAT('$',a.preciounitario_ar) AS 'Precio' FROM Articulos AS A
INNER JOIN Marcas AS M ON M.IdMarca_mar=A.IdMarca_ar 
INNER JOIN Categorias AS C ON C.IdCategoria_cat= A.IdCategoria_ar
WHERE A.Estado_ar=1 AND A.Stock_ar>0
GO

CREATE VIEW FACTURASADMIN
AS 
SELECT F.IdFactura_fa AS 'IDFACTURA' ,F.Dni_fa AS 'DNIFACTURA',CONCAT(P.Nombre_per,' ',P.Apellido_per) AS 'NOMBREDNIFACTURA', fp.Nombre_fp AS 'FORMAPAGO', CONVERT(VARCHAR,CONVERT(DATE,F.Fecha_fa)) AS 'FECHAFACTURA', CONCAT('$ ',F.TotalFactura_fa) AS 'TOTALFACTURA' FROM FACTURAS AS F
INNER JOIN FormaPago as fp on f.IdFormaPago_fa=fp.IdFormaPago_fp 
INNER JOIN Personas AS P on f.Dni_fa=p.Dni_per
WHERE f.Estado_fa=1
GO

CREATE VIEW DETALLEFACTURASADMIN
AS 
SELECT D.IdFactura_df AS 'IDFACTURA', A.DESCRIPCION_AR AS 'ARTICULO', D.Cantidad_df AS 'CANTIDAD', concat('$ ',D.PrecioUnitario_df) AS 'PRECIOUNI' FROM DetalleFactura AS D
INNER JOIN Articulos AS A ON D.IdArticulo_df=A.IdArticulo_ar
WHERE D.Estado_df=1
GO




