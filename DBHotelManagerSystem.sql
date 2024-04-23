create database DBHotelManagerSystem
GO

USE DBHotelManagerSystem
go

create table NhanVien
(
	IDNV INT IDENTITY PRIMARY KEY, -- id tự tăng
	TenNV NVARCHAR(50) NOT NULL,
	GioiTinh NVARCHAR(5),
	NgaySinh Date,
	ChucVu NVARCHAR(50) NOT NULL,
	SDT varchar(11),
	CCCD varchar(15) UNIQUE NOT NULL,
	Mail varchar(50) NOT NULL
)
GO

create table Khach
(
	IDKhach INT IDENTITY PRIMARY KEY, -- id tự tăng
	TenKhach NVARCHAR(50) NULL,
	GioiTinh NVARCHAR(5),
	NgaySinh Date,
	CCCD varchar(15) UNIQUE NOT NULL,
	QuocTich NVARCHAR(50),
	SDT varchar(11),
	Mail varchar(50) NOT NULL UNIQUE
)
GO

create table Phong
(
	MaPhong VARCHAR(20) PRIMARY KEY,
	LoaiPhong NVARCHAR(30),-- 1 giường đơn, 1 giường đôi, 2 giường đơn, 2 giường đôi
	Mota NVARCHAR(500),-- tầm nhìn, diện tích phòng, loại giường, ban công,  
	TrangThai INT NOT NULL, -- -1 đang sửa chữa, 0 phòng trống, 1 đang cho thuê 
	Gia MONEY NOT NULL,
	SucChua INT NOT NULL 
    
)
GO

CREATE TABLE DatTruoc(
	ID INT IDENTITY PRIMARY KEY,
	IDKhach INT REFERENCES dbo.Khach(IDKhach) NOT NULL,
	MaPhong VARCHAR(20) REFERENCES dbo.Phong(MaPhong) NOT NULL,
	NgayNhan DATE NOT NULL,
	NgayTra DATE NOT NULL,
	TienCoc MONEY
)
GO

create table BienLai
(
	IDBienLai INT IDENTITY PRIMARY KEY,
	IDKhach INT references Khach(IDKhach),
	MaPhong VARCHAR(20) references Phong(MaPhong),
	IDNV INT references NhanVien(IDNV),
	TienCoc MONEY NOT NULL DEFAULT 0,
	NgayVao DATETIME NOT NULL,
	NgayRa DateTime,
	TienPhong MONEY,
	TrangThai INT NOT NULL, -- 1 -> đã thanh toán 0 -> chưa thanh toán
	discount MONEY DEFAULT 0, -- giảm giá 
	VAT MONEY DEFAULT 0,
	TongTien MONEY DEFAULT 0,
	TenPhuongThuc NVARCHAR(20), -- chuyển khoản hoặc tiền mặt
)
GO


create table TaiKhoan
(
	SDT VARCHAR(30) UNIQUE NOT NULL,
	Mail varchar(30) UNIQUE NOT NULL, -- đăng nhập bẳng mail hoặc sdt
	MatKhau nvarchar(30) NOT NULL,
	LoaiTaiKhoan varchar(20) NOT NULL, -- quản lí, nhân viên hoặc khách
	PRIMARY KEY(SDT,Mail)	
)
GO

CREATE TABLE KhachInfoBill(
	ID INT IDENTITY PRIMARY KEY,
	IDKhach INT REFERENCES dbo.Khach(IDKhach),
	IDBienLai INT REFERENCES dbo.BienLai(IDBienLai)
)
GO

