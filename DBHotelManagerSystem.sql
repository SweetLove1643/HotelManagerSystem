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
	Mail varchar(50) NOT NULL,
	QuocTich NVARCHAR(50)
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
	IDKhach INT REFERENCES dbo.Khach(IDKhach) ON DELETE SET NULL,
	MaPhong VARCHAR(20) REFERENCES dbo.Phong(MaPhong) ON DELETE SET NULL,
	NgayNhan DATE NOT NULL,
	NgayTra DATE NOT NULL,
	TienCoc MONEY
)
GO

create table BienLai
(
	IDBienLai INT IDENTITY PRIMARY KEY,
	IDKhach INT references Khach(IDKhach) ON DELETE SET NULL,
	TenKhach NVARCHAR(40) NULL,
	MaPhong VARCHAR(20) references Phong(MaPhong) ON DELETE SET NULL,
	IDNV INT references NhanVien(IDNV) ON DELETE SET NULL,
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
	IDKhach INT REFERENCES dbo.Khach(IDKhach) ON DELETE SET NULL,
	IDBienLai INT REFERENCES dbo.BienLai(IDBienLai) ON DELETE SET NULL
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
AFTER INSERT
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

CREATE TRIGGER Insert_TienPhong
ON dbo.BienLai
AFTER INSERT
AS
BEGIN
    UPDATE dbo.BienLai
	SET TienPhong = (SELECT Gia FROM dbo.Phong WHERE dbo.BienLai.MaPhong = dbo.Phong.MaPhong)
END

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


CREATE PROCEDURE CreateNewAccount -- tạo tài khoản mới
	@SDT VARCHAR(30), @Mail VARCHAR(30), @Password NVARCHAR(150), @Accounttype NVARCHAR(20)
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

CREATE PROCEDURE CreateNewGuest --tạo khách
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
GO

CREATE PROC CreateNewPersonnel -- thêm nhân viên
@Name NVARCHAR(50),
@Sex NVARCHAR(5),
@DateofBrith Date,
@Position NVARCHAR(50),
@Phone VARCHAR(11),
@CCCD varchar(15),
@Mail varchar(50),
@Nationality NVARCHAR(50)
AS	
BEGIN
	INSERT INTO dbo.NhanVien
	(
	    TenNV,
	    GioiTinh,
	    NgaySinh,
	    ChucVu,
	    SDT,
	    CCCD,
	    Mail,
	    QuocTich
	)
    VALUES
    (   @Name,
        @Sex, -- GioiTinh - nvarchar(5)
        @DateofBrith, -- NgaySinh - date
        @Position,  -- ChucVu - nvarchar(50)
        @Phone, -- SDT - varchar(11)
        @CCCD,   -- CCCD - varchar(15)
        @Mail,    -- Mail - varchar(50)
		@Nationality
        )
END
GO

CREATE PROC SeachEmail @Email VARCHAR(30) -- kiểm tra account
AS
BEGIN
    SELECT * FROM dbo.TaiKhoan WHERE Mail = @Email
END
GO

CREATE PROC ChangePassword @Email VARCHAR(30), @Newpassword NVARCHAR(150) -- đổi pass
AS
BEGIN
    UPDATE dbo.TaiKhoan 
	SET MatKhau = @Newpassword
	WHERE Mail = @Email
END
GO

CREATE FUNCTION CheckAccount (@username VARCHAR(30), @password NVARCHAR(150)) -- check quyền
RETURNS INT
AS
BEGIN
	DECLARE @accounttype INT
	SELECT @accounttype =
		CASE
			WHEN LoaiTaiKhoan = N'Quản lí' THEN 1
			WHEN LoaiTaiKhoan = N'Nhân viên' THEN 0
			WHEN LoaiTaiKhoan = N'Khách hàng' THEN -1
		END 
	FROM dbo.TaiKhoan
	WHERE (SDT = @username OR Mail = @username) AND	 MatKhau = @password
	RETURN @accounttype
END
GO

CREATE PROC CheckAccountAndPassword @username VARCHAR(30), @password VARCHAR(150) -- check account
AS
BEGIN
    SELECT * FROM dbo.TaiKhoan WHERE (SDT = @username OR Mail = @username) AND MatKhau = @password
END
GO


CREATE PROC CreateNewRoom @Roomcode VARCHAR(20), @Roomtype NVARCHAR(30), @Mota NVARCHAR(500), @Status INT, @Price MONEY, @SucChua INT
AS
BEGIN
    INSERT INTO dbo.Phong
    (
        MaPhong,
        LoaiPhong,
        Mota,
        TrangThai,
        Gia,
        SucChua
    )
    VALUES
    (   @Roomcode,   -- MaPhong - varchar(20)
        @Roomtype, -- LoaiPhong - nvarchar(30)
        @Mota, -- Mota - nvarchar(500)
        @Status,    -- TrangThai - int
        @Price, -- Gia - money
        @SucChua     -- SucChua - int
        )
END
GO


CREATE PROC Update_Info_NhanVien @IDNV INT, @Name NVARCHAR(50), @Sex NVARCHAR(5), @Dateofbirth DATE, @Phone VARCHAR(11), @CCCD VARCHAR(15), @Mail VARCHAR(50)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM dbo.NhanVien WHERE CCCD = @CCCD AND IDNV <> @IDNV)
    BEGIN
        -- CCCD không trùng lặp, tiến hành cập nhật thông tin nhân viên
        UPDATE dbo.NhanVien 
        SET TenNV = @Name, 
            GioiTinh = @Sex, 
            NgaySinh = @Dateofbirth, 
            SDT = @Phone, 
            CCCD = @CCCD, 
            Mail = @Mail
        WHERE IDNV = @IDNV;
    END
    ELSE
    BEGIN
        -- CCCD trùng lặp, thông báo lỗi
        UPDATE dbo.NhanVien 
        SET TenNV = @Name, 
            GioiTinh = @Sex, 
            NgaySinh = @Dateofbirth, 
            SDT = @Phone, 
            Mail = @Mail
        WHERE IDNV = @IDNV;
    END
