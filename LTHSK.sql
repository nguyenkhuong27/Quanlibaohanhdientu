create database LTHSK
go
use LTHSK

--1 Tạo bảng tblNhomHang
create table tblNhomHang
(
	PK_MaNhomHang char(10) primary key,
	sTenNhomHang nvarchar(50)
)
--2 Tạo bảng tblHangHoa
create table tblHangHoa
(
	PK_MaHang char(10) primary key,
	sTenHang nvarchar(50),
	sMauSac nvarchar(50),
	iSoLuong int,
	fGiaBan float,
	sHangSX nvarchar(100),
	sMaNhomHang char(10)
)
--3 Tạo bảng tblHangBan
create table tblHangBan
(
	PK_MaHoaDon char(10)   NOT NULL  ,
	sMaHang char(10)  NOT NULL,
	iSoLuong int,
	fGiaBan float,
	dTGMua date,
	dTGBaoHanh date 
	CONSTRAINT pk_hb PRIMARY KEY(PK_MaHoaDon, sMaHang) 
)

DROP TABLE dbo.tblHangBan
ALTER TABLE dbo.tblHangBan 
ADD CONSTRAINT checksl CHECK (dTGBaoHanh >= dTGMua)

--4 Tạo bảng tblThietBiCanBaoHanh
create table tblThietBiCanBaoHanh
(
	PK_MaBH CHAR(10) NOT NULL PRIMARY KEY,
	sMaThietBi char(10),
	sTenThietBi nvarchar(50),
	sTinhTrang nvarchar(500),
	sNguyenNhan nvarchar (500),
	dTGNhanBH DATE,
	dBHDen DATE
)
SELECT * FROM dbo.tblThietBiCanBaoHanh
ALTER TABLE dbo.tblThietBiCanBaoHanh
ADD CONSTRAINT checkdatebh CHECK (dBHDen > dTGNhanBH)

--5 Tạo bảng tblNhatKiSuaChua
create table tblNhatKiSuaChua
(
	PK_MaSC CHAR(10) PRIMARY KEY NOT NULL,
	sMaHang char(10),
	sNguyenNhan nvarchar(500),
	sGiaiQuyet nvarchar(500),
	sMaNVSua char(10),
	sTGSua date,
	sTGTra date
)

ALTER TABLE dbo.tblNhatKiSuaChua
ADD CONSTRAINT chtg CHECK (sTGTra >= sTGSua)
--6 Tạo bảng tblPhieuNhan
create table tblPhieuNhan
(
	PK_MaPhieu char(10) primary key,
	sMaKH char(10),
	sTenKH nvarchar(50),
	sDiaChi nvarchar(50),
	sMaNVNhanSua char(10),
	dNgayNhanSua date,
	dTGTra date
)
ALTER TABLE dbo.tblPhieuNhan
ADD CONSTRAINT chtgtra CHECK (dNgayNhanSua <= dTGTra)
--7 Tạo bảng tblNhanVien
create table tblNhanVien
(
	PK_MaNV char(10) primary key,
	sTenNV nvarchar(50),
	sGioiTinh NVARCHAR(10),
	sDiaChi nvarchar(50),
	dNgaySinh date,
	fHSL float,
	sTenDangNhap char(50),
	sMatKhau char(50),
)

ALTER TABLE dbo.tblNhanVien
ADD CONSTRAINT chns CHECK (YEAR(dNgaySinh) <= YEAR(GETDATE())-18)
ALTER TABLE dbo.tblNhanVien
ADD CONSTRAINT chns CHECK ( (YEAR(GETDATE())- Year(dNgaysinh))>=18)
Alter table tblNhanVien drop constraint chns

--8 Tạo bảng tblKhachHang
create table tblKhachHang
(
	PK_MaKH char(10) primary key,
	sTenKH nvarchar(50),
	sGioiTinh NVARCHAR(10),
	dNgaySinh DATE,
	sDiaChi nvarchar(50),
	sSDT char(10)
)


