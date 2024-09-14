--Tạo 1 cơ sở dữ liệu tên QLNiceShoes
CREATE DATABASE QLNiceShoes
GO

--Sử dụng QLNiceShoes
USE QLNiceShoes
GO

--Tạo bảng (Sản phẩm)
Create table SanPham
(
  Id int Primary Key Identity(1,1),
  IdSP int,
  TenSP nvarchar(50),
  AnhSP nvarchar(100),
  GiaSP decimal(18,2),
  IdThuongHieu int
)
GO

--Tạo bảng (Thương hiệu)
Create table ThuongHieu
(
  Id int Primary Key Identity(1,1),
  IdThuongHieu int,
  TenThuongHieu nvarchar(50)
)
GO


--Tạo bảng cho chức năng đặt hàng (Đặt hàng)
Create table DatHang
(
  Id int primary key identity,
  IdKH int,
  TenKH varchar(50),
  TenSP nvarchar(50),
  TrangThaiDH datetime
)
GO

--Tạo bảng cho chức năng đặt hàng (Chi tiết đơn hàng)
Create table ChiTietDH
( 
  Id int primary key identity,
  IdSP int,
  AnhSP nvarchar(100),
  MoTaSP nvarchar(500),
  SoLuong int
)
GO

--Tạo bảng cho chức năng đăng kí-đăng nhập cho khách hàng (Đăng kí_Đăng nhập khách hàng)
Create table DangKi_DangNhapKH
(
 Id int primary key identity(1,1),
 IdKH int,
 TenKH varchar(50),
 Email varchar(50),
 MatKhau varchar(255)
)
GO

--Tạo bảng cho chức năng đăng nhập dành cho người quản trị (Đăng nhập người quản trị )
Create table DangNhapNQT
(
 Id int primary key identity(1,1),
 IdNQT int,
 EmailNQT varchar(50),
 MatKhauNQT varchar(255)
)
GO

--Thêm dữ liệu vào bảng Thương hiệu 
Insert into ThuongHieu values(011,'NIKE')
Insert into ThuongHieu values(012,'ADIDAS')
Insert into ThuongHieu values(013,'REEBOK')
GO

--Thêm dữ liệu vào bảng Sản phẩm 
Insert into SanPham values(01510,'REEBOK FLEXAGON TR 3','s1.jpg',79.00,013)
Insert into SanPham values(01511,'REEBOK PUMP OMNI ZONE','s2.jpg',59.00,013)
Insert into SanPham values(01512,'REEBOK CLASSIC LEATHER','s3.jpg',89.00,013)
Insert into SanPham values(01513,'NIKE DRUNK HIGH PANDA','s4.jpg',149.00,011)
Insert into SanPham values(01514,'NIKE AIR MAX AP','s5.jpg',259.00,011)
Insert into SanPham values(01515,'AIR JORDAN 1 MID','s6.jpg',99.00,011)
Insert into SanPham values(01516,'ADIDAS ULTRABOOST 4.0 DNA','s7.jpg',149.00,012)
Insert into SanPham values(01517,'ADIDAS ULTRABOOST 22','s8.jpg',109.00,012)
Insert into SanPham values(01518,'ADIDAS ZG21','s9.jpg',199.00,012)
GO
