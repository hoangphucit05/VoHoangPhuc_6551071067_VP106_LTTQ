CREATE database DuLieu;
go

use DuLieu;
go

begin

create table SanPham (
MaSanPham NVARCHAR(10) PRIMARY KEY,
TenSanPham NTEXT NOT NULL UNIQUE,
GiaBan NVARCHAR(12) NOT NULL UNIQUE
	
);

begin

insert into SanPham (MaSanPham, TenSanPham, GiaBan) 

values 
(N' SP001', N' Nước Khoáng', '10000'),
(N' SP002', N' Sữa tươi Vinamilk', '25000'),
(N' SP003', N' Gạo tẻ Thơm', '45000'),
(N' SP004', N' Bánh Quy AFC', '30000'),
(N' SP005', N' Dầu ăn Tường An', '65000');
end
go