--9 Tạo bảng tblHoaDonBanHang
create table tblHoaDonBanHang
(
	PK_MaHoaDon char(10) primary key,
	sMaNVLap char(10),
	sMaKH char(10),
	dTGLap date,
	fTongTien float,
	sTTThuTien nvarchar(20)
)

ALTER TABLE dbo.tblHoaDonBanHang
ADD CONSTRAINT tthutien CHECK (sTTThuTien = N'Đã thu tiền' OR sTTThuTien = N'Chưa thu tiền')
ALTER TABLE dbo.tblHoaDonBanHang
ADD CONSTRAINT chTGL CHECK(dTGLap <= GETDATE())
-- TẠO KHÓA NGOẠI CHO CÁC BẢNG
alter table tblHangHoa
add constraint fk_NhomHang foreign key (sMaNhomHang) references tblNhomHang(PK_MaNhomHang)

alter table tblThietBiCanBaoHanh
add constraint fk_TBBH foreign key (sMaThietBi) references tblHangHoa (PK_MaHang)

alter table tblNhatKiSuaChua
add constraint fk_nksc foreign key (sMaHang) references tblHangHoa(PK_MaHang)
alter table tblNhatKiSuaChua
add constraint fk_nvsc foreign key (sMaNVSua) references tblNhanVien(PK_MaNV)

alter table tblHangBan
add constraint fk_hhb foreign key (PK_MaHoaDon) references tblHoaDonBanHang(PK_MaHoaDon),
	constraint fk_maHangban foreign key (sMaHang) references tblHangHoa(PK_MaHang)

alter table tblHoaDonBanHang
add constraint fk_nvbh foreign key (sMaNVLap) references tblNhanVien(PK_MaNV),
	constraint fk_khmh foreign key (sMaKH) references tblKhachHang(PK_MaKH)

alter table tblPhieuNhan
add constraint fk_nvnh foreign key (sMaNVNhanSua) references tblNhanVien(PK_MaNV),
	constraint fk_khsh foreign key (sMaKH) references tblKhachHang(PK_MaKH)
alter table tblNhanVien
add constraint nvgt check (sGioitinh = N'Nam' or sGioitinh = N'Nữ')
Alter table tblNhanVien drop constraint nvgt
alter table tblKhachHang
add constraint khgt check (sGioitinh = N'Nam' or sGioitinh = N'Nữ')

	--Dữ liệu bảng Nhóm Hàng

insert into tblNhomHang values ('NH01', N'Ổ cứng')
insert into tblNhomHang values ('NH02', N'RAM')
insert into tblNhomHang values ('NH03', N'Main')
insert into tblNhomHang values ('NH05', N'CPU')
insert into tblNhomHang values ('NH07', N'Monitor')

 --Dữ liệu bảng Hàng hóa

insert into tblHangHoa 
values('HH01', 'HDD WD Blue 1TB', N'Trắng', 15, 950000, N'Western Digital','NH01');
insert into tblHangHoa 
values('HH02', 'HDD Seagate Barracuda 1TB', N'Trắng xanh', 17, 980000, N'Seagate','NH01');
insert into tblHangHoa 
values('HH03', 'SSD KINGSTON A400 240GB M.2 Sata 3', N'Xanh đen', 21, 890000, N'KINGSTON','NH01');
insert into tblHangHoa 
values('HH04', 'Gigabyte SSD 120GB Sata III', N'Đen', 24, 590000, N'Gigabyte','NH01')
;
insert into tblHangHoa 
values('HH05', 'G.SKILL Ripjaws V 8GB', N'Đỏ đen', 18, 1090000, N'GSKILL','NH02');
insert into tblHangHoa 
values('HH06', 'PNY XLR8 RGB 8GB', N'Đen', 22, 1990000, N'PNY','NH02');
insert into tblHangHoa 
values('HH07', 'Adata XPG Lancer RGB', N'Đen', 11, 4990000, N'Adata','NH02');

