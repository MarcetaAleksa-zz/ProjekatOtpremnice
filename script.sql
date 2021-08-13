USE [Panleksa]
GO
/****** Object:  User [Aleksa]    Script Date: 8/13/2021 6:04:15 PM ******/
CREATE USER [Aleksa] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [Panzo]    Script Date: 8/13/2021 6:04:15 PM ******/
CREATE USER [Panzo] FOR LOGIN [Panzo] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Panzo]
GO
/****** Object:  UserDefinedFunction [dbo].[Iznos]    Script Date: 8/13/2021 6:04:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUnction [dbo].[Iznos] (@Cijena INT, @Kolicina Int, @PDV bit, @Rabat Int)
REturns INT
As 
Begin	
Declare @Result Smallmoney
IF @PDV = 1  and @Rabat >0
begin
	SET @Result = (@Cijena * @Kolicina * 17) / 100 + @Cijena * @Kolicina - (@Cijena * @Kolicina * @Rabat) / 100;
	end

Else if @Pdv = 1 and @Rabat = 0
begin
	SET @Result = (@Cijena * @Kolicina * 17) / 100 + @Cijena * @Kolicina;
	end
Else if @PDV = 0 and @Rabat > 0
begin
	Set @Result = @Cijena * @Kolicina - (@Cijena * @Kolicina * @Rabat) / 100
	end
else	
begin
	Set @Result = (@Cijena * @Kolicina);
	end
RETURN 
@Result
end
GO
/****** Object:  Table [dbo].[Inventar]    Script Date: 8/13/2021 6:04:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventar](
	[id_robe] [smallint] NOT NULL,
	[naziv_robe] [nvarchar](50) NOT NULL,
	[kolicina] [smallint] NULL,
	[cijena] [smallmoney] NULL,
	[jed_mjere] [bit] NULL,
 CONSTRAINT [PK_Inventar] PRIMARY KEY CLUSTERED 
(
	[naziv_robe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Osnovne]    Script Date: 8/13/2021 6:04:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Osnovne](
	[naziv_pravnog_lica] [smallint] NULL,
	[adresa] [nvarchar](50) NULL,
	[IB] [char](13) NOT NULL,
	[otpremi_na_naslov] [nvarchar](50) NULL,
	[adresa_kupac] [nvarchar](50) NULL,
	[nacin_otpreme] [smallint] NULL,
	[reklamacija] [char](1) NULL,
	[datum] [date] NULL,
	[ID] [smallint] NOT NULL,
	[IB_kupac] [char](13) NULL,
	[reg_br_vozila_sluzbenog] [char](9) NULL,
 CONSTRAINT [PK_Osnovne] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rabat]    Script Date: 8/13/2021 6:04:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rabat](
	[rb] [nvarchar](3) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[radne_pozicije]    Script Date: 8/13/2021 6:04:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[radne_pozicije](
	[id] [smallint] NOT NULL,
	[radna_pozicija] [char](20) NULL,
 CONSTRAINT [PK_radne_pozicije] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipovi_naloga]    Script Date: 8/13/2021 6:04:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipovi_naloga](
	[id] [smallint] NOT NULL,
	[naziv] [char](20) NULL,
 CONSTRAINT [PK_tipovi_naloga] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usluge]    Script Date: 8/13/2021 6:04:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usluge](
	[redni_broj] [smallint] NULL,
	[naziv_robe] [smallint] NULL,
	[jed_mjere] [bit] NULL,
	[kolicina] [smallint] NULL,
	[cijena] [smallmoney] NULL,
	[rabat] [smallint] NULL,
	[pdv] [bit] NULL,
	[otpremnica_br] [smallint] NULL,
	[Iznos]  AS ([dbo].[Iznos]([Cijena],[Kolicina],[PDV],[rabat]))
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zaposleni]    Script Date: 8/13/2021 6:04:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zaposleni](
	[id] [smallint] NOT NULL,
	[korisnicko_ime] [nvarchar](20) NULL,
	[lozinka] [nvarchar](260) NULL,
	[tip_naloga] [smallint] NULL,
	[ime] [nvarchar](15) NULL,
	[prezime] [nvarchar](15) NULL,
	[pozicija] [smallint] NULL,
	[adresa] [nvarchar](50) NULL,
	[telefon] [char](13) NULL,
	[sluz_voz] [char](9) NULL,
	[email] [varchar](50) NULL,
	[salt] [varchar](50) NULL,
 CONSTRAINT [PK_zaposleni] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (12, N'Core i7 9th', 0, 300.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (13, N'Core i9 3rd', 81, 260.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (14, N'Core i9 5th', 77, 280.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (15, N'Core i9 7th', 42, 311.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (16, N'Core i9 9th', 25, 400.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (17, N'GeForce GTX 1550', 24, 400.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (18, N'GeForce GTX 1660', 14, 470.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (19, N'GeForce GTX 1660Ti', 12, 550.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (2, N'HDD 512GB', 200, 20.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (20, N'Instaliranje RAM-a', 3, 15.0000, 0)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (11, N'NVMe M.2 256GB', 19, 500.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (1, N'RAM DDR3 2GB', 300, 30.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (3, N'RAM DDR3 4GB', 200, 55.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (6, N'RAM DDR4 16GB ', 70, 120.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (4, N'RAM DDR4 4GB', 161, 65.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (5, N'RAM DDR4 8GB', 113, 80.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (7, N'SSD 128GB', 452, 80.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (10, N'SSD 1T', 22, 300.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (8, N'SSD 256GB', 153, 160.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (21, N'SSD 2T', 8, 550.0000, 1)
INSERT [dbo].[Inventar] ([id_robe], [naziv_robe], [kolicina], [cijena], [jed_mjere]) VALUES (9, N'SSD 512GB', 76, 220.0000, 1)
GO
INSERT [dbo].[Osnovne] ([naziv_pravnog_lica], [adresa], [IB], [otpremi_na_naslov], [adresa_kupac], [nacin_otpreme], [reklamacija], [datum], [ID], [IB_kupac], [reg_br_vozila_sluzbenog]) VALUES (5, N'Vatrenih Jahaca BB', N'4428006942051', N'Janko Vitkovic', N'Samozivih Jedrenjaka BB', 2, N'1', CAST(N'2021-06-30' AS Date), 1, N'4425896578051', N'V13-R-182')
INSERT [dbo].[Osnovne] ([naziv_pravnog_lica], [adresa], [IB], [otpremi_na_naslov], [adresa_kupac], [nacin_otpreme], [reklamacija], [datum], [ID], [IB_kupac], [reg_br_vozila_sluzbenog]) VALUES (5, N'Vatrenih Jahaca BB', N'4428006942051', N'Janko Vitkovic', N'Samozivih Jedrenjaka BB', 2, N'1', CAST(N'2021-06-30' AS Date), 2, N'4425896578051', N'V13-R-182')
INSERT [dbo].[Osnovne] ([naziv_pravnog_lica], [adresa], [IB], [otpremi_na_naslov], [adresa_kupac], [nacin_otpreme], [reklamacija], [datum], [ID], [IB_kupac], [reg_br_vozila_sluzbenog]) VALUES (5, N'Vatrenih Jahaca BB', N'4428006942051', N'Janko Vitkovic', N'Samozivih Jedrenjaka BB', 2, N'1', CAST(N'2021-06-30' AS Date), 3, N'4425896578051', N'V13-R-182')
INSERT [dbo].[Osnovne] ([naziv_pravnog_lica], [adresa], [IB], [otpremi_na_naslov], [adresa_kupac], [nacin_otpreme], [reklamacija], [datum], [ID], [IB_kupac], [reg_br_vozila_sluzbenog]) VALUES (5, N'Vatrenih Jahaca BB', N'4428006942051', N'Janko Vitkovic', N'Samozivih Jedrenjaka BB', 2, N'1', CAST(N'2021-06-30' AS Date), 4, N'4425896578051', N'V13-R-182')
INSERT [dbo].[Osnovne] ([naziv_pravnog_lica], [adresa], [IB], [otpremi_na_naslov], [adresa_kupac], [nacin_otpreme], [reklamacija], [datum], [ID], [IB_kupac], [reg_br_vozila_sluzbenog]) VALUES (5, N'Vatrenih Jahaca BB', N'4428006942051', N'Janko Vitkovic', N'Samozivih Jedrenjaka BB', 2, N'1', CAST(N'2021-06-30' AS Date), 5, N'4425896578051', N'V13-R-182')
GO
INSERT [dbo].[rabat] ([rb]) VALUES (N'0')
INSERT [dbo].[rabat] ([rb]) VALUES (N'1')
INSERT [dbo].[rabat] ([rb]) VALUES (N'2')
INSERT [dbo].[rabat] ([rb]) VALUES (N'3')
INSERT [dbo].[rabat] ([rb]) VALUES (N'4')
INSERT [dbo].[rabat] ([rb]) VALUES (N'5')
INSERT [dbo].[rabat] ([rb]) VALUES (N'6')
INSERT [dbo].[rabat] ([rb]) VALUES (N'7')
INSERT [dbo].[rabat] ([rb]) VALUES (N'8')
INSERT [dbo].[rabat] ([rb]) VALUES (N'9')
INSERT [dbo].[rabat] ([rb]) VALUES (N'10')
INSERT [dbo].[rabat] ([rb]) VALUES (N'11')
INSERT [dbo].[rabat] ([rb]) VALUES (N'12')
INSERT [dbo].[rabat] ([rb]) VALUES (N'13')
INSERT [dbo].[rabat] ([rb]) VALUES (N'14')
INSERT [dbo].[rabat] ([rb]) VALUES (N'15')
INSERT [dbo].[rabat] ([rb]) VALUES (N'16')
INSERT [dbo].[rabat] ([rb]) VALUES (N'17')
INSERT [dbo].[rabat] ([rb]) VALUES (N'18')
INSERT [dbo].[rabat] ([rb]) VALUES (N'19')
INSERT [dbo].[rabat] ([rb]) VALUES (N'20')
INSERT [dbo].[rabat] ([rb]) VALUES (N'21')
INSERT [dbo].[rabat] ([rb]) VALUES (N'22')
INSERT [dbo].[rabat] ([rb]) VALUES (N'23')
INSERT [dbo].[rabat] ([rb]) VALUES (N'24')
INSERT [dbo].[rabat] ([rb]) VALUES (N'25')
INSERT [dbo].[rabat] ([rb]) VALUES (N'26')
INSERT [dbo].[rabat] ([rb]) VALUES (N'27')
INSERT [dbo].[rabat] ([rb]) VALUES (N'28')
INSERT [dbo].[rabat] ([rb]) VALUES (N'29')
INSERT [dbo].[rabat] ([rb]) VALUES (N'30')
INSERT [dbo].[rabat] ([rb]) VALUES (N'31')
INSERT [dbo].[rabat] ([rb]) VALUES (N'32')
INSERT [dbo].[rabat] ([rb]) VALUES (N'33')
INSERT [dbo].[rabat] ([rb]) VALUES (N'34')
INSERT [dbo].[rabat] ([rb]) VALUES (N'35')
INSERT [dbo].[rabat] ([rb]) VALUES (N'36')
INSERT [dbo].[rabat] ([rb]) VALUES (N'37')
INSERT [dbo].[rabat] ([rb]) VALUES (N'38')
INSERT [dbo].[rabat] ([rb]) VALUES (N'39')
INSERT [dbo].[rabat] ([rb]) VALUES (N'40')
INSERT [dbo].[rabat] ([rb]) VALUES (N'41')
INSERT [dbo].[rabat] ([rb]) VALUES (N'42')
INSERT [dbo].[rabat] ([rb]) VALUES (N'43')
INSERT [dbo].[rabat] ([rb]) VALUES (N'44')
INSERT [dbo].[rabat] ([rb]) VALUES (N'45')
INSERT [dbo].[rabat] ([rb]) VALUES (N'46')
INSERT [dbo].[rabat] ([rb]) VALUES (N'47')
INSERT [dbo].[rabat] ([rb]) VALUES (N'48')
INSERT [dbo].[rabat] ([rb]) VALUES (N'49')
INSERT [dbo].[rabat] ([rb]) VALUES (N'50')
INSERT [dbo].[rabat] ([rb]) VALUES (N'51')
INSERT [dbo].[rabat] ([rb]) VALUES (N'52')
INSERT [dbo].[rabat] ([rb]) VALUES (N'53')
INSERT [dbo].[rabat] ([rb]) VALUES (N'54')
INSERT [dbo].[rabat] ([rb]) VALUES (N'55')
INSERT [dbo].[rabat] ([rb]) VALUES (N'56')
INSERT [dbo].[rabat] ([rb]) VALUES (N'57')
INSERT [dbo].[rabat] ([rb]) VALUES (N'58')
INSERT [dbo].[rabat] ([rb]) VALUES (N'59')
INSERT [dbo].[rabat] ([rb]) VALUES (N'60')
INSERT [dbo].[rabat] ([rb]) VALUES (N'61')
INSERT [dbo].[rabat] ([rb]) VALUES (N'62')
INSERT [dbo].[rabat] ([rb]) VALUES (N'63')
INSERT [dbo].[rabat] ([rb]) VALUES (N'64')
INSERT [dbo].[rabat] ([rb]) VALUES (N'65')
INSERT [dbo].[rabat] ([rb]) VALUES (N'66')
INSERT [dbo].[rabat] ([rb]) VALUES (N'67')
INSERT [dbo].[rabat] ([rb]) VALUES (N'68')
INSERT [dbo].[rabat] ([rb]) VALUES (N'69')
INSERT [dbo].[rabat] ([rb]) VALUES (N'70')
INSERT [dbo].[rabat] ([rb]) VALUES (N'71')
INSERT [dbo].[rabat] ([rb]) VALUES (N'72')
INSERT [dbo].[rabat] ([rb]) VALUES (N'73')
INSERT [dbo].[rabat] ([rb]) VALUES (N'74')
INSERT [dbo].[rabat] ([rb]) VALUES (N'75')
INSERT [dbo].[rabat] ([rb]) VALUES (N'76')
INSERT [dbo].[rabat] ([rb]) VALUES (N'77')
INSERT [dbo].[rabat] ([rb]) VALUES (N'78')
INSERT [dbo].[rabat] ([rb]) VALUES (N'79')
INSERT [dbo].[rabat] ([rb]) VALUES (N'80')
INSERT [dbo].[rabat] ([rb]) VALUES (N'81')
INSERT [dbo].[rabat] ([rb]) VALUES (N'82')
INSERT [dbo].[rabat] ([rb]) VALUES (N'83')
INSERT [dbo].[rabat] ([rb]) VALUES (N'84')
INSERT [dbo].[rabat] ([rb]) VALUES (N'85')
INSERT [dbo].[rabat] ([rb]) VALUES (N'86')
INSERT [dbo].[rabat] ([rb]) VALUES (N'87')
INSERT [dbo].[rabat] ([rb]) VALUES (N'88')
INSERT [dbo].[rabat] ([rb]) VALUES (N'89')
INSERT [dbo].[rabat] ([rb]) VALUES (N'90')
INSERT [dbo].[rabat] ([rb]) VALUES (N'91')
INSERT [dbo].[rabat] ([rb]) VALUES (N'92')
INSERT [dbo].[rabat] ([rb]) VALUES (N'93')
INSERT [dbo].[rabat] ([rb]) VALUES (N'94')
INSERT [dbo].[rabat] ([rb]) VALUES (N'95')
INSERT [dbo].[rabat] ([rb]) VALUES (N'96')
INSERT [dbo].[rabat] ([rb]) VALUES (N'97')
INSERT [dbo].[rabat] ([rb]) VALUES (N'98')
INSERT [dbo].[rabat] ([rb]) VALUES (N'99')
GO
INSERT [dbo].[rabat] ([rb]) VALUES (N'100')
GO
INSERT [dbo].[radne_pozicije] ([id], [radna_pozicija]) VALUES (1, N'Administrator       ')
INSERT [dbo].[radne_pozicije] ([id], [radna_pozicija]) VALUES (2, N'Vlasnik             ')
INSERT [dbo].[radne_pozicije] ([id], [radna_pozicija]) VALUES (3, N'Sef Skladista       ')
INSERT [dbo].[radne_pozicije] ([id], [radna_pozicija]) VALUES (4, N'Menadzer Skladista  ')
INSERT [dbo].[radne_pozicije] ([id], [radna_pozicija]) VALUES (5, N'Direktor Marketinga ')
INSERT [dbo].[radne_pozicije] ([id], [radna_pozicija]) VALUES (6, N'Radnik              ')
INSERT [dbo].[radne_pozicije] ([id], [radna_pozicija]) VALUES (7, N'Vozac               ')
GO
INSERT [dbo].[tipovi_naloga] ([id], [naziv]) VALUES (1, N'Administrator       ')
INSERT [dbo].[tipovi_naloga] ([id], [naziv]) VALUES (2, N'Zaposleni           ')
INSERT [dbo].[tipovi_naloga] ([id], [naziv]) VALUES (3, N'Sefovi              ')
GO
INSERT [dbo].[Usluge] ([redni_broj], [naziv_robe], [jed_mjere], [kolicina], [cijena], [rabat], [pdv], [otpremnica_br]) VALUES (1, 1, 1, 12, 30.0000, 0, 0, 1)
INSERT [dbo].[Usluge] ([redni_broj], [naziv_robe], [jed_mjere], [kolicina], [cijena], [rabat], [pdv], [otpremnica_br]) VALUES (1, 3, 1, 3, 55.0000, 0, 0, 2)
INSERT [dbo].[Usluge] ([redni_broj], [naziv_robe], [jed_mjere], [kolicina], [cijena], [rabat], [pdv], [otpremnica_br]) VALUES (1, 6, 1, 12, 120.0000, 0, 0, 3)
INSERT [dbo].[Usluge] ([redni_broj], [naziv_robe], [jed_mjere], [kolicina], [cijena], [rabat], [pdv], [otpremnica_br]) VALUES (1, 7, 1, 3, 80.0000, 75, 1, 4)
INSERT [dbo].[Usluge] ([redni_broj], [naziv_robe], [jed_mjere], [kolicina], [cijena], [rabat], [pdv], [otpremnica_br]) VALUES (1, 11, 1, 17, 500.0000, 15, 1, 5)
GO
INSERT [dbo].[zaposleni] ([id], [korisnicko_ime], [lozinka], [tip_naloga], [ime], [prezime], [pozicija], [adresa], [telefon], [sluz_voz], [email], [salt]) VALUES (1, N'aleksa', N'€2290E425D6ABDBA9765581D5844D21364F2CD40D79D7FB60721C74321881890EB438A178F73172E2EEC53F9FE6B4211BDFC14FB1B5041A1A6673B622123E2BA7', 1, N'Aleksa', N'Marceta', 1, N'Osvajackih brigada 11', N'+38766311227 ', N'M69-A-420', N'aleksa.marceta2@apeiron-edu.eu', N'Jugoslavija')
INSERT [dbo].[zaposleni] ([id], [korisnicko_ime], [lozinka], [tip_naloga], [ime], [prezime], [pozicija], [adresa], [telefon], [sluz_voz], [email], [salt]) VALUES (2, N'aleksandar', N'€FAE7748CB4825E92EA80BBAFEA2F366E82B0C102D0882362D966D63BE81C22705ECB1EEA3E53D9612E70CAE4F8396907B2279FD6341AA8C40F0DE7318F2C9643', 1, N'Aleksandar', N'Panzalovic', 1, N'Odbrambenih brigada 69', N'+38766311228 ', N'M69-A-420', N'aco.panzalovic@gmail.com', N'Srbija')
INSERT [dbo].[zaposleni] ([id], [korisnicko_ime], [lozinka], [tip_naloga], [ime], [prezime], [pozicija], [adresa], [telefon], [sluz_voz], [email], [salt]) VALUES (3, N'dragomir', N'€D1DD11AA65C85956A0B15CA23FCA846D6F552056EB4FB34A08E11EF3044A14E6987549BD7468B9AE80C68E76666A498443D92617B159E04A94F12E2BE1C6BBFD', 3, N'Dragomir', N'Jevric', 3, N'Nikolije Jakovljevica 99i', N'+38766311229 ', N'S66-T-429', N'dragomir.jevric@gmail.com', N'Dragica')
INSERT [dbo].[zaposleni] ([id], [korisnicko_ime], [lozinka], [tip_naloga], [ime], [prezime], [pozicija], [adresa], [telefon], [sluz_voz], [email], [salt]) VALUES (4, N'radenko', N'€0F819823AABD59B518985169FEFF2CFE0B5FA872EE6295AECDFE516ACFC2DA527920C96348135686E6113EA3F31CAFA1B97974D69DEECA116AC6D737531D5A1B', 3, N'Radenko', N'Gligovic', 4, N'Slavuljice Janka 52', N'+38766311230 ', N'S66-T-429', N'radenko.gligovic@gmail.com', N'R4jk0')
INSERT [dbo].[zaposleni] ([id], [korisnicko_ime], [lozinka], [tip_naloga], [ime], [prezime], [pozicija], [adresa], [telefon], [sluz_voz], [email], [salt]) VALUES (5, N'mirko', N'€3622688DB3137A53992F1CE4B325D1CFEAE95DDDCFA4612E63012D89F78ABBEFFF90C91F15D89DC3584AE1A5A94A2D98E9B99E55E028C3A409F983C738972ECB', 2, N'Mirko', N'Mianovic', 6, N'Jevgenija Ohridejskog 49', N'+38766311231 ', N'V13-R-182', N'mirko.mirko@gmail.com', N'Jevgenje')
INSERT [dbo].[zaposleni] ([id], [korisnicko_ime], [lozinka], [tip_naloga], [ime], [prezime], [pozicija], [adresa], [telefon], [sluz_voz], [email], [salt]) VALUES (6, N'rajka', N'€86D394F7F59C6352CEF3C439F078A03F2936B5BF3FA80422E0E7410EB7AA6B416E5C9528C188C9B0451BCCAD3820B1CB1B1E0ACE55B96DA483FF8F8BB93710D0', 3, N'Rajka', N'Jevric', 5, N'Nikolije Jakovljevica 99i', N'+38766311232 ', N'S66-T-429', N'rajka.jevric@gmail.com', N'Slanina ')
INSERT [dbo].[zaposleni] ([id], [korisnicko_ime], [lozinka], [tip_naloga], [ime], [prezime], [pozicija], [adresa], [telefon], [sluz_voz], [email], [salt]) VALUES (7, N'slavojko', N'€910EB33940DF5459602E927002600D97DE2D707448E016E933EB835A77DA279E22E92F6F61E5A36F7000B3BA55C08AD84040D17F374A9165672E84910C4D7030', 3, N'Slavojko', N'Cvrkut', 2, N'Sofronija Crnog 420', N'+38766311233 ', N'S66-T-429', N'slavojko.cvrkut@gmail.com', N'Glad')
INSERT [dbo].[zaposleni] ([id], [korisnicko_ime], [lozinka], [tip_naloga], [ime], [prezime], [pozicija], [adresa], [telefon], [sluz_voz], [email], [salt]) VALUES (8, N'zagorka', N'€69E9F0C9AEFDCA4DD526C04A0D7E27D268A6F0EFD242FA3626261A42E0407AA22F0A84883F4D43C8A81976CCFB2D638A04F922D2EE5CC621E20B5D2A76338F06', 2, N'Zagorka', N'Kantar', 6, N'Sirote Jagnjati', N'+38766311234 ', N'V13-R-183', N'zagorko.kantar@gmail.com', N'Snicla  ')
INSERT [dbo].[zaposleni] ([id], [korisnicko_ime], [lozinka], [tip_naloga], [ime], [prezime], [pozicija], [adresa], [telefon], [sluz_voz], [email], [salt]) VALUES (9, N'dobrasin', N'€07C65DDC5297C28CDE4C79704FF3E93A00BA11C7186A8FF4721DDD484FDE7F39C8C4AE9F9A2A94302CCAD9A6C99453BE065D03CADBFF284FA591BFD3150A17CA', 2, N'Dobrasin', N'Pandrc', 2, N'Pataftovih Drugova 1', N'+38766311235 ', N'V13-R-184', N'dobrasin.pandrc@gmail.com', N'Kupus   ')
INSERT [dbo].[zaposleni] ([id], [korisnicko_ime], [lozinka], [tip_naloga], [ime], [prezime], [pozicija], [adresa], [telefon], [sluz_voz], [email], [salt]) VALUES (10, N'bisenija', N'€80896E9C828DD5A09BEA9D8CCB0BAC6B6E1ED3CAF559B35D1F0AAA89736A5A8DD416B0F6F55F0A446FA47AF460E1E5726EC3342EC357DA23EF0B5DA74DA27D9C', 2, N'Bisenija', N'Hrkman', 2, N'Heleta Tabasa 6', N'+38766311236 ', N'V13-R-185', N'bisenija.hrkman@gmail.com', N'Krompir')
INSERT [dbo].[zaposleni] ([id], [korisnicko_ime], [lozinka], [tip_naloga], [ime], [prezime], [pozicija], [adresa], [telefon], [sluz_voz], [email], [salt]) VALUES (11, N'persida', N'€13CC906EC845CCF3D32A34EA1BCB076BC8A6AE63C4791043073AABDE2DF945193C0DE6D99216EE171FE69C567D7835B789518BE64C20F54F1EC2F7FA822B8410', 2, N'Persida', N'Matavulj', 2, N'Ispod Mosta Kuljani 15', N'+38766311237 ', N'V13-R-186', N'persida.matavulj@gmail.com', N'Musaka')
INSERT [dbo].[zaposleni] ([id], [korisnicko_ime], [lozinka], [tip_naloga], [ime], [prezime], [pozicija], [adresa], [telefon], [sluz_voz], [email], [salt]) VALUES (12, N'uzahije', N'€9727770DA8EB81DE08A0843A56728E72BD61F13F5C4F6C21FC915D4E1AFCA298C9674ADB365F0DF0AD6241A7B0D6131A9B9A5D0FFFD06C2B330339221F519635', 2, N'Uzahije', N'Promaja', 2, N'Vjetrovitih Puteva 8', N'+38766311238 ', N'V13-R-187', N'uzahije.promaja@gmail.com', N'Lazanje')
GO
ALTER TABLE [dbo].[Osnovne]  WITH CHECK ADD  CONSTRAINT [FK_Osnovne_Osnovne] FOREIGN KEY([naziv_pravnog_lica])
REFERENCES [dbo].[zaposleni] ([id])
GO
ALTER TABLE [dbo].[Osnovne] CHECK CONSTRAINT [FK_Osnovne_Osnovne]
GO
ALTER TABLE [dbo].[zaposleni]  WITH CHECK ADD  CONSTRAINT [FK_zaposleni_radne_pozicije] FOREIGN KEY([pozicija])
REFERENCES [dbo].[radne_pozicije] ([id])
GO
ALTER TABLE [dbo].[zaposleni] CHECK CONSTRAINT [FK_zaposleni_radne_pozicije]
GO
ALTER TABLE [dbo].[zaposleni]  WITH CHECK ADD  CONSTRAINT [FK_zaposleni_tipovi_naloga] FOREIGN KEY([tip_naloga])
REFERENCES [dbo].[tipovi_naloga] ([id])
GO
ALTER TABLE [dbo].[zaposleni] CHECK CONSTRAINT [FK_zaposleni_tipovi_naloga]
GO