END
GO

CREATE PROC CreateNewReceipt @Name NVARCHAR(40), @Roomcode VARCHAR(20), @IDNV INT,@Roomprice MONEY, @Discount MONEY, @VAT MONEY
AS
BEGIN
	INSERT INTO dbo.BienLai
	(
		TenKhach,
	    MaPhong,
	    IDNV,
	    TienCoc,
	    NgayVao,
	    NgayRa,
	    TienPhong,
	    TrangThai,
	    discount,
	    VAT,
	    TongTien,
	    TenPhuongThuc
	)
	VALUES
	( 
		@Name,		-- Tenkhach
	    @Roomcode,      -- MaPhong - varchar(20)
	    @IDNV,      -- IDNV - int
	    DEFAULT ,   -- TienCoc - money
	    GETDATE(), -- NgayVao - datetime
	    NULL,      -- NgayRa - datetime
	    @Roomprice,      -- TienPhong - money
	    0,         -- TrangThai - int
	    @Discount,   -- discount - money
	    @VAT,   -- VAT - money
	    DEFAULT ,   -- TongTien - money
	    NULL       -- TenPhuongThuc - nvarchar(20)
	    )    
END
GO

<<<<<<< HEAD
=======
CREATE PROC Select_Booking @Date1 DATE, @Date2 DATE
AS
BEGIN
		SELECT P.MaPhong AS 'Mã phòng', LoaiPhong AS 'Loại phòng',Mota AS 'Mô tả', Gia AS 'Giá', SucChua AS 'Sức chứa'
	FROM dbo.Phong AS P
	LEFT JOIN dbo.DatTruoc AS DT ON P.MaPhong = DT.MaPhong
	WHERE (DT.MaPhong IS NULL OR NOT (DT.NgayNhan BETWEEN @Date1 AND @Date2 OR DT.NgayTra BETWEEN @Date1 AND @Date2)
)
END
GO

CREATE PROC CreateBooking @IDGuest INT, @Roomcode VARCHAR(20), @Checkin DATE, @Checkout DATE, @Coc MONEY
AS
BEGIN
	INSERT INTO dbo.DatTruoc
	(
		IDKhach,
		MaPhong,
		NgayNhan,
		NgayTra,
		TienCoc
	)
	VALUES
	(   @IDGuest,      -- IDKhach - int
		@Roomcode,      -- MaPhong - varchar(20)
		@Checkin, -- NgayNhan - date
		@Checkout, -- NgayTra - date
		@Coc       -- TienCoc - money
		)
	INSERT INTO dbo.BienLai
	(
	    IDKhach,
	    MaPhong,
	    IDNV,
	    TienCoc,
	    NgayVao,
	    NgayRa,
	    TienPhong,
	    TrangThai,
	    discount,
	    VAT,
	    TongTien,
	    TenPhuongThuc,
	    TenKhach
	)
	VALUES
	(   @IDGuest,      -- IDKhach - int
	    @Roomcode,      -- MaPhong - varchar(20)
	    NULL,      -- IDNV - int
	    @Coc,   -- TienCoc - money
	    @Checkin, -- NgayVao - datetime
	    NULL,      -- NgayRa - datetime
	    NULL,      -- TienPhong - money
	    0,         -- TrangThai - int
	    DEFAULT,   -- discount - money
	    DEFAULT,   -- VAT - money
	    DEFAULT,   -- TongTien - money
	    NULL,      -- TenPhuongThuc - nvarchar(20)
	    NULL       -- TenKhach - nvarchar(40)
	    )
END
 
>>>>>>> 35c6b3f94881d5c42f14093171bed8a29b18f685