insert into tblHangHoa 
values('HH08', 'Mainboard Asrock B660M Steel Legend DDR4', N'Đen trắng', 7, 4190000, N'Asrock ','NH03')
insert into tblHangHoa 
values('HH09', 'Mainboard MSI MAG B560M Mortar', N'Đen', 5, 3590000, N'MSI','NH03');
insert into tblHangHoa 
values('HH10', 'Mainboard GIGABYTE Z590 UD', N'Đen', 12, 4590000, N'GIGABYTE','NH03');

insert into tblHangHoa 
values('HH15', 'Intel Core i9-10900K', N'Lam', 13, 9990000, N'Intel','NH05');
insert into tblHangHoa 
values('HH13', 'AMD Ryzen 7 3700X', N'Xám', 16, 8790000, N'AMD','NH05');
insert into tblHangHoa 
values('HH14', 'AMD Athlon 3000G', N'Trắng', 17, 1490000, N'AMD','NH05');

insert into tblHangHoa 
values('HH11', 'Dell 18.5 inch E1920H', N'Đen', 11, 2690000, N'Dell','NH07');
insert into tblHangHoa 
values('HH12', 'HP V19 18.5 inch 9TN41AA', N'Trắng', 14, 2510000, N'HP','NH07');
insert into tblHangHoa 
values('HH19', 'Samsung 27 inch LC27F397FHEXXV', N'Trắng', 14, 4390000, N'Samsung','NH07');

insert into tblNhanVien
values ('NV01', N'Nguyễn Công Phượng', N'Nam', N'Nam Đàn, Nghệ An','12/02/1995', 4.3, 'congphuong10', 'cp10');
insert into tblNhanVien
values ('NV02', N'Nguyễn Tiến Linh', N'Nam', N'Thủ Dầu Một, Bình Dương', '11/05/1996', 4.1, 'tienlinh22', 'tl22');
insert into tblNhanVien
values ('NV03', N'Thái Thị Thảo', N'Nữ', N'Nghi Sơn, Hà Tĩnh','07/22/1998', 2.6, 'thaithao25', 'tt25');
insert into tblNhanVien
values ('NV05', N'Phạm Hải Yến', N'Nữ', N'Tam Đảo, Vĩnh Phúc','05/06/1998', 2.9, 'haiyen7', 'hy7');
insert into tblNhanVien
values ('NV06', N'Phạm Yến', N'Nữ', N'Tam Đảo, Vĩnh Phúc','05/06/1999', 2.9, 'haiyen8', 'hy8');

insert into tblNhatKiSuaChua
values ('NKSC01','HH11',	N'Lỗi màu màn hình', N'Thay giắc màu', 'NV02', '02/11/2020', '02/20/2020' );
insert into tblNhatKiSuaChua
values ('NKSC03','HH06',	N'Lỗi RAM do sự cố', N'Thay RAM mới', 'NV03', '11/11/2020', '11/15/2020' );
insert into tblNhatKiSuaChua
values ('NKSC02','HH02',	N'Ổ cứng ngấm nước', N'Thay ổ cứng', 'NV01', '07/03/2021', '07/05/2021' );

INSERT INTO tblKhachHang VALUES 
('KH01', N'Nguyễn Văn Toàn',N'Nam', '05/15/1995', N'Thanh Hà, Hải Dương', '0987789987');
INSERT INTO tblKhachHang VALUES 
('KH03', N'Hoàng Thị Loan',N'Nữ','02/22/1998', N'Thanh Sơn, Phú Thọ', '0329756734' );
INSERT INTO tblKhachHang VALUES 
('KH02', N'Trần Tuyết Dung',N'Nữ',  '11/20/1996', N'Đông Anh, Hà Nội', '0965743821');
INSERT INTO tblKhachHang VALUES 
('KH06', N'Phạm Văn Mạnh',N'Nam','01/15/2000', N'Vĩnh Tường, Vĩnh Phúc', '0399754251' );


