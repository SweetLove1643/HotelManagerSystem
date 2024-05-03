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
	MatKhau nvarchar(70) NOT NULL,
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

CREATE TRIGGER Unique_CCCD_NhanVien
ON dbo.NhanVien
AFTER INSERT, UPDATE
AS
BEGIN
	IF EXISTS(SELECT 1 FROM Inserted AS i JOIN dbo.NhanVien AS n ON i.CCCD = n.CCCD WHERE i.IDNV <> n.IDNV)
	BEGIN
		RAISERROR('CCCD phải là duy nhất.', 16, 1)
		ROLLBACK TRANSACTION
	END
END
GO

CREATE TRIGGER Unique_CCCD_Khach
ON dbo.Khach
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS(SELECT 1 FROM Inserted AS i JOIN dbo.Khach AS k ON i.Mail = k.Mail WHERE i.IDKhach <> k.IDKhach)
	BEGIN
		RAISERROR('Mail phải là duy nhất', 16, 1)
		ROLLBACK TRANSACTION
	END
END
GO

CREATE TRIGGER Unique_MaPhong_Phong
ON dbo.Phong
AFTER INSERT, UPDATE
AS
BEGIN
	IF EXISTS(SELECT 1 FROM Inserted AS i JOIN dbo.Phong AS p ON i.MaPhong = p.MaPhong WHERE i.MaPhong <> p.MaPhong)
	BEGIN
		RAISERROR('Mã phòng phải là duy nhất', 16, 1)
		ROLLBACK TRANSACTION
	END
END
GO

CREATE TRIGGER Check_NgayTra_DatTruoc
ON dbo.DatTruoc
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS(SELECT 1 FROM Inserted WHERE Inserted.NgayTra <= Inserted.NgayNhan)
	BEGIN
	    RAISERROR('Thời gian trả phòng phải lơn hơn thời gian đặt', 16, 1)
		ROLLBACK TRANSACTION
	END
END
GO

CREATE TRIGGER Update_Tongtien_BienLai
ON dbo.BienLai
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE dbo.BienLai
	SET TongTien = CASE
		WHEN NgayRa IS NOT NULL THEN
			DATEDIFF(DAY, NgayVao, NgayRa) * TienPhong - discount + VAT
		ELSE 0
	END,
	TrangThai = CASE WHEN NgayRa IS NOT NULL THEN 1 ELSE 0 END 
END
GO

CREATE TRIGGER Unique_SDT_Mail_TaiKhoan
ON dbo.TaiKhoan
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS(SELECT 1 FROM Inserted AS i JOIN dbo.TaiKhoan AS t ON t.SDT = i.SDT WHERE t.SDT <> i.SDT)
	BEGIN
	    RAISERROR('Số điện thoại phải là duy nhất', 16, 1)
		ROLLBACK TRANSACTION
	END
	
	IF EXISTS(SELECT 1 FROM Inserted AS i JOIN dbo.TaiKhoan AS t ON t.Mail = i.Mail WHERE t.Mail <> i.Mail)
	BEGIN
	    RAISERROR('Mail phải là duy nhất', 16, 1)
		ROLLBACK TRANSACTION
	END
END
GO



CREATE PROCEDURE CreateNewAccount 
	@SDT VARCHAR(30), @Mail VARCHAR(30), @Password NVARCHAR(30), @Accounttype NVARCHAR(20)
AS
BEGIN
    INSERT INTO dbo.TaiKhoan
    (
        SDT,
        Mail,
        MatKhau,
        LoaiTaiKhoan
    )
    VALUES
    (   @SDT,  -- SDT - varchar(30)
        @Mail,  -- Mail - varchar(30)
        @Password, -- MatKhau - nvarchar(30)
        @Accounttype -- LoaiTaiKhoan - nvarchar(20)
        )
END
GO

-- EXEC dbo.CreateNewAccount @SDT, @Mail, @Password, @Accounttype
GO

CREATE PROCEDURE CreateNewGuest
@Guestname NVARCHAR(50),
@Sex NVARCHAR(5),
@DateOfBrith DATE,
@CCCD VARCHAR(15),
@Nationality NVARCHAR(50),
@Phone VARCHAR(11),
@Mail VARCHAR(50)
AS
BEGIN
    INSERT INTO dbo.Khach
    (
        TenKhach,
        GioiTinh,
        NgaySinh,
        CCCD,
        QuocTich,
        SDT,
        Mail
    )
    VALUES
    (   @Guestname, -- TenKhach - nvarchar(50)
        @Sex, -- GioiTinh - nvarchar(5)
        @DateOfBrith, -- NgaySinh - date
        @CCCD,   -- CCCD - varchar(15)
        @Nationality, -- QuocTich - nvarchar(50)
        @Phone, -- SDT - varchar(11)
        @Mail    -- Mail - varchar(50)
    )
END

-- EXEC dbo.CreateNewGuest @Guestname, @Sex, @DateOfBrith, @CCCD, @Nationality, @Phone, @Mail
EXEC dbo.CreateNewGuest @Guestname = N'',            -- nvarchar(50)
                        @Sex = N'',                  -- nvarchar(5)
                        @DateOfBrith = '2024-05-01', -- date
                        @CCCD = '',                  -- varchar(15)
                        @Nationality = N'',          -- nvarchar(50)
                        @Phone = '',                 -- varchar(11)
                        @Mail = ''                   -- varchar(50)
GO
