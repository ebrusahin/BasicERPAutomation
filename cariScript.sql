USE [master]
GO
/****** Object:  Database [CariHesapDB]    Script Date: 19.11.2019 19:37:06 ******/
CREATE DATABASE [CariHesapDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CariHesapDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CariHesapDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CariHesapDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CariHesapDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CariHesapDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CariHesapDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CariHesapDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CariHesapDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CariHesapDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CariHesapDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CariHesapDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CariHesapDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CariHesapDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CariHesapDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CariHesapDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CariHesapDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CariHesapDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CariHesapDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CariHesapDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CariHesapDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CariHesapDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CariHesapDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CariHesapDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CariHesapDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CariHesapDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CariHesapDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CariHesapDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CariHesapDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CariHesapDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CariHesapDB] SET  MULTI_USER 
GO
ALTER DATABASE [CariHesapDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CariHesapDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CariHesapDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CariHesapDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CariHesapDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CariHesapDB] SET QUERY_STORE = OFF
GO
USE [CariHesapDB]
GO
/****** Object:  Table [dbo].[Kategoriler]    Script Date: 19.11.2019 19:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategoriler](
	[KategoriID] [int] IDENTITY(1,1) NOT NULL,
	[KategoriAd] [nvarchar](100) NULL,
	[KategoriDesc] [nvarchar](350) NULL,
 CONSTRAINT [PK_Kategoriler] PRIMARY KEY CLUSTERED 
(
	[KategoriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 19.11.2019 19:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanicilar](
	[KullaniciID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAd] [nvarchar](50) NOT NULL,
	[KullaniciSifre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Kullanicilar] PRIMARY KEY CLUSTERED 
(
	[KullaniciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteriler]    Script Date: 19.11.2019 19:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteriler](
	[MusteriID] [int] IDENTITY(1,1) NOT NULL,
	[MusteriAd] [nvarchar](50) NOT NULL,
	[MusteriSoyad] [nvarchar](50) NOT NULL,
	[Telefon] [nvarchar](50) NULL,
	[Adres] [nvarchar](350) NULL,
 CONSTRAINT [PK_Musteriler] PRIMARY KEY CLUSTERED 
(
	[MusteriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Satislar]    Script Date: 19.11.2019 19:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Satislar](
	[SatisID] [int] IDENTITY(1,1) NOT NULL,
	[UrunID] [int] NOT NULL,
	[UrunAdet] [int] NOT NULL,
	[MusteriID] [int] NULL,
	[UrunAciklama] [nvarchar](50) NULL,
	[SatisDate] [date] NULL,
 CONSTRAINT [PK_Satislar] PRIMARY KEY CLUSTERED 
(
	[SatisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urunler]    Script Date: 19.11.2019 19:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urunler](
	[UrunID] [int] IDENTITY(1,1) NOT NULL,
	[KategoriID] [int] NOT NULL,
	[UrunAd] [nvarchar](100) NULL,
	[GelisUcret] [int] NOT NULL,
	[SatisUcret] [int] NOT NULL,
	[Stok] [int] NULL,
	[UrunDesc] [nvarchar](350) NULL,
 CONSTRAINT [PK_Urunler] PRIMARY KEY CLUSTERED 
(
	[UrunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Kategoriler] ON 

INSERT [dbo].[Kategoriler] ([KategoriID], [KategoriAd], [KategoriDesc]) VALUES (1, N'Gıda', N'Yenilebilir, içilebilir')
INSERT [dbo].[Kategoriler] ([KategoriID], [KategoriAd], [KategoriDesc]) VALUES (2, N'Kimyevi Maddeler', N'Hammadde ve türevleri')
INSERT [dbo].[Kategoriler] ([KategoriID], [KategoriAd], [KategoriDesc]) VALUES (3, N'Ambalaj', N'Paketleme malzemeleri')
INSERT [dbo].[Kategoriler] ([KategoriID], [KategoriAd], [KategoriDesc]) VALUES (4, N'Temizlik', N'Yüz ve özellikle göz ile temasından kaçınınız. Temas durumunda yıkayınız.')
INSERT [dbo].[Kategoriler] ([KategoriID], [KategoriAd], [KategoriDesc]) VALUES (5, N'Dekorasyon', N'Ev düzenleyicileri, aksesuarlar')
INSERT [dbo].[Kategoriler] ([KategoriID], [KategoriAd], [KategoriDesc]) VALUES (6, N'Elektronik', N'Elektronik eşyaların hepsi bu kategorinin içindedir.')
SET IDENTITY_INSERT [dbo].[Kategoriler] OFF
SET IDENTITY_INSERT [dbo].[Kullanicilar] ON 

INSERT [dbo].[Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSifre]) VALUES (1, N'nes', N'145')
INSERT [dbo].[Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSifre]) VALUES (2, N'user', N'112233')
SET IDENTITY_INSERT [dbo].[Kullanicilar] OFF
SET IDENTITY_INSERT [dbo].[Musteriler] ON 

INSERT [dbo].[Musteriler] ([MusteriID], [MusteriAd], [MusteriSoyad], [Telefon], [Adres]) VALUES (1, N'Cengizhan', N'Yılmaz', N'1234565', N'Şair sk, Edirne, Türkiye')
INSERT [dbo].[Musteriler] ([MusteriID], [MusteriAd], [MusteriSoyad], [Telefon], [Adres]) VALUES (2, N'Su', N'Yıldız', N'7898641', N'İstanbul')
INSERT [dbo].[Musteriler] ([MusteriID], [MusteriAd], [MusteriSoyad], [Telefon], [Adres]) VALUES (3, N'Pedro', N'Castro', N'3512557', N'Coimbra, Portekiz')
INSERT [dbo].[Musteriler] ([MusteriID], [MusteriAd], [MusteriSoyad], [Telefon], [Adres]) VALUES (4, N'Sarah', N'Gozzi', N'5511984', N'Rio, Brezilya')
INSERT [dbo].[Musteriler] ([MusteriID], [MusteriAd], [MusteriSoyad], [Telefon], [Adres]) VALUES (5, N'Ali', N'Veli', N'234235', N'İstanbul')
SET IDENTITY_INSERT [dbo].[Musteriler] OFF
SET IDENTITY_INSERT [dbo].[Satislar] ON 

INSERT [dbo].[Satislar] ([SatisID], [UrunID], [UrunAdet], [MusteriID], [UrunAciklama], [SatisDate]) VALUES (1, 2, 5, 2, NULL, CAST(N'2019-11-12' AS Date))
INSERT [dbo].[Satislar] ([SatisID], [UrunID], [UrunAdet], [MusteriID], [UrunAciklama], [SatisDate]) VALUES (5, 1, 1, 1, NULL, CAST(N'2019-11-12' AS Date))
INSERT [dbo].[Satislar] ([SatisID], [UrunID], [UrunAdet], [MusteriID], [UrunAciklama], [SatisDate]) VALUES (6, 4, 10, 3, NULL, CAST(N'2019-11-12' AS Date))
INSERT [dbo].[Satislar] ([SatisID], [UrunID], [UrunAdet], [MusteriID], [UrunAciklama], [SatisDate]) VALUES (7, 5, 5, 4, NULL, CAST(N'2019-11-13' AS Date))
INSERT [dbo].[Satislar] ([SatisID], [UrunID], [UrunAdet], [MusteriID], [UrunAciklama], [SatisDate]) VALUES (12, 4, 5, 2, NULL, CAST(N'2019-11-13' AS Date))
INSERT [dbo].[Satislar] ([SatisID], [UrunID], [UrunAdet], [MusteriID], [UrunAciklama], [SatisDate]) VALUES (13, 1, 2, 1, NULL, CAST(N'2019-11-13' AS Date))
INSERT [dbo].[Satislar] ([SatisID], [UrunID], [UrunAdet], [MusteriID], [UrunAciklama], [SatisDate]) VALUES (14, 4, 2, 2, NULL, CAST(N'2019-11-13' AS Date))
INSERT [dbo].[Satislar] ([SatisID], [UrunID], [UrunAdet], [MusteriID], [UrunAciklama], [SatisDate]) VALUES (15, 2, 3, 4, NULL, CAST(N'2019-11-13' AS Date))
INSERT [dbo].[Satislar] ([SatisID], [UrunID], [UrunAdet], [MusteriID], [UrunAciklama], [SatisDate]) VALUES (17, 6, 1, 2, NULL, CAST(N'2019-11-14' AS Date))
SET IDENTITY_INSERT [dbo].[Satislar] OFF
SET IDENTITY_INSERT [dbo].[Urunler] ON 

INSERT [dbo].[Urunler] ([UrunID], [KategoriID], [UrunAd], [GelisUcret], [SatisUcret], [Stok], [UrunDesc]) VALUES (1, 2, N'Kezzap', 15, 20, 2, NULL)
INSERT [dbo].[Urunler] ([UrunID], [KategoriID], [UrunAd], [GelisUcret], [SatisUcret], [Stok], [UrunDesc]) VALUES (2, 3, N'Baloncuklu Poşet', 10, 12, 2, N'gelişine ürün')
INSERT [dbo].[Urunler] ([UrunID], [KategoriID], [UrunAd], [GelisUcret], [SatisUcret], [Stok], [UrunDesc]) VALUES (4, 3, N'Pet Şişe', 3, 4, 10, N'Düzenlendi')
INSERT [dbo].[Urunler] ([UrunID], [KategoriID], [UrunAd], [GelisUcret], [SatisUcret], [Stok], [UrunDesc]) VALUES (5, 1, N'Kek', 2, 5, 25, NULL)
INSERT [dbo].[Urunler] ([UrunID], [KategoriID], [UrunAd], [GelisUcret], [SatisUcret], [Stok], [UrunDesc]) VALUES (6, 4, N'Paspas', 10, 15, 9, N'Yer silmek için')
INSERT [dbo].[Urunler] ([UrunID], [KategoriID], [UrunAd], [GelisUcret], [SatisUcret], [Stok], [UrunDesc]) VALUES (7, 5, N'Lambader', 50, 70, 5, N'Aydınlatma')
INSERT [dbo].[Urunler] ([UrunID], [KategoriID], [UrunAd], [GelisUcret], [SatisUcret], [Stok], [UrunDesc]) VALUES (8, 5, N'Yapay Çiçek', 38, 45, 10, N'Süs süs')
INSERT [dbo].[Urunler] ([UrunID], [KategoriID], [UrunAd], [GelisUcret], [SatisUcret], [Stok], [UrunDesc]) VALUES (9, 4, N'Çamaşır Suyu', 5, 8, 50, N'temizlik mis')
SET IDENTITY_INSERT [dbo].[Urunler] OFF
ALTER TABLE [dbo].[Satislar]  WITH CHECK ADD  CONSTRAINT [FK_Satislar_Urunler] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urunler] ([UrunID])
GO
ALTER TABLE [dbo].[Satislar] CHECK CONSTRAINT [FK_Satislar_Urunler]
GO
ALTER TABLE [dbo].[Urunler]  WITH CHECK ADD  CONSTRAINT [FK_Urunler_Kategoriler] FOREIGN KEY([KategoriID])
REFERENCES [dbo].[Kategoriler] ([KategoriID])
GO
ALTER TABLE [dbo].[Urunler] CHECK CONSTRAINT [FK_Urunler_Kategoriler]
GO
USE [master]
GO
ALTER DATABASE [CariHesapDB] SET  READ_WRITE 
GO