INSERT INTO tblHoaDonBanHang VALUES
('HD01', 'NV01', 'KH02', '02/10/2021',0, N'Đã thu tiền'),
('HD02', 'NV01', 'KH03', '11/20/2020', 0, N'Chưa thu tiền'),
('HD03', 'NV03', 'KH06', '03/21/2021', 0, N'Đã thu tiền');
INSERT INTO tblHoaDonBanHang VALUES
('HD04', 'NV01', 'KH01', '10/10/2021',100000, N'Đã thu tiền')

INSERT INTO dbo.tblThietBiCanBaoHanh
(
	PK_MaBH,
    sMaThietBi,
    sTinhTrang,
    sNguyenNhan,
    dTGNhanBH,
    dBHDen
)
VALUES
(   'BH01',
	'HH01',        -- sMaThietBi - char(10)
           -- sTenThietBi - nvarchar(50)
    N'Hư hỏng ô cứng',       -- sTinhTrang - nvarchar(500)
    N'Tác động vật lí bên ngoài',       -- sNguyenNhan - nvarchar(500)
    '02/10/2019', -- dTGNhanBH - date
    '02/10/2020'  -- dBHDen - date
    )
INSERT INTO dbo.tblPhieuNhan
(
    PK_MaPhieu,
    sMaKH,
    sTenKH,
    sDiaChi,
    sMaNVNhanSua,
    dNgayNhanSua,
    dTGTra
)
VALUES
(   'PN01',        -- PK_MaPhieu - char(10)
    'KH02',        -- sMaKH - char(10)
    N'Trần Tuyết Dung',       -- sTenKH - nvarchar(50)
    N'Đông Anh, Hà Nội',       -- sDiaChi - nvarchar(50)
    'NV03',        -- sMaNVNhanSua - char(10)
    '11/20/2019', -- dNgayNhanSua - date
    '11/25/2019'  -- dTGTra - date
    )
	SELECT * FROM dbo.tblThietBiCanBaoHanh
	go
---XỬ LÝ VỚI BẢNG HÀNG HÓA
CREATE PROC hienHH
AS BEGIN
       SELECT * FROM dbo.tblHangHoa
   END
   GO
   
create proc addHH
@mahang char(10), @tenhang nvarchar(50), @mausac nvarchar(50), @soluong int, @giaban float,
@hsx nvarchar(50), @manhomhang char(10)
as begin
		insert into tblHangHoa ([PK_MaHang],[sTenHang],[sMauSac],[iSoLuong],[fGiaBan],[sHangSX],[sMaNhomHang])
		values (@mahang, @tenhang, @mausac, @soluong, @giaban, @hsx, @manhomhang)  
	end
	exec addHH 'HH01', 'HDD WD Blue 1TB', N'Trắng', 15, 950000, N'Western Digital','NH01'

	GO


CREATE PROC delHH 
@mahang CHAR(10)
AS BEGIN
       DELETE FROM dbo.tblHangHoa WHERE PK_MaHang = @mahang
   END
    DELETE FROM dbo.tblHangHoa WHERE PK_MaHang = 'HH01'
GO 

CREATE PROC updateHH
@mahang char(10), @tenhang nvarchar(50), @mausac nvarchar(50), @soluong int, @giaban float,
@hsx nvarchar(50), @manhomhang char(10)
AS BEGIN
       UPDATE dbo.tblHangHoa SET  sTenHang = @tenhang, sMauSac = @mausac, iSoLuong = @soluong, fGiaBan = @giaban, sHangSX= @hsx, sMaNhomHang = @manhomhang
				WHERE PK_MaHang = @mahang
   END
   GO
   
ALTER PROC searchHH 
 @tenhang NVARCHAR(50) /*, @mahang char(10), @mausac nvarchar(50), @soluong int, @giaban float, 
@hsx nvarchar(50), @manhomhang char(10)*/
AS BEGIN
       SELECT * FROM dbo.tblHangHoa 
	   WHERE  --PK_MaHang like '%' +@mahang + '%' AND
				 sTenHang like N'%' +@tenhang + '%' /*OR
                sMauSac like N'%' +@mausac + '%' OR
                iSoLuong = @soluong  OR
                fGiaBan = @giaban OR
                sHangSX like N'%' +@hsx + '%'AND
                sMaNhomHang like N'%' +@manhomhang + '%' */ 
                
   END
   GO 
	--XỬ LÝ DỮ LIỆU BẢNG HÀNG BÁN
ALTER PROC hienHB
AS BEGIN
       SELECT * FROM dbo.tblHangBan
   END
   GO
   --Thêm hàng bán
ALTER PROC addHB
@mahd CHAR(10), @mahang CHAR(10), @sl int, @giaban float, @tgmua date, @tgbh date
AS BEGIN
       INSERT INTO tblHangBan(PK_MaHoaDon, sMaHang, iSoLuong, fGiaBan, dTGMua, dTGBaoHanh )
							VALUES (@mahd, @mahang, @sl, @giaban, @tgmua, @tgbh)	
   END
   GO 
   EXEC addHB 'HD01', 'HH02', 15, 900000,  '01/01/2020','01/01/2023'
   EXEC addHB 'HD01', 'HH04', 4, 400000, '01/01/2021', '01/01/2024'
   EXEC addHB 'HD02', 'HH02', 2, 900000, '01/05/2019', '01/11/2020'

 SELECT * FROM dbo.tblHangHoa
GO
	--Sửa hàng bán
CREATE  PROC updateHB
@mahd CHAR(10), @mahang CHAR(10), @sl int, @giaban float, @tgmua date, @tgbh date
AS BEGIN
       UPDATE dbo.tblHangBan SET iSoLuong = @sl, fGiaBan = @giaban, dTGMua = @tgmua, dTGBaoHanh = @tgbh
	   WHERE PK_MaHoaDon = @mahd AND sMaHang = @mahang
   END
   
   GO 
   EXEC dbo.updateHB @mahd = 'HD01',  -- char(10)
                     @mahang = 'HH02', -- char(10)
					 @sl = 50,
					 @giaban = 5000000,
					 @tgmua = '10/20/2019',
					 @tgbh = '10/20/2023'
   GO 
   --Xóa mặt hàng bán ra
CREATE PROC delHB
@mahd CHAR(10), @mahang CHAR(10)
AS BEGIN
       DELETE FROM dbo.tblHangBan WHERE PK_MaHoaDon = @mahd AND sMaHang = @mahang
   END
   SELECT * FROM dbo.tblHangBan
   EXEC dbo.delHB @mahd = 'HD01',  -- char(10)
                  @mahang = 'HH04' -- char(10)
   GO 

	--Tìm kiếm hàng bán ra
ALTER PROC searchHB
@mahd CHAR(10), @mahang CHAR(10)
AS BEGIN
       SELECT * FROM dbo.tblHangBan WHERE PK_MaHoaDon = @mahd OR sMaHang = @mahang
   END
   EXEC dbo.searchHB @mahd = 'HD01',  -- char(10)
                     @mahang = 'HH02' -- char(10)
   
   GO 
   

		--Xử lí sl hàng hóa giảm đi khi có đơn hàng
CREATE TRIGGER trg_dathang
ON dbo.tblHangBan AFTER INSERT 
AS BEGIN
       UPDATE dbo.tblHangHoa
	   SET dbo.tblHangHoa.iSoLuong = dbo.tblHangHoa.iSoLuong - 
					(SELECT Inserted.iSoLuong FROM Inserted
					WHERE Inserted.sMaHang = dbo.tblHangHoa.PK_MaHang )
		FROM dbo.tblHangHoa JOIN Inserted ON Inserted.sMaHang = tblHangHoa.PK_MaHang
   END
   GO
		-- Xử lí hàng hóa sau khi cập nhật hàng bán
CREATE TRIGGER trg_CapNhatDatHang on dbo.tblHangBan after update AS
	BEGIN
	   UPDATE dbo.tblHangHoa SET dbo.tblHangHoa.iSoLuong = dbo.tblHangHoa.iSoLuong -
		   (SELECT Inserted.iSoLuong FROM Inserted
					WHERE Inserted.sMaHang = dbo.tblHangHoa.PK_MaHang) +
		   (SELECT Deleted.iSoLuong FROM Deleted
					WHERE Deleted.sMaHang = dbo.tblHangHoa.PK_MaHang )
	   FROM dbo.tblHangHoa 
	   JOIN Deleted ON Deleted.sMaHang = tblHangHoa.PK_MaHang
	END
    GO 
	UPDATE dbo.tblHangBan SET iSoLuong = 12 WHERE sMaHang = 'HH02'
	GO 
		--Xử lí hàng hóa tăng lên khi hóa đơn bị xóa
create TRIGGER trg_HuyDatHang ON dbo.tblHangBan FOR DELETE 
AS 
	BEGIN
		UPDATE dbo.tblHangHoa
		SET dbo.tblHangHoa.iSoLuong = dbo.tblHangHoa.iSoLuong + (SELECT Deleted.iSoLuong FROM Deleted WHERE Deleted.sMaHang = dbo.tblHangHoa.PK_MaHang)
		FROM dbo.tblHangHoa 
		JOIN deleted ON Deleted.sMaHang = tblHangHoa.PK_MaHang
	END
	GO
    
		-- Xử lí hàng bán ra phải ít hơn hàng trong kho
CREATE TRIGGER checkhb
ON dbo.tblHangBan FOR INSERT, UPDATE
AS 
      iF (SELECT dbo.tblHangHoa.iSoLuong FROM dbo.tblHangHoa  JOIN Inserted ON tblHangHoa.PK_MaHang = Inserted.sMaHang  )
	  <
	  (SELECT dbo.tblHangBan.iSoLuong FROM dbo.tblHangBan  JOIN Inserted ON tblHangBan.sMaHang = Inserted.sMaHang  )
	   AND
       NOT EXISTS (SELECT dbo.tblHangHoa.PK_MaHang FROM dbo.tblHangHoa JOIN Inserted 
				on dbo.tblHangHoa.PK_MaHang = Inserted.sMaHang AND dbo.tblHangHoa.iSoLuong >0)
	  BEGIN
	      PRINT N'Số lượng hàng bán ra phải ít hơn số hàng hiện có'
		  ROLLBACK TRAN
	  END
   GO
   INSERT INTO dbo.tblHangBan
   (
       PK_MaHoaDon,
       sMaHang,
       iSoLuong,
       fGiaBan,
       dTGMua,
       dTGBaoHanh
   )
   VALUES
   (   'HD05',        -- PK_MaHoaDon - char(10)
       'HH04',        -- sMaHang - char(10)
       30,         -- iSoLuong - int
       30000000,       -- fGiaBan - float
       '10/20/2019', -- dTGMua - date
       '10/20/2021'  -- dTGBaoHanh - date
       )
GO 
			----XỬ LÝ DỮ LIỆU BẢNG THIẾT BỊ BẢO HÀNH
ALTER PROC hienTBBH
AS BEGIN
       SELECT * FROM dbo.tblThietBiCanBaoHanh
   END
   ---------hiện nhân viên
   GO
   Create PROC hienNV
AS BEGIN
       SELECT * FROM dbo.tblNhanVien
   END
   GO

   --Thêm TBBH
ALTER PROC addTBBH
@mabh CHAR(10), @matb CHAR(10), @tinhtrang NVARCHAR(500), @nguyennhan NVARCHAR(500),
@tgbh DATE, @tghetbh DATE
AS BEGIN
       INSERT INTO dbo.tblThietBiCanBaoHanh
       (
			PK_MaBH,
           sMaThietBi,
           
           sTinhTrang,
           sNguyenNhan,
           dTGNhanBH,
           dBHDen
       )
       VALUES
       (   
			@mabh,
			@matb,        -- PK_MaThietBi - char(10)
                 -- sTenThietBi - nvarchar(50)
           @tinhtrang,       -- sTinhTrang - nvarchar(500)
           @nguyennhan,       -- sNguyenNhan - nvarchar(500)
           @tgbh, -- dTGNhanBH - date
           @tghetbh  -- dBHDen - date
           )
   END
   EXEC dbo.addTBBH @mabh = 'BH02',
					@matb = 'HH11',             -- char(10)
                               -- nvarchar(50)
                    @tinhtrang = N'Hư hỏng',       -- nvarchar(500)
                    @nguyennhan = N'Nhiễm nước',      -- nvarchar(500)
                    @tgbh = '2022-03-06',   -- date
                    @tghetbh = '2022-03-12' -- date
   GO 
  --Sửa thiết bị bảo hành
ALTER PROC updateTBBH
@mabh CHAR(10), @matb CHAR(10), @tinhtrang NVARCHAR(500), @nguyennhan NVARCHAR(500),
@tgbh DATE, @tghetbh DATE
AS BEGIN
       UPDATE dbo.tblThietBiCanBaoHanh SET   sTinhTrang = @tinhtrang,
										sNguyenNhan = @nguyennhan, dTGNhanBH = @tgbh, dBHDen = @tghetbh
		WHERE PK_MaBH = @mabh and sMaThietBi = @matb
   END
   GO
   --Xóa thiết bị bảo hành
CREATE PROC delTBBH
@mabh CHAR(10), @matb CHAR(10)
AS BEGIN
       DELETE FROM dbo.tblThietBiCanBaoHanh where PK_MaBH = @mabh AND  sMaThietBi = @matb 
   END
   GO
ALTER PROC searchTBBH
@mabh CHAR(10), @matb CHAR(10)
AS BEGIN
       SELECT * FROM dbo.tblThietBiCanBaoHanh WHERE PK_MaBH = @mabh OR  sMaThietBi = @matb
   END
   --Nhật kí sửa chữa
   CREATE PROC hienNKSC
AS BEGIN
       SELECT * FROM dbo.tblNhatKiSuaChua
   END
   GO
   --Thêm nhật kí sửa chữa
   CREATE PROC addNKSC
@mahang CHAR(10), @nguyennhan NVARCHAR(500), @giaiquyet NVARCHAR(500), @ManvSua CHAR(10),
@TGsua DATE, @TGtra DATE,@masc char(10)
AS BEGIN
       INSERT INTO dbo.tblNhatKiSuaChua(PK_MaSC,sMaHang,sNguyenNhan,sGiaiQuyet, sMaNVSua,sTGSua,sTGTra)
       VALUES
       (@masc,@mahang,@nguyennhan,@giaiquyet,@ManvSua,@TGsua,@TGtra)
   END
   --Xóa nhật kí sửa chữa
	CREATE PROC xoaNKSC
	@mahang CHAR(10), @masc CHAR(10)
	AS BEGIN
		   DELETE FROM dbo.tblNhatKiSuaChua where PK_MaSC = @masc AND  sMaHang = @mahang 
	   END
	   
	--Tìm kiếm nhật kí sửa chữa
	CREATE PROC searchNKSC
	@mahang CHAR(10),@masc CHAR(10)
	AS BEGIN
		SELECT *FROM dbo.tblNhatKiSuaChua where PK_MaSC = @masc and sMaHang = @mahang
		END
	--Phiếu Nhận
	   CREATE PROC hienPN
AS BEGIN
       SELECT * FROM dbo.tblPhieuNhan
   END
   --Thêm phiếu nhận
     CREATE PROC addPN
	@maphieu CHAR(10), @makh NVARCHAR(500), @tenkh NVARCHAR(500), @diachi CHAR(10),
	@ngaynhansua DATE, @maNVnhansua DATE,@TGtra char(10)
	AS BEGIN
       INSERT INTO dbo.tblPhieuNhan(PK_MaPhieu,sMaKH,sTenKH,sDiaChi,sMaNVNhanSua,dNgayNhanSua,dTGTra)
       VALUES
       (@maphieu,@makh,@tenkh,@diachi,@maNVnhansua,@ngaynhansua,@TGtra)
   END
   --Xóa phiếu nhận
   CREATE PROC xoaPN
	@maphieu CHAR(10), @makh CHAR(10)
	AS BEGIN
		   DELETE FROM dbo.tblPhieuNhan where PK_MaPhieu = @maphieu AND  sMaKH = @makh 
	   END
	--Tìm kiếm phiếu nhận
	CREATE PROC searchPN
	@maphieu CHAR(10), @makh CHAR(10)
	AS BEGIN
		   SELECT* FROM dbo.tblPhieuNhan where PK_MaPhieu = @maphieu AND  sMaKH = @makh 
	   END

   SELECT * FROM dbo.tblHangBan
   SELECT * FROM dbo.tblKhachHang
   SELECT * FROM dbo.tblHoaDonBanHang
   SELECT * FROM dbo.tblNhanVien
   SELECT* FROM dbo.tblThietBiCanBaoHanh
   SELECT * FROM dbo.tblNhatKiSuaChua
   SELECT * FROM dbo.tblHangHoa
   SELECT * FROM dbo.tblPhieuNhan
	
GRANT SELECT, INSERT, UPDATE, DELETE    ON tblHangBan TO  thekhai

---------Hiện hóa đơn bán hàng
 create proc HienHDBH 
 as BEGIN
       SELECT * FROM dbo.tblHoaDonBanHang
   END
   GO
   
   ------Thêm hóa đơn bán hàng
   create proc addHDBH
@mahoadon char(10), @manvlap char(10), @makh char(10), @tglap date, @tongtien float, @ttthutien nvarchar(20)
as begin
		insert into tblHoaDonBanHang([PK_MaHoaDon],[sMaNVLap],[sMaKH],[dTGLap],[fTongTien],[sTTThuTien])
		values (@mahoadon, @manvlap, @makh, @tglap, @tongtien, @ttthutien)  
	end
	CREATE PROC delHDBH
@mahoadon CHAR(10)
AS BEGIN
       DELETE FROM dbo.tblHoaDonBanHang WHERE PK_MaHoaDon = @mahoadon
   END
   ---thêm nhân viên
   create proc addNV
@manhanvien char(10), @tennhanvien nvarchar(50), @gioitinh nvarchar(10), @diachi nvarchar(50), @ngaysinh date, @hsl float, @tendn char(50), @matkhau char(50)
as begin
		insert into tblNhanVien([PK_MaNV],[sTenNV],[sGioiTinh],[sDiaChi],[dNgaySinh],[fHSL],[sTenDangNhap],[sMatKhau])
		values (@manhanvien, @tennhanvien, @gioitinh, @diachi, @ngaysinh, @hsl,@tendn,@matkhau)  
	end
	go
	---hiện nv
	Create PROC hienNV
AS BEGIN
       SELECT * FROM dbo.tblNhanVien
   END
   GO
   -------update nhân viên
  create PROC updateNV
@manv char(10), @tennhanvien nvarchar(50), @gioitinh nvarchar(10), @diachi nvarchar(50), @ngaysinh date, @hsl float, @tendn char(50), @matkhau char(50)
AS BEGIN
       UPDATE dbo.tblNhanVien   set [PK_MaNV] = @manv,[sTenNV] = @tennhanvien, [sGioiTinh] = @gioitinh, [dNgaySinh]= @ngaysinh, [fHSL] = @hsl,[sDiaChi] = @diachi,[sTenDangNhap] = @tendn,[sMatKhau] = @matkhau
		WHERE PK_MaNV = @manv
   END
   GO

   drop proc searchNV
   use LTHSK
   ----xóa nhân viên
   CREATE PROC deleteNV
	@manv char(10)
	AS BEGIN
		   DELETE FROM dbo.tblNhanVien where PK_MaNV= @manv 
	   END
	   go
	   ------tìm kiếm nhân viên
	   CREATE PROC searchNV
	@manv char(10), @tennhanvien nvarchar(50)
	AS BEGIN
		SELECT *FROM dbo.tblNhanVien where PK_MaNV = @manv or  sTenNV = @tennhanvien 
		END
		go